using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Entity.DogEntity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListAll()
        {
            try
            {
                string strConnection = _configuration.GetConnectionString("Sql");

                SqlConnection connection = new SqlConnection();
                connection.Open();

                StringBuilder strComando = new StringBuilder();
                strComando.AppendLine("SELECT [Id]");
                strComando.AppendLine("      ,[DogName]");
                strComando.AppendLine("      ,[Breed]");
                strComando.AppendLine("      ,[BirthYear]");
                strComando.AppendLine("      ,[Pedgiree]");
                strComando.AppendLine("      ,[Enrollment]");
                strComando.AppendLine("      ,FROM [dbo].[Dogs]");
                
                SqlCommand cmd = new SqlCommand(strComando.ToString());

                return Ok(new List<Entity.DogEntity>());
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
