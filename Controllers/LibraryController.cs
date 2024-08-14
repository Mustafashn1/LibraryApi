using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace APINEW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        [HttpGet] 
        
        public string SayHelloApi ()
        {
            return "Merhaba APİ";
        }
    }
}
