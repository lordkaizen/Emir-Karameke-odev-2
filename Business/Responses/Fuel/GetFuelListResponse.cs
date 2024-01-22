using Business.Dtos;
using Business.Dtos.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Fuel
{
    public class GetFuelListResponse
    {
        public ICollection<FuelListItemDto> Items { get; set; }

        public GetFuelListResponse()
        {
            Items = Array.Empty<FuelListItemDto>();
        }

        public GetFuelListResponse(ICollection<FuelListItemDto> items)
        {
            Items = items;
        }
    }
}
