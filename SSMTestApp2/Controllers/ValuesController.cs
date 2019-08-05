using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Amazon.XRay.Recorder.Core;
using System.Threading;

namespace SSMTestApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static IOptions<DemoConfig> config;
        public ValuesController(IServiceProvider serviceProvider)
        {
            config = serviceProvider.GetService<IOptions<DemoConfig>>();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            AWSXRayRecorder.Instance.BeginSubsegment("Subsegment A");
            Thread.Sleep(1000);
            AWSXRayRecorder.Instance.EndSubsegment();
            
            return new string[] { config.Value.TestItem, config.Value.SubConfig.SubItem };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
