﻿using AutoMapper;
using DataLayer.DTO.UserDTO;
using DataLayer.Entities.Users;
using DataLayer.ViewModels.Role;
using DataLayer.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Mappers
{
    public class UsersMappingProfile : Profile
    {
        public UsersMappingProfile()
        {
            CreateMap<Users, RegisterViewModel>().ReverseMap();
            CreateMap<Users, RegisterUserAdminViewModel>().ReverseMap();
            CreateMap<Users, UsersManageDTO>().ReverseMap();
            CreateMap<Users, UserIdTitleDTO>().ReverseMap();
            CreateMap<Users, RegisterUserByAdminCustomerViewModel>().ReverseMap();
            CreateMap<Users, AdminRegisterUserViewModel>().ReverseMap();
            CreateMap<ProfileViewModel, Users>().ReverseMap();

            CreateMap<UserRoles, SetUserRoleViewModel>().ReverseMap();
            CreateMap<Roles, RoleUpdateViewModel>().ReverseMap();
        }
    }
}
