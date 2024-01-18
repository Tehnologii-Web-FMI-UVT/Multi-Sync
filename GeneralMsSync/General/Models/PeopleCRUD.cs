using CMSShared;

using System.ComponentModel.DataAnnotations;

namespace ChurchManagementSystem.Models
{
    public class People
    {
        public long? Id { get; set; } = null;

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public EGender Gender { get; set; }

        public DateTime? DateOfJoin { get; set; } = null;

        public string Address { get; set; } = null;

        public string PhoneNumber { get; set; } = null;

        public string Email { get; set; } = null;
    }
}
