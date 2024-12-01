﻿using System;
using System.Collections.Generic;
using System.Data;
using PNCBank_LoanFiles.BusinessEntities;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace PNCBank_LoanFiles.RepositoryLayer.Repository
{
    public class FilesUploadRepository : IFilesUploadRepository
    {
        private readonly IConfiguration _config;
        public FilesUploadRepository(IConfiguration configuration)
        {
            this._config = configuration;
        }

        public async Task<List<FileUpload>> GetFileUploadList()
        {
            List<FileUpload> lstfiles = new List<FileUpload>();
            using (SqlConnection con = new SqlConnection(Convert.ToString(_config.GetSection("ConnectionStrings:hotelmanagementSqlConnectionString").Value)))//here we are getting the conection string
            {
                SqlCommand cmd = new SqlCommand(StoredProcedureStatusMessages.GetFileUpload_SP, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "FileUpload");
                DataTable dt = new DataTable();
                dt = ds.Tables["FileUpload"];
                foreach (DataRow dr in dt.Rows)
                {
                    FileUpload fileUpload = new FileUpload();
                    fileUpload.Id = Convert.ToInt32(dr["Id"]);
                    fileUpload.FileName= Convert.ToString(dr["FileName"]);
                    fileUpload.ModifiedFilename = Convert.ToString(dr["ModifiedFilename"]);
                    fileUpload.FilePath= Convert.ToString(dr["FilePath"]);
                    fileUpload.Createdby = Convert.ToString(dr["Createdby"]);
                    fileUpload.CreatedDatetTime = Convert.ToDateTime(dr["CreatedDateTime"]);
                    lstfiles.Add(fileUpload);
                }
            }
            return lstfiles;
        }

        public async Task<FileUpload> GetFileUploadDetailsById(int Id)
        {
            FileUpload fileUpload = new FileUpload();
            using (SqlConnection con = new SqlConnection(Convert.ToString(_config.GetSection("ConnectionStrings:hotelmanagementSqlConnectionString").Value)))//here we are getting the conection string
            {
                SqlCommand cmd = new SqlCommand(StoredProcedureStatusMessages.GetFileUploadDetailsById_SP, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "FileUpload");
                DataTable dt = new DataTable();
                dt = ds.Tables["FileUpload"];
                foreach (DataRow dr in dt.Rows)
                {
                    fileUpload.ModifiedFilename = Convert.ToString(dr["ModifiedFilename"]);
                }
            }
            return fileUpload;
        }

        public async Task<FileUploadResponse> AddFileUpload(FileUpload fileUpload)
        {
            FileUploadResponse fileUploadResponse = new FileUploadResponse();
            using (SqlConnection con = new SqlConnection(Convert.ToString(_config.GetSection("ConnectionStrings:hotelmanagementSqlConnectionString").Value)))//here we are getting the conection string
            {
                SqlCommand cmd = new SqlCommand(StoredProcedureStatusMessages.AddFileUpload_SP, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FileName",fileUpload.FileName);
                cmd.Parameters.AddWithValue("@FilePath", fileUpload.FilePath);
                cmd.Parameters.AddWithValue("@ModifiedFilename", fileUpload.ModifiedFilename);
                cmd.Parameters.AddWithValue("@Createdby",fileUpload.Createdby);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "FileUpload");
                DataTable dt = new DataTable();
                dt = ds.Tables["FileUpload"];
                foreach ( DataRow dr  in dt.Rows)
                {
                    fileUploadResponse.Error_Code = Convert.ToString(dr["ERROR_CODE"]);
                    fileUploadResponse.Error_Message= Convert.ToString(dr["ERROR_MESSAGE"]);
                }
            }
            return fileUploadResponse;
        }
    }
}
