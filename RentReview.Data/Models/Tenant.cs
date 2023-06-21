namespace RentReview.Data.Models
{
    public class Tenant
    {
        public string Id = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
