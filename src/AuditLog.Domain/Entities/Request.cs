using AuditLog.Domain.Core.Entities;
using FluentValidation;
using System;

namespace AuditLog.Domain.Entities
{
    public class Request : Entity<Request>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ApplicationId { get; set; }
        public string HttpMethod { get; set; }
        public string HttpHeader { get; set; }
        public string Uri { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string DataBase { get; set; }
        public string Table { get; set; }
        public string Json { get; set; }
        public DateTime Date { get; set; }

        public virtual Location Location { get; set; }
        public virtual Response Response { get; set; }
        public virtual Application Application { get; set; }

        #region Validations
        public override bool IsValid()
        {
            Validating();
            return ValidationResult.IsValid;
        }

        private void Validating()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.ApplicationId).NotEmpty();
            RuleFor(x => x.HttpMethod).NotEmpty().MaximumLength(10);
            RuleFor(x => x.HttpHeader).NotEmpty();
            RuleFor(x => x.Uri).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Controller).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Action).NotEmpty().MaximumLength(50);
            RuleFor(x => x.DataBase).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Table).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Json).NotEmpty();
            RuleFor(x => x.Date).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);

            ValidationResult = Validate(this);
        }
        #endregion
    }
}
