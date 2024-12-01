using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNCBank_LoanFiles.BusinessEntities
{
    public class BaseResponse
    {
        public string Error_Message { get; set; }
        public string Error_Code { get; set; }
    }
}
