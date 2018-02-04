using AuditLog.Domain.Core.Entities;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace AuditLog.Domain.Entities
{
    public class Application : Entity<Application>
    {
        public Application()
        {
            Requests = new List<Request>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Request> Requests { get; set; }

        #region Validations
        public override bool IsValid()
        {
            Validating();
            return ValidationResult.IsValid;
        }

        private void Validating()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Active).NotNull();

            ValidationResult = Validate(this);
        }
        #endregion
    }
}
