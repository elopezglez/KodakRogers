using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RogersKodak.Data_Sets.LocalBDDataSetTableAdapters
{
    public partial class AnalysisResultsTableAdapter
    {
        public int InsertNewAnalysisResultsRecord(string neck,
                                                  string neck0,
                                                  string shoulder1,
                                                  string shoulder2,
                                                  string shoulder0,
                                                  string back,
                                                  string back0,
                                                  string elbow1,
                                                  string elbow2,
                                                  string elbow0,
                                                  string hand1,
                                                  string hand2,
                                                  string hand0,
                                                  string leg1,
                                                  string leg2,
                                                  string leg0,
                                                  string feet1,
                                                  string feet2,
                                                  string feet0
                                                 )
        {
            int id = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO  AnalysisResults (
                                         Neck, 
                                         Neck0, 
                                         Shoulder1,
                                         Shoulder2,
                                         Shoulder0,
                                         Elbow1,
                                         Elbow2,
                                         Elbow0,
                                         Hand1,
                                         Hand2,
                                         Hand0,
                                         Back,
                                         Back0,
                                         Leg1,
                                         Leg2,
                                         Leg0,
                                         Feet1,
                                         Feet2,
                                         Feet0)
                                OUTPUT  inserted.Id
                                VALUES (
                                         @neck, 
                                         @neck0, 
                                         @shoulder1,
                                         @shoulder2,
                                         @shoulder0,
                                         @Elbow1,
                                         @Elbow2,
                                         @Elbow0,                                         
                                         @hand1,
                                         @hand2,
                                         @hand0,
                                         @back,
                                         @back0,
                                         @leg1,
                                         @leg2,
                                         @leg0,
                                         @feet1,
                                         @feet2,
                                         @feet0
                                        );";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@neck", SqlDbType.VarChar);
            cmd.Parameters["@neck"].Value = neck;
            cmd.Parameters.Add("@neck0", SqlDbType.VarChar).Value=neck0;

            cmd.Parameters.Add("@back", SqlDbType.VarChar);
            cmd.Parameters["@back"].Value = back;
            cmd.Parameters.Add("@back0", SqlDbType.VarChar).Value = back0;

            cmd.Parameters.Add("@shoulder1", SqlDbType.VarChar);
            cmd.Parameters["@shoulder1"].Value = shoulder1;
            cmd.Parameters.Add("@shoulder2", SqlDbType.VarChar);
            cmd.Parameters["@shoulder2"].Value = shoulder2;
            cmd.Parameters.Add("@shoulder0", SqlDbType.VarChar).Value=shoulder0;

            cmd.Parameters.Add("@elbow1", SqlDbType.VarChar).Value = elbow1;
            cmd.Parameters.Add("@elbow2", SqlDbType.VarChar).Value = elbow2;
            cmd.Parameters.Add("@elbow0", SqlDbType.VarChar).Value = elbow0;

            cmd.Parameters.Add("@hand1", SqlDbType.VarChar).Value = hand1;
            cmd.Parameters.Add("@hand2", SqlDbType.VarChar).Value = hand2;
            cmd.Parameters.Add("@hand0", SqlDbType.VarChar).Value = hand0;

            cmd.Parameters.Add("@leg1", SqlDbType.VarChar);
            cmd.Parameters["@leg1"].Value = leg1;
            cmd.Parameters.Add("@leg2", SqlDbType.VarChar);
            cmd.Parameters["@leg2"].Value = feet2;
            cmd.Parameters.Add("@leg0", SqlDbType.VarChar).Value = leg0;

            cmd.Parameters.Add("@feet1", SqlDbType.VarChar).Value = feet1;
            cmd.Parameters.Add("@feet2", SqlDbType.VarChar).Value = feet2;
            cmd.Parameters.Add("@feet0", SqlDbType.VarChar).Value = feet0;

            cmd.Connection = this.Connection;
            this.Connection.Open();
            var reader = cmd.ExecuteReader(CommandBehavior.SingleResult);            
            while (reader.Read())
                id = int.Parse(reader[0].ToString());
            this.Connection.Close();
            return id;
        }
    }
}
