﻿using AutoMapper;
using Services.DTOs.Recruitment;
using Data.Entities;
using HeRoBackEnd.ViewModels.Recruitment;

namespace HeRoBackEnd.Profiles
{
    public class RecruitmentProfile : Profile
    {
        public RecruitmentProfile()
        {
            CreateMap<CreateRecruitmentDTO, Recruitment>();
            CreateMap<UpdateRecruitmentDTO, Recruitment>();
            CreateMap<RecruitmentCreateViewModel, CreateRecruitmentDTO>();
            CreateMap<RecruitmentEditViewModel, UpdateRecruitmentDTO>();
            CreateMap<RecruitmentChangeStatusViewModel, ChangeRecruitmentStatusDTO>();
            CreateMap<Recruitment, ReadRecruitmentDTO>();
        }
    }
}
