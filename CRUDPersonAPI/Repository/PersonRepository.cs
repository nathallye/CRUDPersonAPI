using System.Data;

using CRUDPersonAPI.Dto;
using CRUDPersonAPI.Interface;
using CRUDPersonAPI.Models;
using CRUDPersonAPI.Repository.Context;

namespace CRUDPersonAPI.Repository
{
    public class PersonRepository : IPersonRepository
    {
        // Propriedade que terá a instância do DataBaseContext
        private readonly DatabaseContext _context;

        public PersonRepository(DatabaseContext context)
        {
            // Criando um instância da classe de contexto do EntityFramework
            _context = context;
        }


        public List<PersonDto> GetAll()
        {
            return _context.Person.Select(s => new PersonDto()
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address
            }).ToList();
        }

        
        public PersonDto GetOne(int id)
        {
            return (from t in _context.Person
                    where t.Id == id
                    select new PersonDto()
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Address = t.Address

                    })
                    ?.FirstOrDefault()
                    ?? new PersonDto();
        }

        
        public int Create(PersonCreateDto person)
        {
            Person personEntity = new Person()
            {
                Name = person.Name,
                Address = person.Address
            };

            _context.ChangeTracker.Clear();
            _context.Person.Add(personEntity);
            return _context.SaveChanges();
        }

        /*
        public void Update(Person person)
        {
            _context.Person.Update(person);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // Criar um tipo produto apenas com o PersonId
            var person = new Person()
            {
                PersonId = id
            };

            _context.Person.Remove(person);
            _context.SaveChanges();
        }
        */
    }
}
