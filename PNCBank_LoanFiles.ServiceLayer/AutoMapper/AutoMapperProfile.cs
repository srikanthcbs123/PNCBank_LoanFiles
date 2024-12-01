using AutoMapper;//import the automapper namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNCBank_LoanFiles.BusinessEntities;
using PNCBank_LoanFiles.RepositoryLayer;

namespace PNCBank_LoanFiles.ServiceLayer
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {//        1) creating mapping
            //syntax: mapper.createmap < sourcemodelclass ,destination model class >();
            CreateMap<FileUploadDTO, FileUpload>();//dml performs[inser,update,delete]//from dto to table loki inserting
            CreateMap<FileUpload, FileUploadDTO>();//get methods // from table to picking data

            //CreateMap<PgAccountDTO, PgAccount>();
            //CreateMap<PgAccount, PgAccountDTO>();
        }
    }
}
