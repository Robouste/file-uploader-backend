using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Net;
using System.IO;

namespace file_uploader_backend.Controllers
{
    [Route("api/[controller]")]
    public class FtpController : Controller
    {

        [HttpGet]
        [Route("connect")]
        public string[] Connect()
        {
            StringBuilder result = new StringBuilder();
            FtpWebRequest requestDir = (FtpWebRequest)WebRequest.Create("");
            requestDir.Method = WebRequestMethods.Ftp.ListDirectory;
            requestDir.Credentials = new NetworkCredential("", "");
            FtpWebResponse responseDir = (FtpWebResponse)requestDir.GetResponse();
            var response = responseDir.GetResponseStream();
            StreamReader readerDir = new StreamReader(response);
            string line = readerDir.ReadLine();

            while(line != null)
            {
                result.Append(line);
                result.Append("\n");
                line = readerDir.ReadLine();
            }

            result.Remove(result.ToString().LastIndexOf('\n'), 1);
            responseDir.Close();
            return result.ToString().Split('\n');
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
