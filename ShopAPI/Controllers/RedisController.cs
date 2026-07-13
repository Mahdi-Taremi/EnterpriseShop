using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using ServiceStack;
using ServiceStack.Redis;
using ServiceStack.Script;
using System.Text;
using RouteAttribute = ServiceStack.RouteAttribute;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        public RedisController(IDistributedCache cache)
        {
            _cache = cache;
        }

        [HttpPost("{Key},{Value}")]
        public ActionResult PostRedis(string Key, string Value)
        {
            using (var connection = new RedisClient())
            {
                 _cache.SetString(Key,Value,
                 new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow =
                         TimeSpan.FromMinutes(3)
                 });
            }
            return Ok();
        }

        [HttpGet("{Key}")]
        public ActionResult GetRedis(string Key)
        {
            var result = _cache.GetString(Key);
            return Ok(result);
        }

        [HttpGet("GetRedisAsync")]
        public async Task<IActionResult> GetRedisAsync(string Key)
        {
            var result =  await _cache.GetStringAsync(Key);
            if (string.IsNullOrEmpty(result))
            {
            await Task.Delay(5000);
            return Ok(result);
            }
            return Ok(result);

        }
    }
}
