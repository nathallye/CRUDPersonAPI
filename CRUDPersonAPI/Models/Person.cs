namespace CRUDPersonAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Person> People { get; set; }
    }
}
