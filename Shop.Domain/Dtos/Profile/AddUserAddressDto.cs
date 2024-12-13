namespace Shop.Domain.Dtos.Profile
{
    public record AddUserAddressDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long CityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PostalCode { get; set; }
        public string ReciverMobile { get; set; }
        public string? ReciverPhoneNumber { get; set; }

    }
}
