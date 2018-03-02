using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;


namespace Website_revision
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public class items
        {
            public string name { get; set; }
            public string html_url { get; set; }
            public string language { get; set; }
            public string commits_url { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpWebRequest request = WebRequest.Create("https://api.github.com/users/"+ txtUsername.Text + "/repos") as HttpWebRequest;
            request.Method = "GET";
            request.UserAgent = "Website revision";

            try
            {
                string jsonString;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    jsonString = reader.ReadToEnd();
                }

                List<items> item = JsonConvert.DeserializeObject<List<items>>(jsonString);

                foreach (var items in item)
                {
                    Response.Write("<a class='reponame' href=" + items.html_url.ToString() + ">" + items.name.ToString() + "</a> <br/>");
                    Response.Write("<div class='language '>" + items.language.ToString() + "</div>");
                    //Repo.InnerText = Response.Write("<a href = " + items.html_url.ToString() + " > " + items.name.ToString() + "</ a >");
                }
                return;
            }
            catch(Exception ex)
            {
                Console.WriteLine("{0} Execption caught",ex);
            }
        }
    }
}