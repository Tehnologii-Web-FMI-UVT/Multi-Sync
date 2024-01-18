using CMSShared;

namespace DataLayer.Models
{
    public class PeopleFilterParams : PaginationParams
    {
        public string Name { get; set; } = null;

        public DateTime? DateOfJoin { get; set; } = null;

        public string Address { get; set; } = null;

        public string PhoneNumber { get; set; } = null;

        public string Email { get; set; } = null;
    }
}
