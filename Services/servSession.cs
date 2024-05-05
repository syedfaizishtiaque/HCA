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

        public async Task<List<SessionModel>> GetData(string username)
        {
            List<SessionModel> session = new List<SessionModel>();
            try
            {
                session = await GetSession(username);
                return session;
            }
            catch (Exception ex)
            {
                await servErrorLog.WriteErrorLog("Error", ex, "GetData/Serv_Session");
            }
            return session;
        }

        private async Task<List<SessionModel>> GetSession(string username)
        {
            List<SessionModel> list = new List<SessionModel>();
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    //  list = context.Set<SessionModel>().FromSqlRaw(@"Exec sp_Logindata @username , @appId", new { username = username, appId = 9 }).ToList();
                }
            }
            catch (Exception ex)
            {
                await servErrorLog.WriteErrorLog("Error", ex, "IsValidUser/Serv_Session");
            }
            return list;
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
