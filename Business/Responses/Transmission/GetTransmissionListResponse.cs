using Business.Dtos;
using Business.Dtos.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Transmission;

public class GetTransmissionListResponse
{
    public ICollection<TransmissionListItemDto> Items { get; set; }

    public GetTransmissionListResponse()
    {
        Items = Array.Empty<TransmissionListItemDto>();
    }

    public GetTransmissionListResponse(ICollection<TransmissionListItemDto> items)
    {
        Items = items;
    }
}
