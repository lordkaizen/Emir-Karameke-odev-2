using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;

namespace Business.BusinessRules;

public class ModelBusinessRules
{
    private readonly IModelDal _modelDal;

    public ModelBusinessRules(IModelDal modelDal)
    {
        _modelDal = modelDal;
    }

    public void CheckIfModelNameNotExists(string modelName)
    {
        bool isExists = _modelDal.GetList().Any(b => b.Name == modelName);
        if (isExists)
        {
            throw new BusinessException("Model already exists.");
        }
    }
    public void CheckModelName(int nameLenght)
    {
        bool isSmaller = nameLenght < 2;
        if (isSmaller)
        {
            throw new BusinessException("Model name can not set smaller than 2.");
        }
    }
    public void CheckDailyPrice(int dailyPrice)
    {
        bool isEqual = dailyPrice == 0;
        if (isEqual)
        {
            throw new BusinessException("Model price can not set smaller than 0.");
        }
    }
}
