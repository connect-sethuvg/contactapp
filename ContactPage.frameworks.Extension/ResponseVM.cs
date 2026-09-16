using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.frameworks.Extension
{
    public class ResponseVM
    {
        public string? Responsecode { get; set; }
        private string? _ResponseMessage;

        public ResponseVM( string successCode)
        {
            Responsecode = successCode;
        }

        public ResponseVM( string successCode, string responseMessage)
        {
            Responsecode = successCode;
            ResponseMessage = responseMessage;
        }

        public string? ResponseMessage
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Responsecode))
                {
                    return string.Empty;
                }
                return string.IsNullOrWhiteSpace(Responsecodes.ResourceManager.GetString(Responsecode))
                    ? _ResponseMessage : Responsecodes.ResourceManager.GetString(Responsecode);
            }

            set => _ResponseMessage = value;
        }

    }
}
