namespace AutoRentalAPI.DTOs
{
    public class CarTypeDto
    {
        public int CarTypeId { get; set; }
        public string? Category { get; set; }
        public string? BodyType { get; set; }
        public int? SeatingCapacity { get; set; }
        public string? Brand { get; set; }
    }
}
