using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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
            this._configuration = _configuration;
        }

        [HttpGet]
        [Route("/ListAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Entity.DogEntity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListAll()
        {
            List<Entity.DogEntity> dogs = new List<Entity.DogEntity>();
            
            try
            {
                string strConnection = _configuration.GetConnectionString("SQL");

                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    connection.Open();

                    StringBuilder strCommand = new StringBuilder();
                    strCommand.AppendLine("SELECT [Id]");
                    strCommand.AppendLine("      ,[DogName]");
                    strCommand.AppendLine("      ,[Breed]");
                    strCommand.AppendLine("      ,[BirthYear]");
                    strCommand.AppendLine("      ,[Pedigree]");
                    strCommand.AppendLine("      ,[Enrollment]");
                    strCommand.AppendLine("      FROM [dbo].[Dogs]");

                    using (SqlCommand cmd = new SqlCommand(strCommand.ToString(), connection))
                    {
                        SqlDataReader dbReader = cmd.ExecuteReader();

                        while (dbReader.Read())
                        {
                            dogs.Add(new Entity.DogEntity()
                            {
                                Id = Convert.ToInt32(dbReader["Id"] ?? "00"),
                                DogName = NullTreatment(dbReader["DogName"]),
                                Breed = NullTreatment(dbReader["Breed"]),
                                BirthYear = Convert.ToDateTime(
                                    dbReader["BirthYear"] == DBNull.Value
                                    ? DateTime.MinValue
                                    : dbReader["BirthYear"]),
                                Pedigree = NullTreatment(dbReader["Pedigree"]),
                                Enrollment = NullTreatment(dbReader["Enrollment"])
                            });
                        }
                    }
                }
                
                return Ok(dogs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/ListAllDapper")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Entity.DogEntity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListAllDapper()
        {
            try
            {
                StringBuilder strCommand = new StringBuilder();
                strCommand.AppendLine("SELECT [Id]");
                strCommand.AppendLine("      ,[DogName]");
                strCommand.AppendLine("      ,[Breed]");
                strCommand.AppendLine("      ,[BirthYear]");
                strCommand.AppendLine("      ,[Pedigree]");
                strCommand.AppendLine("      ,[Enrollment]");
                strCommand.AppendLine("      FROM [dbo].[Dogs]");
                
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SQL"));
                List<Entity.DogEntity> dogs = connection.Query<Entity.DogEntity>(strCommand.ToString()).ToList(); 
                
                return Ok(dogs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string NullTreatment(object valor)
        {
            if (valor == DBNull.Value)
            {
                return string.Empty;
            }
            else
            {
                return Convert.ToString(valor);
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
