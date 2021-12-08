using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PracticeASP.Models
{
    public class db
    {
        public SqlConnection con = new SqlConnection("data source=JAYSON\\SQLEXPRESS; database=AOMG; integrated security=SSPI; MultipleActiveResultSets=True");
        public List<Artist> GetArtistDataNormal()
        {

            SqlCommand cmd = new SqlCommand();
            var model = new List<Artist>();

            cmd.Connection = con;
            con.Open();

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectAllArtist";

            SqlDataReader sdr = cmd.ExecuteReader();


            while (sdr.Read())
            {

                var artist = new Artist();
                artist.Artist_id += (int)sdr["Artist_id"];
                artist.Artist_Name += sdr["Artist_Name"];
                artist.Artist_roles += sdr["Artist_role"];
                artist.Artist_contact += (int)sdr["Artist_contact"];


                model.Add(artist);





            }
            con.Close();

            return model;

        }
    }
}