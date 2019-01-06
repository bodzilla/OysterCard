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
            CreateMap<Oyster, OysterDTO>().ReverseMap();
            CreateMap<OysterApplicationVM, Oyster>().ConvertUsing(new OysterApplicationVmConverter());
        }
    }

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
            oyster.Address = oysterApplicationVm.Address;
            oyster.City = oysterApplicationVm.City;
            oyster.PostCode = oysterApplicationVm.PostCode;
            oyster.UserId = oysterApplicationVm.UserId;
            return oyster;
        }
    }
}
