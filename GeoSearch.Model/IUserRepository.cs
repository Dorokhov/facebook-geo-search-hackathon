using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoSearch.Model
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; set; } 
    }
}
