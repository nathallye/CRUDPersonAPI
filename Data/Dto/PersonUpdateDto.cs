namespace Data.Dto
{
    public class PersonUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? CPF { get; set; } 
        public string? Email { get; set; } 
        public string? Address { get; set; }
    }
}
