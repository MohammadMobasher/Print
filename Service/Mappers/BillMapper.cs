using AutoMapper;
using DataLayer.DTO.FAQs;
using DataLayer.Entities;
using DataLayer.Entities.FAQs;
using DataLayer.ViewModels;
using DataLayer.ViewModels.FAQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Mappers
{
    public class BillMapper : Profile
    {

        public BillMapper()
        {
            //CreateMap<FAQ, FAQDTO>();
            //CreateMap<FAQ, FAQDTO>().ReverseMap();
            //CreateMap<FAQInsertViewModel, FAQ>().ReverseMap();
            CreateMap<BillInsertUpdateViewModel, Bill>().ReverseMap();
        }

    }
}
