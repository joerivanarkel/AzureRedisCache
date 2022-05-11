namespace Domain.Persons
{
    public class Person: Common.IEntity
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get ;set; }
    }
}