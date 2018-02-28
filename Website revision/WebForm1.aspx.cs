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
using Octokit;


namespace Website_revision
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            var github = new GitHubClient(new Octokit.ProductHeaderValue("Website revision"));
            var user = github.User.Get("StageJuice");
            lblRepo.Text = ;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpWebRequest request = WebRequest.Create("https://api.github.com/users/"+ txtUsername.Text + "/repos?per_page=10") as HttpWebRequest;
            request.Method = "GET";
            request.UserAgent = "Website revision";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    lblRepo.Text = reader.ReadToEnd();
            }
            
        }
    }
}