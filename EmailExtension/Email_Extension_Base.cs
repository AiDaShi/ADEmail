using EmailExtensionLibrary.EmailInterfaces;
using EmailExtensionLibrary.EmailModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmailExtensionLibrary.EmailExtension
{
    public abstract class Email_Extension_Base: IEmail_Extension_Base
    {
        public EmailInfomaction _emailInfomaction { get; set; }
        public string _FolderPath { get; set; }
        public string TempPath { get; set; }

        public Email_Extension_Base(EmailInfomaction emailInfomaction)
        {
            _emailInfomaction = emailInfomaction;
        }

        public abstract bool Send();
        public void DownloadFile_AddAttachments(string urlFile,string FolderPath)
        {
            if (string.IsNullOrEmpty(urlFile))
            {
                throw new Exception("The URL and Folder can't null ");
            }
            // can not null
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            WebClient client = new WebClient();
            string filename = urlFile.Substring((urlFile.LastIndexOf('/')+1));
            if (string.IsNullOrEmpty(TempPath))
            {
                TempPath = Guid.NewGuid().ToString();
                _FolderPath = Path.Combine(FolderPath, TempPath);
            }
            Directory.CreateDirectory(_FolderPath);
            string fullpath = Path.Combine(_FolderPath,filename);
            client.DownloadFile(urlFile, fullpath);
            client.Dispose();
            AddAttachments(fullpath);
        }


        public void ClearNetworkFile()
        {
            string path = _FolderPath;
            //if (Directory.Exists(path))
            //{
            //    foreach (string d in Directory.GetFileSystemEntries(path))
            //    {
            //        if (File.Exists(d))
            //        {
            //            File.Delete(d);
            //        }
            //    }
            //}
            Directory.Delete(path, true);
        }

        public void Dispose()
        {
            ClearNetworkFile();
            TempPath = "";
        }

        public void AddAttachments(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                _emailInfomaction.Attachments.Add(FilePath);
            }
        }
    }
}
