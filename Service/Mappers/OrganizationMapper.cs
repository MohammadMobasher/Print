using AutoMapper;
using DataLayer.DTO.Organizations;
using DataLayer.Entities;
using DataLayer.ViewModels.Organizations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Mappers
{
    public class OrganizationMapper : Profile
    {
        public OrganizationMapper()
        {
            CreateMap<Organization, OrganizationDTO>();
            CreateMap<Organization, OrganizationIdTitleDTO>();
            CreateMap<OrganizationInsertViewModel, Organization>().ReverseMap();
            CreateMap<OrganizationUpdateViewModel, Organization>().ReverseMap();
        }
    }
}
