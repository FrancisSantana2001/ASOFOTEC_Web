using ASOFOTEC_Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASOFOTEC_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Random_API : ControllerBase
    {
        private IRandomService _ServiceSingleton;
        private IRandomService _ServiceScoped;
        private IRandomService _ServiceTransient;

        private IRandomService _ServiceSingleton2;
        private IRandomService _ServiceScoped2;
        private IRandomService _ServiceTransient2;

        public Random_API(
            [FromKeyedServices("RandomKeySingleton")] IRandomService RandomServiceSingleton,
            [FromKeyedServices("RandomKeyScoped")] IRandomService RandomServiceScoped,
            [FromKeyedServices("RandomKeyTransient")] IRandomService RandomServiceTransient,
            [FromKeyedServices("RandomKeySingleton")] IRandomService RandomServiceSingleton2,
            [FromKeyedServices("RandomKeyScoped")] IRandomService RandomServiceScoped2,
            [FromKeyedServices("RandomKeyTransient")] IRandomService RandomServiceTransient2
            )
        {
            _ServiceScoped = RandomServiceScoped;
            _ServiceSingleton = RandomServiceSingleton;
            _ServiceTransient = RandomServiceTransient;

            _ServiceScoped2 = RandomServiceScoped2;
            _ServiceSingleton2 = RandomServiceSingleton2;
            _ServiceTransient2 = RandomServiceTransient2;
        }

        [HttpGet]
        public ActionResult<Dictionary<string, int>> Get()
        {
            var result = new Dictionary<string, int>();

            result.Add("Singleton1", _ServiceSingleton.value);
            result.Add("Scoped1", _ServiceScoped.value);
            result.Add("Transient1", _ServiceTransient.value);

            result.Add("Singleton2", _ServiceSingleton2.value);
            result.Add("Scoped2", _ServiceScoped2.value);
            result.Add("Transient2", _ServiceTransient2.value);

            return result;


        }

    }
}
