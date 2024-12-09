namespace Shop.Domain.Dtos.Profile
{
    public record AddUserFavoriteRequestDto
    {
        public long UserId { get; set; }
        public long ProductId { get; set; }
    }
}
