using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dog_Ava_project_BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public DogsController(IConfiguration _configuration)
        {
            _configuration = _configuration;
        }

        [HttpGet]
        [Route("/ListAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entity.DogEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Entity.DogEntity))]
        public IActionResult ListAll()
        {
            try
            {
                return Ok(new Entity.DogEntity());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/ListById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entity.DogEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListById(int id)
        {
            try
            {
                return Ok(new Entity.DogEntity());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("/Register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entity.DogEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public int Register(Entity.DogEntity dog)
        {
            return 0;
        }

        [HttpDelete]
        [Route("/Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Delete(Entity.DogEntity dog)
        {

        }

        [HttpPatch]
        [Route("/Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public int Update(Entity.DogEntity dog)
        {
            return 0;
        }
        
        

    }
}
