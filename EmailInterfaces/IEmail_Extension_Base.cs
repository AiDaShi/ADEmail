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
        void DownloadFile_AddAttachments(string urlFile);

        // Add Attachments
        void AddAttachments(string FilePath);

        // Clear File
        void ClearNetworkFile();

        // Dispose Object
        void Dispose();

    }
}
