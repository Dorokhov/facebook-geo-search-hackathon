using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Facebook;
using StackExchange.Redis;

namespace GeoSearch.WebUI.Models
{
    public class GeoRepo
    {
        ConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect("localhost:6379,allowAdmin=True,connectTimeout=60000");
        string Script = "return redis.call('GEORADIUS', @key, @value1, @value2, @value3, @value4)";

        public IEnumerable<UserDatails> GetGeo(double latitude, double longitude, int radius)
        {
            var db = multiplexer.GetDatabase();

            var prepared = LuaScript.Prepare(Script);
            var ids =  (string[])db.ScriptEvaluate(prepared, new { key = (RedisKey)"geosearch", value1 = longitude , value2= latitude , value3 = radius, value4 = "m" });

            var t = new FacebookApiEmulator();
            return t.GetUserDetails(ids);
        }
    }

    public class FacebookApiEmulator
    {
        Dictionary<string, UserDatails> _users = new Dictionary<string, UserDatails>()
        {
            {
                "480339392010395",
                new UserDatails() {FirstName = "Vladimir", LastName = "Dorokhov", Id = "480339392010395"}
            },
            {
                "524508470972271",
                new UserDatails() {FirstName = "Alexander", LastName = "Ryzhov", Id = "524508470972271"}
            },
            {
                "339454829558304",
                new UserDatails() {FirstName = "Max", LastName = "Manziuk", Id = "339454829558304"}
            },
            {
                "1134620166568531",
                new UserDatails() {FirstName = "Vasilii", LastName = "Kravchuk", Id = "1134620166568531"}
            },
        };
        public IEnumerable<UserDatails> GetUserDetails(string[] ids)
        {
            return ids.Select(x => _users[x]);
        }
    }

    public class UserDatails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public string Link { get { return "www.facebook.com/" + Id; } }
    }
}