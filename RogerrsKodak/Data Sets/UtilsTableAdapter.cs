using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RogersKodak.Data_Sets.LocalBDDataSetTableAdapters
{
    public class UtilsTableAdapter
    {
        public DataTable GetAnalysisDinceDate(DateTime date)
        {
            DataTable tb = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"select * from AnalysisData";
//                                where datecreated > @startDate";
            //cmd.CommandType = CommandType.Text;
            //cmd.Parameters.Add("@startDate", SqlDbType.VarChar).Value = date.AddDays(-30);
            var cnn = new AnalysisResultsTableAdapter();
            cmd.Connection = cnn.Connection;
            cmd.Connection.Open();
            var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            tb.Load(reader);
            //cmd.Connection.Close();
            return tb;
        }
    }

}


