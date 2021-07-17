using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;
using WebApi.Dtos;

namespace WebApi.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<QuestionCreateDto, Question>();
            CreateMap<ChoiceCreateDto, Choice>();
            CreateMap<ChoiceEditDto, Choice>();
        }
    }
}