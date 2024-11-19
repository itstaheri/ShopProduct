namespace Shop.Domain.Dtos.Profile
{
    public record AddUserCartRequestDto
    {
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public long ColorId { get; set; }
        public int Quantity { get; set; }
    }
}
