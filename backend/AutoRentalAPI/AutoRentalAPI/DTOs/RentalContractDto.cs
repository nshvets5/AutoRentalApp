namespace AutoRentalAPI.DTOs
{
    public class RentalContractDto
    {
        public int ContractId { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? Status { get; set; }
        public int? ClientId { get; set; }
        public int? CarId { get; set; }
    }
}
