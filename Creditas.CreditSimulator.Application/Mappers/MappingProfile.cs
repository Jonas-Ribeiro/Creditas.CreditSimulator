using AutoMapper;
using Creditas.CreditSimulator.Domain.Entities;
using Creditas.CreditSimulator.Domain.Requests;
using Creditas.CreditSimulator.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creditas.CreditSimulator.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SimulationRequest, User>();
 
            CreateMap<CreditSimulationResult, SimulationResponse>()
                .ForMember(dest => dest.MonthlyPayment, 
                opt => opt.MapFrom(src => Math.Round(src.MonthlyPayment, 2)))
            .ForMember(dest => dest.TotalAmount,
                opt => opt.MapFrom(src => Math.Round(src.TotalAmount, 2)))
            .ForMember(dest => dest.TotalFee,
                opt => opt.MapFrom(src => Math.Round(src.TotalFee, 2)));
        }
    }
}
