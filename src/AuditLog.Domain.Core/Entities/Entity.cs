using FluentValidation;
using FluentValidation.Results;

namespace AuditLog.Domain.Core.Entities
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        #region CONSTRUCTOR
        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }
        #endregion

        public abstract bool IsValid();

        public ValidationResult ValidationResult { get; protected set; }
    }
}
