using System.ComponentModel.DataAnnotations;

namespace AuditLog.Application.ViewModels
{
    public class ResponseVM : ViewModel<ResponseVM>
    {
        public int Id { get; set; }
        [Required]
        public int RequestId { get; set; }
        [Required]
        public int HttpCode { get; set; }
        [Required]
        [MaxLength(20)]
        public string HttpDescription { get; set; }
        [Required]
        public string HttpHeader { get; set; }
        [Required]
        public string JsonResponseClient { get; set; }
        [Required]
        public string JsonResponseOriginal { get; set; }
        public bool FlagError { get; set; }
    }
}
