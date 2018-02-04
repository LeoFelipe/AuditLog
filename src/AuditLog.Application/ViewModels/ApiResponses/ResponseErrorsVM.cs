
namespace AuditLog.Application.ViewModels.ApiResponses
{
    public class ResponseErrorsVM
    {
        public bool Success { get; set; }
        public dynamic Info { get; set; }
        public dynamic Errors { get; set; }
    }
}
