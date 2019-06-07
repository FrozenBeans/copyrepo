using System;
using System.Collections.Generic;

namespace Domain
{
    public class UserInfo
    {
        private string _username;
        private string _password;
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int? phonenumber { get; set; }
        public int userId { get; set; }
        public string username
        {
            get => _username;
            set
            {
                /*if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty.", nameof(value));
                }*/
                _username = value;
            }
        }
        public string password
        {
            get => _password;
            set
            {/*
                if (value.Length < 6)
                {
                    throw new ArgumentException("Password must be more than 5 characters.", nameof(value));
                }
                */
                _password = value;
                
            }
        }
        public string GetName(string fname, string lname)
        {
            return $"{fname} {lname}";
        }

    }
}
