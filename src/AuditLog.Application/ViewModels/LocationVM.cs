using System.ComponentModel.DataAnnotations;

namespace AuditLog.Application.ViewModels
{
    public class LocationVM : ViewModel<LocationVM>
    {
        public int Id { get; set; }
        [Required]
        public int RequestId { get; set; }
        [Required]
        [MaxLength(150)]
        public string UserAgent { get; set; }
        [MaxLength(50)]
        public string IP { get; set; }
        [MaxLength(4)]
        public string CountryCode { get; set; }
        [MaxLength(50)]
        public string CountryName { get; set; }
        [MaxLength(4)]
        public string RegionCode { get; set; }
        [MaxLength(50)]
        public string RegionName { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string TimeZone { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
