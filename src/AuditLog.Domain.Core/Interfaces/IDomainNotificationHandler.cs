using AuditLog.Domain.Core.Notifications;
using FluentValidation.Results;
using System.Collections.Generic;

namespace AuditLog.Domain.Core.Interfaces
{
    public interface IDomainNotificationHandler
    {
        bool HasNotifications();
        List<DomainNotification> GetNotifications();
        void SetNotification(DomainNotification notification);
        void SetManyNotifications(ValidationResult validationResult);
    }
}
