using AutoMapper;
using DataLayer.DTO;
using DataLayer.Entities;
using DataLayer.ViewModels.Keyword;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Mappers
{
    public class KeywordMappingProfile:Profile
    {
        public KeywordMappingProfile()
        {
            CreateMap<KeywordsUpdateViewModel, Keywords>().ReverseMap();
            CreateMap<KeywordsCreateViewModel, Keywords>().ReverseMap();
            CreateMap<KeywordsFullDTO, Keywords>().ReverseMap();
        }
    }
}
