﻿namespace Data.Dto
{
    public class PersonDto
    {
        // DTO para mascarar as entidades para não retorná-las diretamente
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; }
        public string CPF { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
