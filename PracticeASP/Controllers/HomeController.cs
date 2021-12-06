using PracticeASP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeASP.Controllers
{
    public class HomeController : Controller
    {
        public SqlConnection con = new SqlConnection("data source=JAYSON\\SQLEXPRESS; database=AOMG; integrated security=SSPI; MultipleActiveResultSets=True");
        public ActionResult Index()
        {

            List<Artist> model = GetArtistDataNormal();

            return View(model);
        }

        public ActionResult DisplayArtist()
        {

            List<Artist> model = GetArtistDataNormal();

            return View(model);
        }



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
                artist.Artist_Name += sdr["Artist_Name"];
                artist.Artist_roles += sdr["Artist_role"];
                artist.Artist_contact += (int)sdr["Artist_contact"];


                model.Add(artist);





            }
            con.Close();

            return model;

        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}