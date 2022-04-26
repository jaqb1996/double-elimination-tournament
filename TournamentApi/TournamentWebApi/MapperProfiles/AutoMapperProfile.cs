using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWebApi.Models;
using TournamentWebApi.Models.FromUser;

namespace TournamentWebApi.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TournamentFromUser, Tournament>();
        }
    }
}
