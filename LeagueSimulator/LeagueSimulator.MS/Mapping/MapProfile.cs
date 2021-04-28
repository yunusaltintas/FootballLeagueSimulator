using AutoMapper;
using LeagueSimulator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.DTOs.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<PuanTable, PuanTableDTO>();
            CreateMap<PuanTableDTO, PuanTable>();

            CreateMap<PuanTable, PuanTableWithTeamDTO>();
            CreateMap<PuanTableWithTeamDTO, PuanTable>();

            CreateMap<Team, TeamDTO>();
            CreateMap<TeamDTO, Team>();

            CreateMap<WeeklyResultDTO, WeeklyResult>();
            CreateMap<WeeklyResult, WeeklyResultDTO>();

            CreateMap<WeeklyResultWithTeamDTO, WeeklyResult>();
            CreateMap<WeeklyResult, WeeklyResultWithTeamDTO>();

            CreateMap<PredictionChamp, PredictionChampWithTeamDTO>();
            CreateMap<PredictionChampWithTeamDTO, PredictionChamp>();

        }

    }
}
