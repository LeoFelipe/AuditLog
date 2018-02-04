using AuditLog.Domain.Core.Interfaces;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace AuditLog.Domain.Core.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler
    {
        #region PARAMETERS
        private List<DomainNotification> _notifications;
        #endregion

        #region CONSTRUCTOR
        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }
        #endregion

        public bool HasNotifications() => _notifications.Any();

        public List<DomainNotification> GetNotifications() => _notifications;

        public void SetNotification(DomainNotification notification) => _notifications.Add(notification);

        public void SetManyNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                _notifications.Add(new DomainNotification(error.PropertyName, error.ErrorMessage));
        }

        public void Dispose() => _notifications = new List<DomainNotification>();
    }
}
