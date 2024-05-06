using HCA.DbModels;
using HCA.Models;
using Microsoft.EntityFrameworkCore;

namespace HCA.Services
{
    public class servSession : IDisposable
    {
        public HCAContext context;
        public servSession(HCAContext _context)
        {
            context = _context;
        }

        public async Task<List<vu_menu_details>> GetMenuData(int user_sk)
        {
            List<vu_menu_details> session = new List<vu_menu_details>();
            try
            {
                
                    session = context.Set<vu_menu_details>().FromSqlRaw(@"Exec spLoginValidation @username , @password", new { username = user_sk }).ToList();
                
            }
            catch (Exception ex)
            {
                await servErrorLog.WriteErrorLog("Error", ex, "IsValidUser/Serv_Session");
            }
            return session;
        }

        private async Task<vu_user_details> GetUserData(string username , string password)
        {
            vu_user_details obj = new vu_user_details(); 
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                      obj = context.Set<vu_user_details>().FromSqlRaw(@"Exec spLoginValidation @username , @password", new { username = username, password = password }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                
                await servErrorLog.WriteErrorLog("Error", ex, "IsValidUser/Serv_Session");
                
            }
            return obj;
        }

        public async Task<bool> IsValiduser(string userId, string password)
        {
            servHash hash = new servHash();
            bool result = false;
            try
            {
                result = await (from q in context.Users
                                where q.UserName.ToLower() == userId.ToLower() &&
                                      q.Password == hash.HashPasword(password)
                                select q.UserSk
                 ).AnyAsync();
            }
            catch (Exception ex)
            {
                result = false;
                await servErrorLog.WriteErrorLog("Error", ex, "IsValidUser/Serv_Session");
            }
            return result;
        }
        public void Dispose()
        {
            //_ConnectionString = string.Empty;
        }
    }
}
