using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNCBank_LoanFiles.RepositoryLayer
{ 
    public static class StoredProcedureStatusMessages
    {
        public static readonly string AddFileUpload_SP = "Usp_AddFileUpload";

        public static readonly string GetFileUpload_SP = "GetFileUpload";

        public static readonly string GetFileUploadDetailsById_SP = "GetFileUploadDetailsById";

    }
}
