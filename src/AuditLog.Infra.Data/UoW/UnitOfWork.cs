using AuditLog.Domain.Core.Interfaces;
using AuditLog.Domain.Core.Notifications;
using AuditLog.Infra.Data.Context;

namespace AuditLog.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        #region PARAMETERS
        private readonly AuditLogContext _ctx;
        private readonly IDomainNotificationHandler _notifications;
        #endregion

        #region CONSTRUCTOR
        public UnitOfWork(AuditLogContext ctx, IDomainNotificationHandler notifications)
        {
            _ctx = ctx;
            _notifications = notifications;
        }
        #endregion

        #region COMMIT
        public void Commit()
        {
            if (_notifications.HasNotifications()) return;

            var rowsAffected = _ctx.SaveChanges();
            if (rowsAffected == 0)
                _notifications.SetNotification(new DomainNotification("Erro ao Salvar.", "Não foi possível salvar os dados no banco de Dados."));
        }
        #endregion

        #region DISPOSE
        public void Dispose()
        {
            _ctx.Dispose();
        }
        #endregion
    }
}
