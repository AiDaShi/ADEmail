# ADEmail

> Email about ADEmail can only be sent via STMP now, if you want more extensions, please actively create a branch and leave a message in the project comments area.
>Currently, only. Net framework 4.5 is supported+


The usage method is as follows:

> Add package AiDaSi _ Email through the package management tool

```bash
Install-Package AiDaSi_Email -Version 1.0.0
```

> Reference the namespace in the project

```c#
using EmailExtensionLibrary.EmailConfig;
using EmailExtensionLibrary.EmailModel;
using System.Net.Mail;
```

> Fill in related parameters last

```c#
using EmailExtensionLibrary.EmailConfig;
using System.Net.Mail;
```

> Initialize email object

```c#
var email = new Email(() => new EmailInfomaction
{
    Host = "smtp_server",
    Port = 587, //smtp_port
    Username = "your_Email",
    Password = "your_Password",
    IsBodyHtml = false,
    OP = EmailExtensionLibrary.EmailOptionEnum.SMTP // select SMTP Send
});

```

> Demo1 （Simple text request）

```c#
email.Subject("here is Subject");
email.Body("here is body");
bool SendResult = email.Send().Result;
```

> Demo2 （Add some attachments to send）

```c#
email.AddAttachments(filepath).Send();
```

> Demo3 （Download the file from the network and send it to the attachment）

```c#
string pathfile = @"E:\core3.0\SMTPEmail\File\";
email.DownloadFile_AddAttachments("url", FolderPath).Send();
```

> Demo4 （这一切都是扩展方法进行实现的，所以你可以将他们连起来）

```c#
string pathfile = @"E:\core3.0\SMTPEmail\File\";
bool result = new Email(() => new EmailInfomaction
{
    Host = "smtp_server",
    Port = 587, //smtp_port
    Username = "your_Email",
    Password = "your_Password",
    IsBodyHtml = false,
    OP = EmailExtensionLibrary.EmailOptionEnum.SMTP // select SMTP Send
})
.Subject("here is Subject")
.Body("here is body")
.AddAttachments(filepath)
.DownloadFile_AddAttachments("url", FolderPath)
.Send()
.Clear()
.Result
;
```

> Note :that the clear method can clear CC, BCC, attachments, to, etc