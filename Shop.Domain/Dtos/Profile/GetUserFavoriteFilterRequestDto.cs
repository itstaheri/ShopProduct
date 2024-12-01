namespace Shop.Domain.Dtos.Profile
{
    public record GetUserFavoriteFilterRequestDto : PaginationRequestDto
    {
        public long UserId { get; set; }
    }
}
