using AuditLog.Domain.Core.Entities;
using FluentValidation;

namespace AuditLog.Domain.Entities
{
    public class Response : Entity<Response>
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int HttpCode { get; set; }
        public string HttpDescription { get; set; }
        public string HttpHeader { get; set; }
        public string JsonResponseClient { get; set; }
        public string JsonResponseOriginal { get; set; }
        public bool FlagError { get; set; }

        public virtual Request Request { get; set; }

        #region Validations
        public override bool IsValid()
        {
            Validating();
            return ValidationResult.IsValid;
        }

        private void Validating()
        {
            RuleFor(x => x.RequestId).NotEmpty();
            RuleFor(x => x.HttpCode).NotEmpty();
            RuleFor(x => x.HttpDescription).NotEmpty().MaximumLength(20);
            RuleFor(x => x.HttpHeader).NotEmpty();
            RuleFor(x => x.JsonResponseClient).NotEmpty();
            RuleFor(x => x.JsonResponseOriginal).NotEmpty();
            RuleFor(x => x.FlagError).NotNull();

            ValidationResult = Validate(this);
        }
        #endregion
    }
}
