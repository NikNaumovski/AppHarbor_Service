using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_SERVICE
{
    public class User
    {
        private int user_id;
        private string user_first_name;
        private string user_last_name;
        private string user_login_name;
        private string user_password;
        //private DateTime last_login;


        public int id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        public string first_name
        {
            get { return user_first_name; }
            set { user_first_name = value; }
        }
        public string last_name
        {
            get { return user_last_name; }
            set { user_last_name = value; }
        }
        public string login_name
        {
            get { return user_login_name; }
            set { user_login_name = value; }
        }
        public string password
        {
            get { return user_password; }
            set { user_password = value; }
        }
        //public DateTime  login
        //{
        //    get { return last_login; }
        //    set { last_login = value; }
        //} 
    }
}