namespace Shop.Domain.Dtos.Category
{
    public record UpdateCategoryDto : CreateCategoryDto
    {
        public int CategoryId { get; set; }
    }
}
