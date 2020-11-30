using EmailExtensionLibrary.EmailExtension;
using EmailExtensionLibrary.EmailInterfaces;
using EmailExtensionLibrary.EmailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailExtensionLibrary.EmailConfig
{
    public class Email
    {
        public EmailInfomaction _EmailInfomaction { get; set; }
        public IEmail_Extension_Base _IEB { get; set; }
        public bool Result { get; set; }
        public Email(Func<EmailInfomaction> funcEmailInfomaction)
        {
            _EmailInfomaction = funcEmailInfomaction.Invoke();
            SelectConfig();
        }
        public void SelectConfig()
        {
            switch (_EmailInfomaction.OP)
            {
                case EmailOptionEnum.SMTP:
                    _IEB = new SMTP_Email_Extension_Class(_EmailInfomaction);
                    break;
                default:
                    break;
            }
        }
    }
}
