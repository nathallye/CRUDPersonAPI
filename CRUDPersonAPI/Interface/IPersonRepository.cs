using CRUDPersonAPI.Dto;
using CRUDPersonAPI.Models;

namespace CRUDPersonAPI.Interface
{
    public interface IPersonRepository
    {
        List<PersonDto> GetAll();
        
        PersonDto GetOne(int id);

        Person Create(PersonCreateDto person);

        Person Update(PersonUpdateDto person);
        
        int Delete(int Id);
    }
}
