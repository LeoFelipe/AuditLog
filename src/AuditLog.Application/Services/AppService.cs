using AuditLog.Application.Interfaces;
using AuditLog.Application.ViewModels;
using AuditLog.Infra.CrossCutting.Bus;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AuditLog.Application.Services
{
    public abstract class AppService<VM> : IAppService<VM>, IDisposable where VM : ViewModel<VM>
    {
        #region PARAMETERS
        protected readonly IBus _bus;
        private readonly Type _entityType;
        private readonly dynamic _serviceBase;
        #endregion

        #region CONSTRUCTOR
        protected AppService(dynamic serviceBase, IBus bus)
        {
            _bus = bus;
            _serviceBase = serviceBase;
            _entityType = GetEntityType(serviceBase.GetType());
        }
        #endregion

        #region GET
        public IEnumerable<VM> GetAll()
        {
            return Mapper.Map<IEnumerable<VM>>(_serviceBase.GetAll());
        }

        public IEnumerable<VM> GetBy(Expression<Func<VM, bool>> filter)
        {
            return Mapper.Map<IEnumerable<VM>>(_serviceBase.GetBy(filter));
        }

        public VM GetById(int id)
        {
            return Mapper.Map<VM>(_serviceBase.GetById(id));
        }
        #endregion

        #region POST
        public VM Insert(VM obj)
        {
            var entity = _serviceBase.Insert(Mapper.Map(obj, typeof(VM), _entityType));
            return Mapper.Map(entity, _entityType, typeof(VM));
        }
        #endregion

        #region PUT
        public VM Update(VM obj)
        {
            var entity = _serviceBase.Update(Mapper.Map(obj, typeof(VM), _entityType));
            return Mapper.Map(entity, _entityType, typeof(VM));
        }
        #endregion

        #region DELETE
        public void Delete(int id)
        {
            _serviceBase.Delete(id);
        }
        #endregion

        #region ENTITY TYPE
        /// <summary>
        /// Obtém o tipo da Entity atravéz do Model
        /// </summary>
        /// <param name="tipo">Tipo do Model</param>
        /// <returns>Tipo da Entity</returns>
        private static Type GetEntityType(Type tipo)
        {
            var sb = new StringBuilder();
            var entityName = typeof(VM).Name.Substring(0, typeof(VM).Name.IndexOf("VM"));
            var ApplicationAssembly = tipo.Assembly.ToString();
            var ApplicationName = ApplicationAssembly.Split(',')[0];

            sb.Append(ApplicationName);
            sb.Append(".Entities.");
            sb.Append(entityName);
            sb.Append(", ");
            sb.Append(ApplicationAssembly);

            return Type.GetType(sb.ToString());
        }
        #endregion

        #region DISPOSE
        public virtual void Dispose()
        {
            _serviceBase.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
