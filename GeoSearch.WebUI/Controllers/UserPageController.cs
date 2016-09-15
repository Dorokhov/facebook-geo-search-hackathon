using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeoSearch.Model;
using GeoSearch.WebUI.Models;

namespace GeoSearch.WebUI.Controllers
{
    public class UserPageController : Controller
    {
        private User user;
        private GeoRepo _geoRepo;
        

        private GeoLocation friends = new GeoLocation()
        {
            //Users = new List<User>()
            //{
            //    new User() {FirstName = "Jon", SecondName = "Snow", Url = "https://www.facebook.com/profile.php?id=100004813681413"},
            //    new User() {FirstName = "Ned", SecondName = "Stark", Url = "https://www.facebook.com/profile.php?id=100004813681413"},
            //    new User() {FirstName = "Arya", SecondName = "Stark", Url = "https://www.facebook.com/profile.php?id=100004813681413"},
            //    new User() {FirstName = "Tirion", SecondName = "Lanister", Url = "https://www.facebook.com/profile.php?id=100004813681413"}
            //}
        };
        [HttpGet]
        public ActionResult FindFriends()
        {
            
            // find logic
            return View(new GeoLocation() {Coordinates = "4"});
        }
        // GET: UserPage
        [HttpPost]
        public ActionResult PostFriends(GeoLocation geoLocation)
        {
            //_geoRepo.GetGeo();

            // find logic
            return View(geoLocation);
        }
    }

    public class GeoLocation
    {
        public string Coordinates { get; set; }
         public IEnumerable<User> Users { get; set; }
    }
}