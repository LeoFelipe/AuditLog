using AuditLog.Domain.Core.Notifications;
using System.Collections.Generic;

namespace AuditLog.Infra.CrossCutting.Bus
{
    public interface IBus
    {
        bool HasInMemoryBusNotifications();
        List<DomainNotification> GetInMemoryBusNotifications();
        void SetNotification(string code, string message);
    }
}
