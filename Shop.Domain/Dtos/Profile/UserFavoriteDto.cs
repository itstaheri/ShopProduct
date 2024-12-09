using Shop.Domain.Dtos.Product;

namespace Shop.Domain.Dtos.Profile
{
    public record UserFavoriteDto : PaginationRequestDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}
