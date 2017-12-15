using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceRole.Controllers
{
    public class PackageController : ApiController
    {
        [HttpGet]
        [Route("api/package/{packageId}")]
        public IHttpActionResult GetPackageById(int packageId)
        {
            
            return Ok(packageId);
        }
    }
}
