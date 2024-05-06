using HCA.DbModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Security.Claims;

namespace HCA.Controllers
{
    public class LogInController : Controller
    {
        private readonly HCAContext _context;

        public LogInController(HCAContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel input, string ReturnUrl)
        {
            ResponseModel resp = new ResponseModel();
            var claims = new List<Claim>();
            var ip = _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString();
            try
            {
                if (!string.IsNullOrEmpty(ReturnUrl))
                {
                    if (ReturnUrl.Contains("Error"))
                    {
                        ReturnUrl = "";
                    }
                }
                if (input.Email == null || input.Password == null)
                {
                    resp.HasError = true;
                    resp.Message = "Invalid Information, make sure you have entered Username and password..";
                    return Json(resp);
                }
                // var user = await _context.AppUser.Where(e => e.Email == input.Email && e.IsActive == true).FirstOrDefaultAsync();
                var emailParam = new SqlParameter("Email", DBNull.Value);
                emailParam.Value = input.Email;

                var user = await _context.AppUserViewModelQuery.FromSqlRaw(@"select top 1 * from AppUser
where Email = @Email and IsActive = 1", emailParam).FirstOrDefaultAsync();

                if (user == null)
                {
                    resp.HasError = true;
                    resp.Message = "UserName not found";
                    return Json(resp);
                }
                LoginLogDBModel loginLog = new LoginLogDBModel();
                if (Security.VerifyHashedPassword(user.Password, input.Password) == false)
                {
                    if (ip.Contains("::"))
                    {
                        ip = "DeveloperMachine";
                    }

                    loginLog.IPAddress = ip;

                    var iploc = new IPLocation();
                    var API_PATH_IP_API = "http://ip-api.com/json/" + ip;
                    IPLocation iPlocation = new IPLocation();
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        //For IP-API
                        client.BaseAddress = new Uri(API_PATH_IP_API);
                        HttpResponseMessage response = client.GetAsync(API_PATH_IP_API).GetAwaiter().GetResult();
                        if (response.IsSuccessStatusCode)
                        {
                            var locationDetails = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                            iploc = JsonConvert.DeserializeObject<IPLocation>(locationDetails);
                            // iPlocation = (IPLocation)locationDetails;


                        }
                    }

                    var emailLog = new EmailDbModel
                    {
                        EmailFrom = "noreply@saharahomecare.com",
                        EmailTo = user.Email,
                        EmailSubject = "Invalid Attempts",
                        EmailBody = "tring to signIn with Invalid Password attemps. You're getting this email to make sure it was you., from Location: </br></hr> " + JsonConvert.SerializeObject(iploc)
                    };

                    _context.Emails.Add(emailLog);
                    var emailsave = await _context.SaveChangesAsync();

                    //  SMTP.SendEmail(user.Email, "InValid Attempts", "Your New CRM SarahaHomeCare Account was just try to signIn with Invalid Password attemps. You're getting this email to make sure it was you., from IP Address:  " + ip);
                    loginLog.UserName = user.Email;
                    loginLog.UserId = user.Id;
                    loginLog.Status = "InCorrectPassword";
                    loginLog.Remarks = "User has tried from IP: " + ip + " with Invalid Password";
                    loginLog.CreatedOn = DateTime.Now;

                    _context.LoginLogs.Add(loginLog);
                    _context.SaveChanges();
                    resp.HasError = true;
                    resp.Message = "UserName or Password does not match, Your IP< " + ip + "> recorded";
                    return Json(resp);
                }



                var userRoles = user.UserRole;

                if (string.IsNullOrEmpty(userRoles))
                {
                    resp.HasError = true;
                    resp.Message = "Invalid Login";
                    return Json(resp);
                }

                ip = _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString();

                loginLog.IPAddress = ip;
                loginLog.UserName = user.Email;
                loginLog.UserId = user.Id;
                loginLog.Status = "Success";
                loginLog.Remarks = "User has Login from IP: " + ip + " with Role: " + userRoles;
                loginLog.CreatedOn = DateTime.Now;

                _context.LoginLogs.Add(loginLog);
                _context.SaveChanges();

                //Set user role, permissions then later use in application.

                string profilePhotoPath = "defaultAvatar.jpg";
                var userProfilePhoto = user.PhotoPath;
                if (!string.IsNullOrEmpty(user.PhotoPath))
                {
                    userProfilePhoto = user.PhotoPath;

                }


                claims.Add(new Claim("RoleId", userRoles));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                claims.Add(new Claim("UserName", user.FullName));
                claims.Add(new Claim("UserId", user.Id.ToString()));
                claims.Add(new Claim("EmpId", user.EmpId != null ? user.EmpId.Value.ToString() : "0"));
                claims.Add(new Claim("UserEmail", input.Email.ToString()));
                claims.Add(new Claim("CompanyId", user.CompanyId != null ? user.CompanyId.Value.ToString() : "0"));
                claims.Add(new Claim("ProfilePhoto", profilePhotoPath));




                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //   var claimPrincipal = new ClaimsPrincipal(claimsIdentity);
                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    IsPersistent = false,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                //User.IsInRole

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                resp.Message = "/Home";

                if (!string.IsNullOrEmpty(ReturnUrl))
                {
                    resp.Message = ReturnUrl;
                }

                return Json(resp);
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }

            return Json(new { });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
