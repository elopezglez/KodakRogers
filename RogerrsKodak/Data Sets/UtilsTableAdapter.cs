using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using RogersKodak.Properties;
using RogersKodak.Data_Sets.RKDataSetTableAdapters;

namespace RogersKodak.Data_Sets.LocalBDDataSetTableAdapters
{
    public class UtilsTableAdapter
    {
        public DataTable GetAnalysisSinceDate(DateTime startDate, DateTime endTime)
        {

            try
            {
                DataTable tb = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select * from AnalysisData
                              where datecreated >= @startDate
                              and datecreated < @endDate";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@startDate", SqlDbType.Date).Value = startDate;
                cmd.Parameters.Add("@endDate", SqlDbType.Date).Value = endTime;
                //var cnn = new AnalysisResultsTableAdapter();
                cmd.Connection = new SqlConnection(Settings.Default.LocalBDConnectionString);//cnn.Connection;
                cmd.Connection.Open();
                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                tb.Load(reader);
                return tb;

            }
            catch (Exception e)
            {               
                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }

        }

        /// <summary>
        /// Get the complete information about an analysis 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RKDataSet.AnalysisCompleteDataViewRow GetAnalysisByID(int id)
        {
            var adapter = new AnalysisCompleteDataViewTableAdapter();
            var res = adapter.GetAnalysisById(id);
            return res.FirstOrDefault();
        }
    }

}


