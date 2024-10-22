namespace AutoRentalAPI.DTOs
{
    public class AdditionalServiceDto
    {
        public int ServiceId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal PricePerDay { get; set; }
    }
}
