using AuditLog.Application.ViewModels;
using AuditLog.Domain.Core.Entities;
using AuditLog.Domain.Entities;
using AutoMapper;

namespace AuditLog.Application.AutoMapper
{
    public class DefaultMappingProfile : Profile
    {
        public DefaultMappingProfile()
        {
            #region DOMAIN <=> VIEWMODEL
            CreateMap(typeof(Entity<>), typeof(ViewModel<>)).ReverseMap();
            CreateMap<Location, LocationVM>().ReverseMap();
            CreateMap<Request, RequestVM>().ReverseMap();
            CreateMap<Response, ResponseVM>().ReverseMap();
            CreateMap<Domain.Entities.Application, ApplicationVM>().ReverseMap();
            #endregion
        }
    }
}
