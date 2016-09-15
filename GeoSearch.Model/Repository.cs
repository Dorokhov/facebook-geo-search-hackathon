using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoSearch.Model
{
    public class Repository: IUserRepository
    {
        public IEnumerable<User> Users { get; set; }
    }
}
