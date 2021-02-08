using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace TestPocApp.Data
{
    public interface iLocalDB
    {
        Task<List<Account>> GetAccountsAsync();
        Task<Account> GetAccountAsync(string userName);
        Task<int> SaveAccountAsync(Account userAccount);
        bool IsValidUser(string userName);
        bool IsValidUser(string userName, string password);
    }
}