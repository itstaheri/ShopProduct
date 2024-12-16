namespace Shop.Domain.Dtos.Profile
{
    public record UpdateUserAddressDto : AddUserAddressDto
    {
        public long UserAddressId { get; set; }
    }
}
