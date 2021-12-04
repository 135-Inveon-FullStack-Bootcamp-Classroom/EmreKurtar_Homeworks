using AutoMapper;
using FootballManager.Entities;
using FootballManager.Service.DTOs.Footballer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManager.API.Mapping
{
    public class FootballerProfile : Profile
    {
        public FootballerProfile()
        {
            CreateMap<Footballer, AddFootballerDTO>().ReverseMap();
            CreateMap<Footballer, UpdateFootballerDTO>().ReverseMap();
        }
    }
}
