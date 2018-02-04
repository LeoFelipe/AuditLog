using AuditLog.Domain.Core.Entities;
using FluentValidation;
using FluentValidation.Validators;

namespace AuditLog.Domain.Entities
{
    public class Location : Entity<Location>
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string UserAgent { get; set; }
        public string IP { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string TimeZone { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

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
            RuleFor(x => x.UserAgent).NotEmpty().MaximumLength(150);
            RuleFor(x => x.IP).NotEmpty().MaximumLength(50);
            RuleFor(x => x.CountryCode).MaximumLength(4);
            RuleFor(x => x.CountryName).MaximumLength(50);
            RuleFor(x => x.RegionCode).MaximumLength(4);
            RuleFor(x => x.RegionName).MaximumLength(50);
            RuleFor(x => x.City).MaximumLength(50);
            RuleFor(x => x.TimeZone).MaximumLength(50);
            RuleFor(x => x.Latitude).SetValidator(new ScalePrecisionValidator(10, 8));
            RuleFor(x => x.Longitude).SetValidator(new ScalePrecisionValidator(11, 8));

            ValidationResult = Validate(this);
        }
        #endregion
    }
}
