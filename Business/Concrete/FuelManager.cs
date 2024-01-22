using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using DataAccess.Abstract;
using Entities.Concrete;
namespace Business.Concrete
{
    public class FuelManager : IFuelService
    {
        private readonly IFuelDal _fuelDal;
        private readonly FuelBusinessRules _fuelBusinessRules;
        private readonly IMapper _mapper;
        public FuelManager(IFuelDal fuelDal, FuelBusinessRules fuelBusinessRules, IMapper mapper)
        {
            _fuelDal = fuelDal;
            _fuelBusinessRules = fuelBusinessRules;
            _mapper = mapper;
        }

        public AddFuelResponse Add(AddFuelRequest request)
        {
            // İş Kuralları
            _fuelBusinessRules.CheckIfBrandNameNotExists(request.Name);

            // Validation
            // Yetki kontrolü
            // Cache
            // Transaction
            Fuel fuelToAdd = _mapper.Map<Fuel>(request);

            _fuelDal.Add(fuelToAdd);

            AddFuelResponse response = _mapper.Map<AddFuelResponse>(fuelToAdd);
            return response;
        }

        public GetFuelListResponse GetList(GetFuelListRequest request)
        {
            // İş Kuralları
            // Validation
            // Yetki kontrolü
            // Cache
            // Transaction

            IList<Fuel> fuelList = _fuelDal.GetList();

            // brandList.Items diye bir alan yok, bu yüzden mapping konfigurasyonu yapmamız gerekiyor.

            // Brand -> BrandListItemDto
            // IList<Brand> -> GetBrandListResponse

            GetFuelListResponse response = _mapper.Map<GetFuelListResponse>(fuelList); // Mapping
            return response;
        }
    }
}
