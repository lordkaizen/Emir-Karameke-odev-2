﻿using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Brand;
using Business.Requests.Model;
using Business.Responses.Brand;
using Business.Responses.Model;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ModelManager : IModelService
{
    private readonly IModelDal _modelDal;
    private readonly ModelBusinessRules _modelBusinessRules;
    private readonly IMapper _mapper;

    public ModelManager(IModelDal modelDal, ModelBusinessRules modelBusinessRules, IMapper mapper)
    {
        _modelDal = modelDal; //new InMemoryBrandDal(); // Başka katmanların class'ları new'lenmez. Bu yüzden dependency injection kullanıyoruz.
        _modelBusinessRules = modelBusinessRules;
        _mapper = mapper;
    }

    public AddModelResponse Add(AddModelRequest request)
    {
        // İş Kuralları
        _modelBusinessRules.CheckIfModelNameNotExists(request.Name);
        _modelBusinessRules.CheckModelName(request.Name.Length);
        _modelBusinessRules.CheckDailyPrice(request.DailyPrice);
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction
        //Brand brandToAdd = new(request.Name)
        Model modelToAdd = _mapper.Map<Model>(request); // Mapping

        _modelDal.Add(modelToAdd);

        AddModelResponse response = _mapper.Map<AddModelResponse>(modelToAdd);
        return response;
    }

    public GetModelListResponse GetList(GetModelListRequest request)
    {
        // İş Kuralları
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction

        IList<Model> modelList = _modelDal.GetList();

        // brandList.Items diye bir alan yok, bu yüzden mapping konfigurasyonu yapmamız gerekiyor.

        // Brand -> BrandListItemDto
        // IList<Brand> -> GetBrandListResponse

        GetModelListResponse response = _mapper.Map<GetModelListResponse>(modelList); // Mapping
        return response;
    }
}
