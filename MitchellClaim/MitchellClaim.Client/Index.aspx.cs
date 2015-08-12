using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MitchellClaim.Client
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblxmlLocation1.Text = string.Format("{0}\\bin\\create-claim.xml", AppDomain.CurrentDomain.BaseDirectory);
        }

        protected void btnAddClaim_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string xmlFileLocation = string.Format("{0}\\bin\\create-claim.xml", AppDomain.CurrentDomain.BaseDirectory);
            using (StreamReader inputQueryReader = new StreamReader(xmlFileLocation))
            {
                sb.Append(inputQueryReader.ReadToEnd());
            }
            PostXMLData("http://localhost:50072/api/mitchellclaim", sb.ToString());
        }
        public string PostXMLData(string destinationUrl, string requestXml)
        {
            // Restful service URL
            //string url = txtURL.Text;

            // declare ascii encoding
            ASCIIEncoding encoding = new ASCIIEncoding();
            string strResult = string.Empty;
            // sample xml sent to Service & this data is sent in POST
            string SampleXml = requestXml;
            string postData = SampleXml.ToString();
            // convert xmlstring to byte using ascii encoding
            byte[] data = encoding.GetBytes(postData);
            // declare httpwebrequet wrt url defined above
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(destinationUrl);
            // set method as post
            webrequest.Method = "POST";
            // set content type
            webrequest.ContentType = "text/xml";
            // set content length
            webrequest.ContentLength = data.Length;
            // get stream data out of webrequest object
            Stream newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            // declare & read response from service
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();

            // set utf8 encoding
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            // read response stream from response object
            StreamReader loResponseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            // read string from stream data
            strResult = loResponseStream.ReadToEnd();
            // close the stream object
            loResponseStream.Close();
            // close the response object
            webresponse.Close();

            return strResult;
        }
    }
}