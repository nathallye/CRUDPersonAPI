using CRUDPersonAPI.Dto;

namespace CRUDPersonAPI.Interface
{
    public interface IPersonRepository
    {
        List<PersonDto> GetAll();
        
        PersonDto GetOne(int id);

        int Create(PersonCreateDto person);
    }
}
