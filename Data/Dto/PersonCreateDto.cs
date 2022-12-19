namespace Data.Dto
{
    public class PersonCreateDto
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; }
        public string CPF { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
