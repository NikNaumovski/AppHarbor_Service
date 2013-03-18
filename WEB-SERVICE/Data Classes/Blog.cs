using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_SERVICE
{
    public class Blog
    {
        private int id_blog;
        private string name_blog;
        private string url_blog;
        private string description_blog;
        private string owner_blog;

        public int id {
            get { return id_blog; }
            set { id_blog = value; }
        }
        public string name
        {
            get { return name_blog; }
            set { name_blog = value; }
        }
        public string url
        {
            get { return url_blog; }
            set { url_blog = value; }
        }
        public string description
        {
            get { return description_blog; }
            set { description_blog = value; }
        }
        public string owner
        {
            get { return owner_blog; }
            set { owner_blog = value; }
        }
    }
}