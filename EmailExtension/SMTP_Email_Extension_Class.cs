using EmailExtensionLibrary.EmailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailExtensionLibrary.EmailExtension
{
    public class SMTP_Email_Extension_Class: Email_Extension_Base
    {
        SmtpClient smtp = null;
        public SMTP_Email_Extension_Class(EmailInfomaction emailInfomaction)
            : base(emailInfomaction)
        {
            smtp = new SmtpClient(emailInfomaction.Host, emailInfomaction.Port);
            smtp.Credentials = new NetworkCredential(emailInfomaction.Username, emailInfomaction.Password);
        }

        public override bool Send()
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(_emailInfomaction.From);
                    foreach (var item in _emailInfomaction.To)
                    {
                        mail.To.Add(item);
                    }
                    foreach (var item in _emailInfomaction.Bcc)
                    {
                        mail.Bcc.Add(item);
                    }
                    foreach (var item in _emailInfomaction.CC)
                    {
                        mail.CC.Add(item);
                    }
                    foreach (var item in _emailInfomaction.Attachments)
                    {
                        mail.Attachments.Add(new Attachment(item));
                    }
                    mail.Subject = _emailInfomaction.Subject;
                    mail.Body = _emailInfomaction.Body;
                    mail.IsBodyHtml = _emailInfomaction.IsBodyHtml;
                    {
                        smtp.EnableSsl = true;
                        try
                        {
                            smtp.Send(mail);
                        }
                        catch (SmtpException ex)
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
