using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CRUDPersonAPI.Repository;
using CRUDPersonAPI.Models;

namespace CRUDPersonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Person : ControllerBase
    {
        // GET localhost:7153/api/Person/GetAll
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            try
            {
                return base.Ok(new PersonRepository().GetAll());
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // GET localhost:7153/api/Person/GetOne?id={}
        [HttpGet]
        [Route("GetOne/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                PersonRepository personRepository = new PersonRepository();
                Models.Person person = personRepository.GetOne(id);
                return Ok(person);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST localhost:7153/api/Person/Post
        [HttpPost]
        [Route("Post")]
        public IActionResult Post([FromBody] Models.Person person)
        {
            try
            {
                // Cria o objeto DAL
                PersonRepository personRepository = new PersonRepository();
                // Insere a informação do banco de dados
                personRepository.Create(person);

                // Cria uma propriedade para efetuar a consulta da informação cadastrada
                string location = "https://localhost:7153/api/CRUDPerson";

                return Created(new Uri(location), person);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE localhost:7153/api/Person/Delete?id={}
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                PersonRepository personRepository = new PersonRepository();
                personRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT localhost:7153/api/Person/Put?id={}
        [HttpPut]
        [Route("Put/{id}")]
        public IActionResult Put([FromBody] Models.Person person)
        {
            try
            {
                PersonRepository personRepository = new PersonRepository();
                personRepository.Update(person);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
