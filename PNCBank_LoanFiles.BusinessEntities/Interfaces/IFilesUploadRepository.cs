using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNCBank_LoanFiles.BusinessEntities
{
    public interface IFilesUploadRepository
    {
        Task<FileUploadResponse>  AddFileUpload(FileUpload fileUpload);
        Task<List<FileUpload>> GetFileUploadList();
        Task<FileUpload> GetFileUploadDetailsById(int Id);
    }
}
