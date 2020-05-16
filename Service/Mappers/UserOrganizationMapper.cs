using AutoMapper;
using DataLayer.DTO.Organizations;
using DataLayer.Entities;
using DataLayer.ViewModels.Organizations;
using DataLayer.ViewModels.UserOrganization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Mappers
{
    public class UserOrganizationMapper : Profile
    {
        public UserOrganizationMapper()
        {
            CreateMap<UserOrganization, UserOrganizationDTO>();
            CreateMap<UserOrganization, OrganizationIdTitleDTO>();
            CreateMap<UserOrganizationInsertViewModel, UserOrganization>().ReverseMap();
            CreateMap<UserOrganizationUpdateViewModel, UserOrganization>().ReverseMap();
        }
    }
}
