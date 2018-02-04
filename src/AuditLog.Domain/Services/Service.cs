using AuditLog.Domain.Core.Entities;
using AuditLog.Domain.Core.Interfaces;
using AuditLog.Domain.Core.Notifications;
using AuditLog.Domain.Interfaces.Repositories;
using AuditLog.Domain.Interfaces.Services;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AuditLog.Domain.Services
{
    public abstract class Service<TEntity> : AbstractValidator<TEntity>, IService<TEntity> where TEntity : Entity<TEntity>
    {
        #region PARAMETERS
        private readonly IRepository<TEntity> _repository;
        private readonly IDomainNotificationHandler _dnh;
        protected readonly IUnitOfWork _uow;
        #endregion

        #region CONSTRUCTOR
        public Service(IRepository<TEntity> repository, IDomainNotificationHandler dnh, IUnitOfWork uow)
        {
            _repository = repository;
            _dnh = dnh;
            _uow = uow;
        }
        #endregion

        #region GET
        public List<TEntity> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public List<TEntity> GetBy(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.GetBy(filter).ToList();
        }

        public TEntity GetById(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                _dnh.SetNotification(new DomainNotification("Key Not Found", $"No records found with ID {id}"));
                return null;
            }
            return _repository.GetById(id);
        }
        #endregion

        #region POST
        public TEntity Insert(TEntity obj)
        {
            if (!obj.IsValid()) _dnh.SetManyNotifications(obj.ValidationResult);
            _repository.Insert(obj);
            _uow.Commit();
            return obj;
        }

        public TEntity Insert(object obj) => Insert((TEntity)obj);
        #endregion

        #region PUT
        public TEntity Update(TEntity obj)
        {
            if (!obj.IsValid()) _dnh.SetManyNotifications(obj.ValidationResult);
            _repository.Update(obj);
            _uow.Commit();
            return obj;
        }

        public TEntity Update(object obj) => Update((TEntity)obj);
        #endregion

        #region DELETE
        public void Delete(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                _dnh.SetNotification(new DomainNotification("Key Not Found", $"No records found with ID {id}"));
                return;
            }
            _repository.Delete(id);
            _uow.Commit();
        }
        #endregion

        #region DISPOSE
        public virtual void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
