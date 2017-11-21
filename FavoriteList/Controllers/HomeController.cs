using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FavoriteList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        // /Home/AddToFavList?Name=songname
        public ActionResult AddToFavoriteList(string Name)
        {
            if (Session["FavList"] == null)
            {
                Session.Add("FavList", new List<string>());
            }

            //fetch list from session
            List<string> Favlist = (List<string>)Session["FavList"];
            if (!Favlist.Contains(Name))
            {
                Favlist.Add(Name);
            }
            //Save list back in session
            Session["FavList"] = Favlist;

            ViewBag.FavList = Favlist; //Sending the Favlist to the view

            return View("About");
        }
    }
}