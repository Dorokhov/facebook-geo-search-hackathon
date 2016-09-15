using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoSearch.Model
{
    public class User : IUser
    {
        private string login;
        private string password;
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Url { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        object Image { get; set; }

    }
}
