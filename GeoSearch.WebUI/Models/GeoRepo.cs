using System.Collections;
using System.Collections.Generic;
using StackExchange.Redis;

namespace GeoSearch.WebUI.Models
{
    public class GeoRepo
    {
        ConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect("localhost:6379,allowAdmin=True,connectTimeout=60000");
        string Script = "return redis.call('GEORADIUS', @key, @value1, @value2, @value3, @value4)";
        public IEnumerable<string> GetGeo()
        {
            var db = multiplexer.GetDatabase();

            var prepared = LuaScript.Prepare(Script);
            var ids =  (string[])db.ScriptEvaluate(prepared, new { key = (RedisKey)"geosearch", value1 = 30.511010, value2=  50.474680, value3 = 1, value4 = "m" });

            return ids;
        }
    }
}