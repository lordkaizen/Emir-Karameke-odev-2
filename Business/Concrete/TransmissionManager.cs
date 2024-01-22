using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Transmission;
using Business.Responses.Transmission;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class TransmissionManager : ITransmissionService
{
    private readonly ITransmissionDal _transmissionDal;
    private readonly TransmissionBusinessRules _transmissionBusinessRules;
    private readonly IMapper _mappert;

    public TransmissionManager(ITransmissionDal transmissionDal, TransmissionBusinessRules transmissionBusinessRules, IMapper mappert)
    {
        _transmissionDal = transmissionDal; 
        _transmissionBusinessRules = transmissionBusinessRules;
        _mappert = mappert;
    }

    public AddTransmissionResponse Add(AddTransmissionRequest request)
    {
        // İş Kuralları
        _transmissionBusinessRules.CheckIfTransmissionNameNotExists(request.Name);

        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction

        Transmission transmissionToAdd = _mappert.Map<Transmission>(request); // Mapping

        _transmissionDal.Add(transmissionToAdd);

        AddTransmissionResponse response = _mappert.Map<AddTransmissionResponse>(transmissionToAdd);
        return response;
    }

    public GetTransmissionListResponse GetList(GetTransmissionListRequest request)
    {
        // İş Kuralları
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction

        IList<Transmission> transmissionList = _transmissionDal.GetList();

        // brandList.Items diye bir alan yok, bu yüzden mapping konfigurasyonu yapmamız gerekiyor.

        // Brand -> BrandListItemDto
        // IList<Brand> -> GetBrandListResponse

        GetTransmissionListResponse response = _mappert.Map<GetTransmissionListResponse>(transmissionList); // Mapping
        return response;
    }
}
