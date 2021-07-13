using AutoMapper;
using smoking_meat_api.DTOs;
using smoking_meat_api.Models;

namespace smoking_meat_api.Profiles
{
    public class InstructionsProfile : Profile
    {
        public InstructionsProfile()
        {
            // Source -> Target
            CreateMap<Instruction, InstructionReadDto>();
            CreateMap<InstructionCreateDto, Instruction>();
            CreateMap<InstructionUpdateDto, Instruction>();
            CreateMap<Instruction, InstructionUpdateDto>();
        }
    }
}