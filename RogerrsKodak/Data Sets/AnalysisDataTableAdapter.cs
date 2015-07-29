using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace RogersKodak.Data_Sets.LocalBDDataSetTableAdapters
{
    public partial class AnalysisDataTableAdapter
    {
        public int InsertNewAnalysisDataRecord(string company,
                                               string jobTitle,
                                               string jobDescription,
                                               string analystName,
                                               string employeeName,
                                               long analysisResultsId)
        {
            int num;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO  AnalysisData
                                OUTPUT  inserted.Id
                                VALUES (
                                         @company          ,
                                         @jobTitle         ,
                                         @jobDescription   ,
                                         @analystName      ,
                                         @employeeName     ,
                                         @dateCreated      ,
                                         @dateEdited       ,
                                         @createdById      ,
                                         @analysisResultsId
                                        );";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@company", SqlDbType.VarChar);
            cmd.Parameters["@company"].Value = company;
            cmd.Parameters.Add("@jobTitle", SqlDbType.VarChar);
            cmd.Parameters["@jobTitle"].Value = jobTitle;
            cmd.Parameters.Add("@jobDescription", SqlDbType.VarChar);
            cmd.Parameters["@jobDescription"].Value = jobDescription;
            cmd.Parameters.Add("@analystName", SqlDbType.VarChar);
            cmd.Parameters["@analystName"].Value = analystName;
            cmd.Parameters.Add("@employeeName", SqlDbType.VarChar);
            cmd.Parameters["@employeeName"].Value = employeeName;
            cmd.Parameters.Add("@dateCreated", SqlDbType.DateTime);
            cmd.Parameters["@dateCreated"].Value = DateTime.Now;
            cmd.Parameters.Add("@dateEdited", SqlDbType.DateTime);
            cmd.Parameters["@dateEdited"].Value = DateTime.Now;
            cmd.Parameters.Add("@createdById", SqlDbType.Int);
            cmd.Parameters["@createdById"].Value = 0;
            cmd.Parameters.Add("@analysisResultsId", SqlDbType.Int);
            cmd.Parameters["@analysisResultsId"].Value = analysisResultsId;
            cmd.Connection = this.Connection;
            this.Connection.Open();
            num = cmd.ExecuteNonQuery();
            this.Connection.Close();
            return num;
        }
    }
}
