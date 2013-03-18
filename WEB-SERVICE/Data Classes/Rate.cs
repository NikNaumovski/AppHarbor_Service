using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_SERVICE
{
    public class Rate
    {
        private int id_blog;
        private int blog_rate;
        private DateTime blog_date_rate;


        public int id
        {
            get { return id_blog; }
            set { id_blog = value; }
        }
        public int rate
        {
            get { return blog_rate; }
            set { blog_rate = value; }
        }
        public DateTime date_rate
        {
            get { return blog_date_rate; }
            set { blog_date_rate = value; }
        }
    }
}