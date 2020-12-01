using EmailExtensionLibrary.EmailConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Mail
{
    public static class EmailService
    {
        #region config

        public static Email From(this Email email,string youremail) 
        {
            email._EmailInfomaction.From = youremail;
            return email;
        }
        public static Email Body(this Email email, string Body)
        {
            email._EmailInfomaction.Body = Body;
            return email;
        }
        public static Email Subject(this Email email, string Subject)
        {
            email._EmailInfomaction.Subject = Subject;
            return email;
        }
        public static Email To(this Email email, string[] To)
        {
            foreach (var item in To)
            {
                email._EmailInfomaction.To.Add(item);
            }
            return email;
        }
        public static Email CC(this Email email, string[] CC)
        {
            foreach (var item in CC)
            {
                email._EmailInfomaction.CC.Add(item);
            }
            return email;
        }
        public static Email BCC(this Email email, string[] BCC)
        {
            foreach (var item in BCC)
            {
                email._EmailInfomaction.Bcc.Add(item);
            }
            return email;
        }
        public static Email SMTPServer(this Email email, string Host,int Port)
        {
            email._EmailInfomaction.Host = Host;
            email._EmailInfomaction.Port = Port;
            return email;
        }
        #endregion

        #region Service

        public static Email DownloadFile_AddAttachments(this Email email, string urlFile, string FolderPath)
        {
            email._IEB.DownloadFile_AddAttachments(urlFile, FolderPath);
            return email;
        }

        public static Email AddAttachments(this Email email, string FilePath)
        {
            email._IEB.AddAttachments(FilePath);
            return email;
        }
        public static Email DownloadFile_multiple_attachments(this Email email, string[] urlFiles, string FolderPath)
        {
            email._IEB.DownloadFile_multiple_attachments(urlFiles, FolderPath);
            return email;
        }
        public static Email Send(this Email email)
        {
            email.Result = email._IEB.Send();
            email._IEB.Dispose();
            return email;
        }
        // clear bcc cc to attachments
        public static Email Clear(this Email email)
        {
            email._EmailInfomaction.Attachments.Clear();
            email._EmailInfomaction.CC.Clear();
            email._EmailInfomaction.Bcc.Clear();
            email._EmailInfomaction.To.Clear();
            return email;
        }

        #endregion
    }
}
