namespace AutoRentalAPI.DTOs
{
    public class CarDto
    {
        public int CarId { get; set; }
        public string? Model { get; set; }
        public int? YearOfManufacture { get; set; }
        public string? Color { get; set; }
        public string? Condition { get; set; }
        public decimal? PricePerDay { get; set; }
        public bool? Availability { get; set; }
        public int? CarTypeId { get; set; }
    }
}
