using System;

namespace AuditLog.Domain.Core.Notifications
{
    public class DomainNotification
    {
        #region PARAMETERS
        public Guid DomainNotificationId { get; private set; }
        public string MessageKey { get; private set; }
        public string ErrorMessage { get; private set; }
        #endregion

        #region CONSTRUCTOR
        public DomainNotification(string messageKey, string errorMessage)
        {
            DomainNotificationId = Guid.NewGuid();
            MessageKey = messageKey;
            ErrorMessage = errorMessage;
        }
        #endregion
    }
}
