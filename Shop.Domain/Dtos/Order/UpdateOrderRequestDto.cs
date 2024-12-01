namespace Shop.Domain.Dtos.Order
{
    public record UpdateOrderRequestDto : AddOrderRequestDto
    {
        public long Id { get; set; }
        public bool IsActive { get; set; }
    }
}
