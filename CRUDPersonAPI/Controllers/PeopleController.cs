using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CRUDPersonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly Data.Interface.IPersonRepository _personRepository;

        public PeopleController(Data.Interface.IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        // GET localhost:7153/api/People/GetAll
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Data.Models.Person>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            try
            {
                List<Data.Dto.PersonDto> list = _personRepository.GetAll();
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

        // GET localhost:7153/api/People/GetOne?id={}
        [HttpGet]
        [Route("GetOne/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Data.Models.Person))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetOne(int id)
        {
            if (id < 1)
                return NoContent();

            try
            {
                Data.Dto.PersonDto person = _personRepository.GetOne(id);

                if (person == null)
                    return NoContent();

                return Ok(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST localhost:7153/api/People/Post
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Data.Models.Person))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(Data.Dto.PersonCreateDto newPerson)
        {
            try
            {
                // int returnLines = _personRepository.Create(newPerson);

                Data.Models.Person personEntity = _personRepository.Create(newPerson);

                return Ok(personEntity);

            }
            catch(Exception ex)
            {
                // retorna para tela do formulário
                return BadRequest(ex.Message);
            }
        }

        // Patch localhost:7153/api/People/Update?id={}
        [HttpPut]
        [Route("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Data.Models.Person))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(Data.Dto.PersonUpdateDto person)
        {
            try
            {
                // int returnLines = _personRepository.Create(newPerson);

                Data.Models.Person personEntity = _personRepository.Update(person);

                return Ok(personEntity);

            }
            catch (Exception ex)
            {
                // retorna para tela do formulário
                return BadRequest(ex.Message);
            }
        }

        // DELETE localhost:7153/api/People/Delete?id={}
        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            try
            {
                int returnLines = _personRepository.Delete(id);
                return Ok(returnLines);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
