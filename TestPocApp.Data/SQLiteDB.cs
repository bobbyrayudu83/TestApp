using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace TestPocApp.Data
{
    public class SQLiteDB : iLocalDB
    {
        readonly SQLiteAsyncConnection _database;

        public SQLiteDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Account>().Wait();
        }

        public Task<List<Account>> GetAccountsAsync()
        {
            return _database.Table<Account>().ToListAsync();
        }

        public Task<int> SaveAccountAsync(Account userAcc)
        {
            return _database.InsertAsync(userAcc);
        }

        public Task<Account> GetAccountAsync(string userName)
        {
            return _database.Table<Account>().FirstOrDefaultAsync(usr=>usr.Username == userName);
        }
        public bool IsValidUser(string userName) 
        {
            var userAcc = _database.Table<Account>().FirstOrDefaultAsync(usr => usr.Username == userName);
            if (userAcc != null)
                return true;
            else
                return false;
        }
        public bool IsValidUser(string userName, string password)
        {
            var userAcc = _database.Table<Account>()
                .FirstOrDefaultAsync(usr => usr.Username == userName && usr.Password == password);
            
            if (userAcc != null)
                return true;
            else
                return false;
        }
    }
}