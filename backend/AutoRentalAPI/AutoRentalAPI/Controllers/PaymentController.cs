using AutoRentalAPI.DTOs;
using AutoRentalAPI.Interfaces;
using AutoRentalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentsRepository;

        public PaymentController(IPaymentRepository paymentsRepository)
        {
            _paymentsRepository = paymentsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetPayments()
        {
            var payments = await _paymentsRepository.GetAllPaymentsAsync();
            var paymentDto = payments.Select(payment => new PaymentDto
            {
                PaymentId = payment.PaymentId,
                PaymentDate = payment.PaymentDate,
                Amount = payment.Amount,
                PaymentType = payment.PaymentType,
                ContractId = payment.ContractId
            });
            return Ok(paymentDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDto>> GetPayment(int id)
        {
            var payment = await _paymentsRepository.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            var paymentDto = new PaymentDto
            {
                PaymentId = payment.PaymentId,
                PaymentDate = payment.PaymentDate,
                Amount = payment.Amount,
                PaymentType = payment.PaymentType,
                ContractId = payment.ContractId
            };
            return Ok(paymentDto);
        }

        [HttpPost]
        public async Task<ActionResult<PaymentDto>> CreatePayment(PaymentDto paymentDto)
        {
            var payment = new Payment
            {
                PaymentDate = paymentDto.PaymentDate,
                Amount = paymentDto.Amount,
                PaymentType = paymentDto.PaymentType,
                ContractId = paymentDto.ContractId
            };
            await _paymentsRepository.CreatePaymentAsync(payment);
            paymentDto.PaymentId = payment.PaymentId;
            return CreatedAtAction(nameof(GetPayment), new { id = paymentDto.PaymentId }, paymentDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, PaymentDto paymentDto)
        {
            if (id != paymentDto.PaymentId)
            {
                return BadRequest();
            }

            var payment = new Payment
            {
                PaymentId = paymentDto.PaymentId,
                PaymentDate = paymentDto.PaymentDate,
                Amount = paymentDto.Amount,
                PaymentType = paymentDto.PaymentType,
                ContractId = paymentDto.ContractId
            };
            await _paymentsRepository.UpdatePaymentAsync(payment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            await _paymentsRepository.DeletePaymentAsync(id);
            return NoContent();
        }
    }
}
