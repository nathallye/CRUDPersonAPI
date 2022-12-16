using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CRUDPersonAPI.Repository;
using CRUDPersonAPI.Interface;
using CRUDPersonAPI.Models;
using CRUDPersonAPI.Dto;
using System;

namespace CRUDPersonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public object TempData { get; private set; }

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        // GET localhost:7153/api/Person/GetAll
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Person>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            try
            {
                List<PersonDto> list = _personRepository.GetAll();
                if (list == null)
                {
                    return NoContent();
                }

                if (list.Count == 0)
                {
                    throw new Exception("Sem elementos");
                }

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET localhost:7153/api/Person/GetOne?id={}
        [HttpGet]
        [Route("GetOne/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Person))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetOne(int id)
        {
            if (id < 1)
                return NoContent();

            try
            {
                PersonDto person = _personRepository.GetOne(id);

                if (person == null)
                    return NoContent();

                return Ok(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
        
        // POST localhost:7153/api/Person/Post
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(PersonCreateDto newPerson)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(newPerson);

            Console.WriteLine("--------------------------------------------");

            try
            {
                int returnLines = _personRepository.Create(newPerson);

                return Ok(returnLines);

            }
            catch(Exception ex)
            {
                // retorna para tela do formulário
                return BadRequest(ex.Message);
            }
        }

        /*
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
        */
    }
}
