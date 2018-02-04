using AuditLog.Domain.Core.Interfaces;
using AuditLog.Domain.Core.Notifications;
using System.Collections.Generic;

namespace AuditLog.Infra.CrossCutting.Bus
{
    public class InMemoryBus : IBus
    {
        #region PARAMETERS
        private readonly IDomainNotificationHandler _dnh;
        #endregion

        #region CONSTRUCTOR
        public InMemoryBus(IDomainNotificationHandler dnh)
        {
            _dnh = dnh;
        }
        #endregion

        public List<DomainNotification> GetInMemoryBusNotifications() => _dnh.GetNotifications();

        public bool HasInMemoryBusNotifications() => _dnh.HasNotifications();

        public void SetNotification(string code, string message) => _dnh.SetNotification(new DomainNotification(code, message));
    }
}
