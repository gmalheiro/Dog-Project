using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dog_Ava_project_BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {

        [HttpGet]
        public void ListAll()
        {

        }

        [HttpPost]
        public int Register()
        {
            return 0;
        }



    }   
}
