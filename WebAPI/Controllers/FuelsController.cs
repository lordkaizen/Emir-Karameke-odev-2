using Business;
using Business.Abstract;
using Business.Requests.Brand;
using Business.Requests.Fuel;
using Business.Responses.Brand;
using Business.Responses.Fuel;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/fuel/[controller]")]
[ApiController]
public class FuelController : ControllerBase
{
    private readonly IFuelService _fuelService; // Field

    public FuelController(IFuelService fuelService)
    {
        // Her HTTP Request için yeni bir Controller nesnesi oluşturulur.
        _fuelService = fuelService;
        // Daha sonra IoC Container yapımızı kurduğumuz Dependency Injection ile daha verimli hale getiricez.
    }

    //[HttpGet]
    //public ActionResult<string> //IActionResult
    //GetList()
    //{
    //    return Ok("BrandsController");
    //}

    [HttpGet] // GET http://localhost:5245/api/brands
    public GetFuelListResponse GetList([FromQuery] GetFuelListRequest request) // Referans tipleri varsayılan olarak request body'den alır.
    {
        GetFuelListResponse response = _fuelService.GetList(request);
        return response; // JSON
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/brands/add
    [HttpPost] // POST http://localhost:5245/api/brands
    public ActionResult<AddFuelResponse> Add(AddFuelRequest request)
    {
        try
        {
            AddFuelResponse response = _fuelService.Add(request);

            //return response; // 200 OK
            return CreatedAtAction(nameof(GetList), response); // 201 Created
        }
        catch (Core.CrossCuttingConcerns.Exceptions.BusinessException exception)
        {
            return BadRequest(
                new Core.CrossCuttingConcerns.Exceptions.BusinessProblemDetails()
                {
                    Title = "Business Exception",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = exception.Message,
                    Instance = HttpContext.Request.Path
                }
            );
            // 400 Bad Request
        }
    }
}
