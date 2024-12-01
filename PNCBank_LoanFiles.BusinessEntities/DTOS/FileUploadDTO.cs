﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNCBank_LoanFiles.BusinessEntities
{
    public class FileUploadDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string ModifiedFilename { get; set; }
        public string Createdby { get; set; }
        public DateTime? CreatedDatetTime { get; set; }
    }
}
