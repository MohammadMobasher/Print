using AutoMapper;
using DataLayer.DTO.ProjectAndSubProject.ProjectDTO;
using DataLayer.Entities;
using DataLayer.ViewModels.ProjectAndSubProject.ProjectViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Mappers
{
    public class ProjectMapper : Profile
    {

        public ProjectMapper()
        {
            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectInsertViewModel, Project>();
            CreateMap<ProjectUpdateViewModel, Project>();
        }
    }
}
