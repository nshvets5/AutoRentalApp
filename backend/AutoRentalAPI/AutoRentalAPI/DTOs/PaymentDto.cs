namespace AutoRentalAPI.DTOs
{
    public class PaymentDto
    {
        public int PaymentId { get; set; }
        public DateOnly? PaymentDate { get; set; }
        public decimal? Amount { get; set; }
        public string? PaymentType { get; set; }
        public int? ContractId { get; set; }
    }
}
