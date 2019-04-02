using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSuppliersDto, Supplier>();

            this.CreateMap<ImportPartsDto, Part>();

            this.CreateMap<ImportCarsDto, Car>();

            this.CreateMap<ImportCustomerDto, Customer>();

            this.CreateMap<ImportSalesDto, Sale>();

            this.CreateMap<Sale, FullSaleDto>()
                .ForMember(x => x.CustomerName, y => y.MapFrom(obj => obj.Customer.Name))
                .ForMember(x => x.Car, y => y.MapFrom(obj => obj.Car))
                .ForMember(x => x.Price, y => y.MapFrom(obj => obj.Car.PartCars.Sum(z => z.Part.Price)))
                .ForMember(x => x.PriceWithDiscount,
                    y => y.MapFrom(
                        obj => $"{obj.Car.PartCars.Sum(z => z.Part.Price) - (obj.Car.PartCars.Sum(w => w.Part.Price) * (obj.Discount / 100))}".TrimEnd('0')));

            this.CreateMap<Car, CarDto>()
                .ForMember(x => x.Make, y => y.MapFrom(obj => obj.Make))
                .ForMember(x => x.Model, y => y.MapFrom(obj => obj.Model))
                .ForMember(x => x.TravelledDistance, y => y.MapFrom(obj => obj.TravelledDistance));
        }
    }
}
