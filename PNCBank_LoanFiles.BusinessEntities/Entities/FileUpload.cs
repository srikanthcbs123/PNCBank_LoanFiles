using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PNCBank_LoanFiles.BusinessEntities
{
    public class FileUpload
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string ModifiedFilename { get; set; }
        public string Createdby { get; set; }
        public DateTime? CreatedDatetTime { get; set; }
    }
}
