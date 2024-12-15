namespace Shop.Domain.Dtos.Category
{
    public record CategoryDto 
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CategoryParentId { get; set; }
        public bool IsActive { get; set; }
        public string? Picture {  get; set; }
    }
}
