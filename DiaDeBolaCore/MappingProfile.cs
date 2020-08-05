using AutoMapper;
using DiaDeBolaCore.Dtos;
using DiaDeBolaCore.Models;


namespace DiaDeBolaCore
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<Contact, ContactDto>();
            CreateMap<ContactList, ContactListDto>();
            CreateMap<EquipmentColor, EquipmentColorDto>();
            CreateMap<Event, EventDto>();
            CreateMap<EventStatus, EventStatusDto>();
            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerStatus, PlayerStatusDto>();
            CreateMap<Team, TeamDto>();


            CreateMap<ApplicationUserDto, ApplicationUser>();
            CreateMap<ContactDto, Contact>();
            CreateMap<ContactListDto, ContactList>();
            CreateMap<EquipmentColorDto, EquipmentColor>();
            CreateMap<EventDto, Event>();
            CreateMap<EventStatusDto, EventStatus>();
            CreateMap<PlayerDto, Player>();
            CreateMap<PlayerStatusDto, PlayerStatus>();
            CreateMap<TeamDto, Team>();
        }
    }
}