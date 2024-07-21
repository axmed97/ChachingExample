using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public ValuesController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        //[HttpGet("[action]")]
        //public void Set()
        //{
        //    _memoryCache.Set("name", "axmed");
        //}

        //[HttpGet("[action]")]
        //public string Get()
        //{
        //    //return _memoryCache.Get<string>("name");
        //    if (_memoryCache.TryGetValue<string>("name", out string value))
        //    {
        //        return value;
        //    }
        //    return string.Empty;
        //}


        [HttpGet("[action]")]
        public void Set()
        {
            _memoryCache.Set<DateTime>("date", DateTime.Now, options: new()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30), // Total
                SlidingExpiration = TimeSpan.FromSeconds(5) // Period
            });
        }

        [HttpGet("[action]")]
        public DateTime Get()
        {
            return _memoryCache.Get<DateTime>("date");
        }
    }
}
