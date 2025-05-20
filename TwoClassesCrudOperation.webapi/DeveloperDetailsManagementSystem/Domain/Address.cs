namespace DeveloperDetailsManagementSystem.Domain
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }



        //navigate the property for related developer

        public ICollection<Developer> Developers { get; set; }

      

    }
}
