using EmailExtensionLibrary.EmailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailExtensionLibrary.EmailInterfaces
{
    public interface IEmail_Extension_Base
    {
        EmailInfomaction _emailInfomaction { get; set; }
        // Send Email
        bool Send();

        // Download File
        void DownloadFile_AddAttachments(string urlFile,string FolderPath);

        // Download multiple attachments file
        void DownloadFile_multiple_attachments(string[] urlFiles, string FolderPath);

        // Add Attachments
        void AddAttachments(string FilePath);

        // Clear File
        void ClearNetworkFile();

        // Dispose Object
        void Dispose();

    }
}
