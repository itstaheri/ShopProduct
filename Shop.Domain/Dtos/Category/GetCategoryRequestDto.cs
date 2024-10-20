namespace Shop.Domain.Dtos.Category
{
    public record GetCategoryRequestDto
    {
        public long CategoryParentId { get; set; }
        public string Name { get; set; }
    }
}
