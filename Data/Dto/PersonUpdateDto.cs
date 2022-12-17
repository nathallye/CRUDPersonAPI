namespace Data.Dto
{
    public class PersonUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? CPF { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string? Address { get; set; }
    }
}
