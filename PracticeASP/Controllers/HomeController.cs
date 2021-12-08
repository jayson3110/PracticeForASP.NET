using PracticeASP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeASP.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new db().con;
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult DisplayArtist()
        {
            List<Artist> model = new db().GetArtistDataNormal();
            

            return View(model);
        }




        public ActionResult Edit(int id)
        {
            List<Artist> model = new db().GetArtistDataNormal();
            var getID = model.Single(m => m.Artist_id == id);

            return View(getID);



        
        }

        [HttpPost]
        public ActionResult Edit(Artist artist, int id)
        {
            List<Artist> model = new db().GetArtistDataNormal();
            var getID = model.Single(m => m.Artist_id == id);

            con.Open();
            try
            {

                SqlCommand cm = new SqlCommand("UpdateValue", con);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new SqlParameter("@Artist_Name", artist.Artist_Name));
                cm.Parameters.Add(new SqlParameter("@Artist_role", artist.Artist_roles));
                cm.Parameters.Add(new SqlParameter("@Artist_contact", artist.Artist_contact));
                cm.Parameters.Add(new SqlParameter("@ID", getID.Artist_id));

                cm.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();

            }
            return View();


        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Artist artist)
        {

            con.Open();
            try
            {

                SqlCommand cm = new SqlCommand("InsertValue", con);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new SqlParameter("@Artist_id", artist.Artist_id));
                cm.Parameters.Add(new SqlParameter("@Artist_Name", artist.Artist_Name));
                cm.Parameters.Add(new SqlParameter("@Artist_role", artist.Artist_roles));
                cm.Parameters.Add(new SqlParameter("@Artist_contact", artist.Artist_contact));
         

                cm.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();

            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            List<Artist> model = new db().GetArtistDataNormal();
            var getID = model.Single(m => m.Artist_id == id);
            return View(getID);
        }


        [HttpPost]
        public ActionResult Delete(Artist artist, int id)
        {
            List<Artist> model = new db().GetArtistDataNormal();
            var getID = model.Single(m => m.Artist_id == id);

            con.Open();
            try
            {

                SqlCommand cm = new SqlCommand("DeleteValue", con);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new SqlParameter("@Artist_Id", getID.Artist_id));
             

                cm.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();

            }
            return View();

         
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