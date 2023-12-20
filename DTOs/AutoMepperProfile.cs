

using AutoMapper;
using DataAccesLayer.Models;
using DTO.DTOs.AdsElonDtos;

namespace DTO;

public class AutoMepperProfile:Profile
{
    public AutoMepperProfile()
    {
        CreateMap<AdsElon, AdsElonDto>().ReverseMap();
    }
}
