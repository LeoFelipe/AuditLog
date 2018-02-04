using System;
using System.ComponentModel.DataAnnotations;

namespace AuditLog.Application.ViewModels
{
    public class RequestVM : ViewModel<RequestVM>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ApplicationId { get; set; }
        [Required]
        [MaxLength(10)]
        public string HttpMethod { get; set; }
        [Required]
        public string HttpHeader { get; set; }
        [Required]
        [MaxLength(50)]
        public string Uri { get; set; }
        [Required]
        [MaxLength(50)]
        public string Controller { get; set; }
        [Required]
        [MaxLength(50)]
        public string Action { get; set; }
        [Required]
        [MaxLength(50)]
        public string DataBase { get; set; }
        [Required]
        [MaxLength(50)]
        public string Table { get; set; }
        [Required]
        public string Json { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public LocationVM Location { get; set; }
        public ResponseVM Response { get; set; }
    }
}
