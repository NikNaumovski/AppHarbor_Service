using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Script.Serialization;

namespace WEB_SERVICE
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        } 
        /// <summary>
        /// Check User Creditentials
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [WebMethod(Description = "Check User Creditentials")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json,UseHttpGet=true)]
        public void CheckUserCreditentials(string username, string password)
        {
            SqlConnection sqlconn = new SqlConnection();
            sqlconn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlCommand sqlcomm = new SqlCommand("SELECT TOP 1 * FROM Users WHERE user_login_name=@login and user_password=@pass", sqlconn);
            sqlcomm.Parameters.AddWithValue("@login", username);
            sqlcomm.Parameters.AddWithValue("@pass", password);
            DataSet ds = new DataSet();
            SqlDataAdapter sqladt = new SqlDataAdapter(sqlcomm);
            sqladt.Fill(ds, "User");
            try
            {
                sqlconn.Open();
                string str = Convert.ToString(sqlcomm.ExecuteScalar());//returnsfirst database column:user_id
                if (str != "")
                {
                    User US = new User();
                    foreach (DataRow dr in ds.Tables["User"].Rows)
                    {
                        US.id = (int)dr["user_id"];
                        US.first_name = dr["user_first_name"].ToString();
                        US.last_name = dr["user_last_name"].ToString();
                        US.login_name = dr["user_login_name"].ToString();
                        US.password = dr["user_password"].ToString();
                        // US.login = DateTime.Now;
                    }
                    this.Context.Response.ContentType = "application/json";
                    JavaScriptSerializer js = new JavaScriptSerializer();
                     string json = js.Serialize(US);

                     //nema potreba od serializer koga imame postaveno [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
                    //kompleten setup na povratniot context od web service 
                    //po default servisot podatocite gi vraka smesteni vo XML shema
                     this.Context.Response.ContentType = "application/json; charset=utf-8";
                     this.Context.Response.Output.Write(json);
                }
            }
            catch (Exception err) { }
            finally { sqlconn.Close(); } 
        }

        [WebMethod(Description = "new User Access")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void newUserAccess(string firstname,string lastname,string loginname,string password) {
            SqlConnection sqlconn = new SqlConnection();
            sqlconn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlCommand sqlcomm = new SqlCommand("INSERT INTO Users (user_first_name,user_last_name,user_login_name,user_password) VALUES (@user_first_name,@user_last_name,@user_login_name,@user_password)",sqlconn);
            sqlcomm.Parameters.AddWithValue("@user_first_name", firstname);
            sqlcomm.Parameters.AddWithValue("@user_last_name", lastname);
            sqlcomm.Parameters.AddWithValue("@user_login_name", loginname);
            sqlcomm.Parameters.AddWithValue("@user_password", password);

            int ok = 0;
            try
            {
                sqlconn.Open();
                ok = sqlcomm.ExecuteNonQuery();
            }
            catch (Exception err)
            {

            }
            finally
            {
                sqlconn.Close();
            }

            if (ok == 0)
            {
               
                Check ch = new Check();
                ch.check = "FALSE";
               // this.Context.Response.ContentType = "application/json";
                JavaScriptSerializer jsFalse = new JavaScriptSerializer();
                string json = jsFalse.Serialize(ch);
                //nema potreba od serializer koga imame postaveno [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
                //kompleten setup na povratniot context od web service 
                //po default servisot podatocite gi vraka smesteni vo XML shema
                this.Context.Response.ContentType = "application/json; charset=utf-8";
                this.Context.Response.Output.Write(json);
               // return json;
            }
            else 
            {
                Check ch = new Check();
                ch.check = "TRUE";
                //this.Context.Response.ContentType = "application/json";
                JavaScriptSerializer jsTrue = new JavaScriptSerializer();
                string json = jsTrue.Serialize(ch);
                //nema potreba od serializer koga imame postaveno [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
                //kompleten setup na povratniot context od web service 
                //po default servisot podatocite gi vraka smesteni vo XML shema
                this.Context.Response.ContentType = "application/json; charset=utf-8";
                this.Context.Response.Output.Write(json);
               // return json;
            }
        }
    }
}