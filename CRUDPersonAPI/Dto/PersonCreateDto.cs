namespace CRUDPersonAPI.Dto
{
    public class PersonCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;

    }
}
