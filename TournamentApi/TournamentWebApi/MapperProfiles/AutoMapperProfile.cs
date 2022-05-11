using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWebApi.Authentication;
using TournamentWebApi.Models;
using TournamentWebApi.Models.ForUser;
using TournamentWebApi.Models.FromUser;

namespace TournamentWebApi.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TournamentFromUser, Tournament>();
            CreateMap<UserRegistrationData, User>()
                .ForMember(u => u.PasswordHash, opt => opt.MapFrom(ur => AuthHelper.HashPassword(ur.Password)));
            CreateMap<TeamFromUser, Team>();
            CreateMap<Match, MatchForUser>()
                .ForMember(mfu => mfu.FirstTeamName, opt => opt.MapFrom(m => m.FirstTeam.Name))
                .ForMember(mfu => mfu.SecondTeamName, opt => opt.MapFrom(m => m.SecondTeam.Name));
            CreateMap<Tournament, TournamentForUser>();
        }
    }
}
