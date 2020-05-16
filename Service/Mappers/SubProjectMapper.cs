using AutoMapper;
using DataLayer.DTO.ProjectAndSubProject.SubProjectDTO;
using DataLayer.Entities;
using DataLayer.ViewModels.ProjectAndSubProject.ProjectViewModel;
using DataLayer.ViewModels.ProjectAndSubProject.SubProjectViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Mappers
{
    public class SubProjectMapper : Profile
    {

        public SubProjectMapper()
        {
            CreateMap<SubProject, SubProjectDTO>();
            CreateMap<SubProject, SubProjectCDTO>();
            CreateMap<SubProject, SubProjectADTO>();
            CreateMap<SubProject, SubProjectACDTO>();
            CreateMap<SubProject, SubProjectEmployeeDTO>();
            CreateMap<SubProjectInsertViewModel, SubProject>();
            CreateMap<SubProjectUpdateViewModel, SubProject>();
        }
    }
}
