﻿using AutoMapper;
using Data.Mongo.Collections;
using Identity.Models;
using Models.DbEntities.Customer;
using Models.DbEntities.RouteBus;
using Models.DTOs.Account;
using Models.DTOs.Customer;
using Models.DTOs.Log;
using Models.DTOs.Menu;
using Models.DTOs.Organization;
using Models.DTOs.Station;

namespace WebApi.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApplicationUser, UserDto>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.UserName))
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, o => o.MapFrom(s => s.LastName))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email));

            CreateMap<LoginLog, LogDto>()
               .ForMember(d => d.UserEmail, o => o.MapFrom(s => s.UserEmail))
               .ForMember(d => d.LoginTime, o => o.MapFrom(s => s.LoginTime));

            CreateMap<ApplicationMenu, MenuDto>();
            CreateMap<MenuDtoCreate, ApplicationMenu>();
            CreateMap<MenuDtoUpdate, ApplicationMenu>();
            CreateMap<MenuRoleDto, ApplicationMenuRole>();
            // .ForMember(d=>d.MenuRoles)
            //Org Mapper
            CreateMap<Organization, OrganizationDto>();
            CreateMap<OrganizationDto, Organization>();
            CreateMap<OrganizationCreateDto, Organization>();

            //Vehical
            CreateMap<Vehicle, VehicalDto>();
            CreateMap<VehicalDto, Vehicle>();
            CreateMap<VehicalUpdateDto, Vehicle>();
            CreateMap<VehicalCreateDto, Vehicle>();

            //CustomerType
            //CustomerType, CustomerDto, CustomerDtoCreate, CustomerDtoUpdate

            CreateMap<CustomerType, CustomerDto>();
            CreateMap<CustomerDto, CustomerType>();
            CreateMap<CustomerDtoUpdate, CustomerType>();
            CreateMap<CustomerDtoCreate, CustomerType>();

            //CustomerType
            //CustomerType, CustomerDto, CustomerDtoCreate, CustomerDtoUpdate

            CreateMap<Station, StationDto>();
            CreateMap<StationDto, Station>();
            CreateMap<StationDtoUpdate, Station>();
            CreateMap<StationDtoCreate, Station>();
        }
    }
}
