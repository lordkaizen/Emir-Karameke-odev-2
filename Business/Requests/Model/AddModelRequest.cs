namespace Business.Requests.Model;

public class AddModelRequest
{
    public int BrandId { get; set; }
    public int FuelId { get; set; }
    public int TransmissionId { get; set; }

    public string Name { get; set; }
    public int DailyPrice { get; set; }
 

    public AddModelRequest(int brandId , int fuelId , int transmissionId , string name , int dailyPrice)
    {
        BrandId = brandId;
        FuelId = fuelId;
        TransmissionId = transmissionId;
        Name = name;
        DailyPrice = dailyPrice;

    }


}

