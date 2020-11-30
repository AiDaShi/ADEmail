using EmailExtensionLibrary.EmailInterfaces;
using SMTPEmail.EmailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmailExtensionLibrary.EmailExtension
{
    public abstract class Email_Extension_Base: IEmail_Extension_Base
    {
        public EmailInfomaction _emailInfomaction { get; set; }

        public Email_Extension_Base(EmailInfomaction emailInfomaction)
        {
            _emailInfomaction = emailInfomaction;
        }

        public abstract bool Send();
        public void DownloadFile_AddAttachments(string urlFile)
        {
            WebClient client = new WebClient();
            string filename = urlFile.Substring((urlFile.LastIndexOf('/')+1));
            client.DownloadFile(urlFile,  + filename);
        }

        public void ClearNetworkFile()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            ClearNetworkFile();
            
        }

        public void AddAttachments(string FilePath)
        {
            throw new NotImplementedException();
        }
    }
}
