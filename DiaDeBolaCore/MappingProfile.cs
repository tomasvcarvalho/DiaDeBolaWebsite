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
            CreateMap<Event, EventDto>();
            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<Contact, ContactDto>();
            CreateMap<ContactList, ContactListDto>();
            CreateMap<EventStatus, EventStatusDto>();
            CreateMap<Location, LocationDto>();


            CreateMap<EventDto, Event>();
            CreateMap<ApplicationUserDto, ApplicationUser>();
            CreateMap<ContactDto, Contact>();
            CreateMap<ContactListDto, ContactList>();
            CreateMap<EventStatusDto, EventStatus>();
            CreateMap<LocationDto, Location>();
        }
    }
}