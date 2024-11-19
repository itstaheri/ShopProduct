namespace Shop.Domain.Dtos.Profile
{
    public record UpdateUserCartRequestDto
    {
        public long Id { get; set; }
        public long Quantity { get; set; }
    }
}
