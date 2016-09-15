using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using GeoSearch.Model;
using GeoSearch.WebUI.Models;

namespace GeoSearch.WebUI.Controllers
{
    public class UserPageController : Controller
    {
        private User user;
        private GeoRepo _geoRepo = new GeoRepo();
        

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
            return View(new GeoLocation() { Coordinates = "50.474680 30.511010" , Radius = "1"});
        }
        // GET: UserPage
        [HttpPost]
        public ActionResult FindFriends(GeoLocation geoLocation)
        {
            var coord = geoLocation.Coordinates.Split(new string[] { " " }, StringSplitOptions.None);
            double[] dcoords = new[] {Double.Parse(coord[0], CultureInfo.InvariantCulture), double.Parse(coord[1], CultureInfo.InvariantCulture) };
            int radius = Int32.Parse(geoLocation.Radius);

            var users = _geoRepo.GetGeo(dcoords[0], dcoords[1], radius).ToList();

            geoLocation.Users = users;
                // find logic
            return View(geoLocation);
        }
    }

    public class GeoLocation
    {
        public string Coordinates { get; set; }
        public string Radius { get; set; }
         public IEnumerable<UserDatails> Users { get; set; }
    }
}