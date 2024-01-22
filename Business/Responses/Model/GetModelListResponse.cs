using Business.Dtos.Brand;
using Business.Dtos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Model
{
    public class GetModelListResponse
    {
        public ICollection<ModelListItemDto> Items { get; set; }

        public GetModelListResponse()
        {
            Items = Array.Empty<ModelListItemDto>();
        }

        public GetModelListResponse(ICollection<ModelListItemDto> items)
        {
            Items = items;
        }
    }
}
