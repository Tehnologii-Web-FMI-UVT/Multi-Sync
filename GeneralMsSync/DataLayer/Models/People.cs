using CMSShared;

namespace DataLayer.Models
{
    public class People
    {
        public long Id { get; set; }

        public string FirstName { get; set; }    

        public string LastName { get; set; }

        public EGender Gender{ get; set; }

        public DateTime? DateOfJoin { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
