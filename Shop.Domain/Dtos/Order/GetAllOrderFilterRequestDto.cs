namespace Shop.Domain.Dtos.Order
{
    public record GetAllOrderFilterRequestDto : PaginationRequestDto
    {
        public long UserId { get; set; }
    }
}
