using System.Data;

using Data.Dto;
using Data.Interface;
using Data.Models;
using Data.Repository.Context;

namespace Data.Repository
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


        public Person Create(PersonCreateDto person)
        {
            Person personEntity = new Person()
            {
                Name = person.Name,
                Address = person.Address
            };

            _context.ChangeTracker.Clear();
            _context.Person.Add(personEntity);
            _context.SaveChanges();
            //  return _context.SaveChanges();
            return personEntity;
        }

        public Person Update(PersonUpdateDto person)
        {
            Person personEntityDB =
                (from c in _context.Person
                 where c.Id == person.Id
                 select c)
                 ?.FirstOrDefault()
                 ?? new Person();

            if (personEntityDB == null || DBNull.Value.Equals(personEntityDB.Id) || personEntityDB.Id == 0)
            {
                return null;
            }

            Person personEntity = new Person()
            {
                Name = person.Name,
                Address = person.Address
            };

            _context.ChangeTracker.Clear();
            _context.Person.Add(personEntity);
            _context.SaveChanges();
            return personEntity;
        }

        public int Delete(int id)
        {
            var person = new Person()
            {
                Id = id
            };

            _context.Person.Remove(person);
            return _context.SaveChanges();
        }
    }
}
