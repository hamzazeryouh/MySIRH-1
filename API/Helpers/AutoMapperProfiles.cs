﻿using API_MySIRH.DTOs;
using API_MySIRH.DTOs.MDM;
using API_MySIRH.Entities;
using API_MySIRH.Entities.Evaluation;
using API_MySIRH.Entities.MDM;
using AutoMapper;

namespace API_MySIRH.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ToDoItem, ToDoItemDTO>().ReverseMap();
            CreateMap<ToDoListDTO, ToDoList>()
                .ForMember(s => s.ToDoItemList, c => c.MapFrom(m => m.ToDoItemList)).ReverseMap();
            CreateMap<Memo, MemoDTO>().ReverseMap();
            CreateMap<MemoDTO, Memo>().ReverseMap();
            CreateMap<Collaborateur, CollaborateurDTO>().ReverseMap();
            CreateMap<PosteNiveau, PosteNiveauDTO>().ReverseMap();
            CreateMap<Poste, PosteDTO>().ReverseMap();
            CreateMap<Site, SiteDTO>().ReverseMap();
            CreateMap<SkillCenter, SkillCenterDTO>().ReverseMap();
            CreateMap<TypeContrat, TypeContratDTO>().ReverseMap();
            CreateMap<Candidat, CandidatDTO>().ReverseMap();
            CreateMap<Evaluation, EvaluationDTO>().ReverseMap();
            CreateMap<Template, TemplateDTO>().ReverseMap();
            CreateMap< TemplateDTO, Template>().ReverseMap();
            CreateMap<Notes, NoteDTO>().ReverseMap();

            CreateMap<Entretien, EntretienDTO>().ReverseMap();
        }

    }
}
