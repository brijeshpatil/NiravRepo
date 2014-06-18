using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace WebApplication1
{

    public class DataSErvice
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;

        public DataTable GetALlCountry()
        {
            cmd = new SqlCommand("GetAllCountry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void DeleteCountry(int CountryID)
        {
            cmd = new SqlCommand("DeleteCountry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CID", CountryID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void InsertNewCountry(PSErvice P)
        {
            cmd = new SqlCommand("InsertNewCountry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cname", P.CountryNAme);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateCountry(PSErvice P)
        {
            cmd = new SqlCommand("UpdateCountry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CID", P.CountryID);
            cmd.Parameters.AddWithValue("@Cname", P.CountryNAme);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}