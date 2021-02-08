using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestPocApp.Data
{
    public class Account
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Username
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }
        public string Phone
        {
            get; set;
        }
        public string FirstName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public string ServiceDate
        {
            get; set;
        }

    }
}