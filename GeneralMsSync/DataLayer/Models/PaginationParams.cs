using CMSShared;

using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class PaginationParams
    {
        [Required]
        public int PageNumber { get; set; }

        [Required]
        public int NumberOfItemsPerPage { get; set; }

        [Required]
        public int OrderColumnIndex { get; set; }

        [Required]
        public bool OrderAscOrDesc { get; set; }
    }
}
