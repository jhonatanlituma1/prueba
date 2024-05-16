namespace WebApiPerson.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string AccountNumber { get; set; }
        public double Balance { get; set; } = 0;
        public DateOnly BirthDay { get; set; }
        public string? Address { get; set; } 
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? CustomerType { get; set; }
        public string? CivilStatus { get; set;}
        public string? IdentificationNumber { get; set;}
        public string? Profession { get; set; }
        public string? Gender { get; set; }
        public string? Nationality { get; set;}
    }
}
