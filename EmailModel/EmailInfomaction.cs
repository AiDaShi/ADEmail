﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailExtensionLibrary.EmailModel
{
    public class EmailInfomaction
    {
        public EmailInfomaction()
        {
            To = new MailAddressCollection();
            CC = new MailAddressCollection();
            Bcc = new MailAddressCollection();
            Attachments =new List<string>();
        }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool IsBodyHtml { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public MailAddressCollection To { get; }
        public MailAddressCollection CC { get; }
        public MailAddressCollection Bcc { get; }
        public List<string> Attachments { get; set; }
        public EmailOptionEnum OP { get; set; }

    }
}
