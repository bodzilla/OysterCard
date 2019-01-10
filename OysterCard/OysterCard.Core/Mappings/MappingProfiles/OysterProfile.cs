using System;
using AutoMapper;
using OysterCard.Core.DTO;
using OysterCard.Core.Enums;
using OysterCard.Core.Models;
using OysterCard.Core.ViewModels;

namespace OysterCard.Core.Mappings.MappingProfiles
{
    /// <inheritdoc />
    public sealed class OysterProfile : Profile
    {
        /// <inheritdoc />
        public OysterProfile()
        {
            CreateMap<Oyster, OysterDTO>();
            CreateMap<OysterDTO, Oyster>().ConvertUsing(new OysterDtoConverter());
            CreateMap<OysterApplicationVM, Oyster>().ConvertUsing(new OysterApplicationVmConverter());
        }
    }

    #region OysterDtoConverter

    /// <inheritdoc />
    /// <summary>
    /// Converts an ambingious type of <see cref="T:OysterCard.Core.Models.Oyster" /> to a defined <see cref="T:OysterCard.Core.Enums.OysterType" />.
    /// </summary>
    public class OysterDtoConverter : ITypeConverter<OysterDTO, Oyster>
    {
        public Oyster Convert(OysterDTO source, Oyster destination, ResolutionContext context)
        {
            switch (source.OysterType)
            {
                case OysterType.Junior:
                    var oysterJunior = MapData(new OysterJunior(), source);
                    return oysterJunior;

                case OysterType.Adult:
                    var oysterAdult = MapData(new OysterAdult(), source);
                    return oysterAdult;

                case OysterType.Senior:
                    var oysterSenior = MapData(new OysterSenior(), source);
                    return oysterSenior;

                default:
                    throw new ArgumentOutOfRangeException($"{source.OysterType} is not defined in enum list.");
            }
        }

        private static Oyster MapData(Oyster oyster, OysterDTO oysterDto)
        {
            oyster.Forename = oysterDto.Forename;
            oyster.Surname = oysterDto.Surname;
            oyster.DateOfBirth = oysterDto.DateOfBirth;
            oyster.Address = oysterDto.Address;
            oyster.City = oysterDto.City;
            oyster.PostCode = oysterDto.PostCode;
            oyster.OysterState = oysterDto.OysterState;
            oyster.UserId = oysterDto.UserId;
            return oyster;
        }
    }

    #endregion

    #region OysterApplicationVmConverter

    /// <inheritdoc />
    /// <summary>
    /// Converts an ambingious type of <see cref="T:OysterCard.Core.Models.Oyster" /> to a defined <see cref="T:OysterCard.Core.Enums.OysterType" />.
    /// </summary>
    public class OysterApplicationVmConverter : ITypeConverter<OysterApplicationVM, Oyster>
    {
        public Oyster Convert(OysterApplicationVM source, Oyster destination, ResolutionContext context)
        {
            switch (source.OysterType)
            {
                case OysterType.Junior:
                    var oysterJunior = MapData(new OysterJunior(), source);
                    return oysterJunior;

                case OysterType.Adult:
                    var oysterAdult = MapData(new OysterAdult(), source);
                    return oysterAdult;

                case OysterType.Senior:
                    var oysterSenior = MapData(new OysterSenior(), source);
                    return oysterSenior;

                default:
                    throw new ArgumentOutOfRangeException($"{source.OysterType} is not defined in enum list.");
            }
        }

        private static Oyster MapData(Oyster oyster, OysterApplicationVM oysterApplicationVm)
        {
            oyster.Forename = oysterApplicationVm.Forename;
            oyster.Surname = oysterApplicationVm.Surname;
            oyster.DateOfBirth = oysterApplicationVm.DateOfBirth;
            oyster.Address = oysterApplicationVm.Address;
            oyster.City = oysterApplicationVm.City;
            oyster.PostCode = oysterApplicationVm.PostCode;
            oyster.UserId = oysterApplicationVm.UserId;
            return oyster;
        }

        #endregion
    }
}
