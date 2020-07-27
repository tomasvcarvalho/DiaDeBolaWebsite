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
            CreateMap<EventDto, Event>();
        }
    }
}