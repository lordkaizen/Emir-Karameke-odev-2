namespace Business.Dtos.Model;

public class ModelListItemDto
{
    public int BrandId { get; set; }
    public string FuelId { get; set; }
    public string TransmissionId { get; set; }

    public string Name { get; set; }
    public int DailyPrice { get; set; }
}
