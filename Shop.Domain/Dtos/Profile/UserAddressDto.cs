using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Profile
{
    public record UserAddressDto
    {
        public long Id { get; set; }
        public long CityId {  get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public string PostalCode { get; set; }
        public string CityTitle { get; set; }
        public string Mobile {  get; set; }
        public string? Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
