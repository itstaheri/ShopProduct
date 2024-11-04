using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Setting
{
    public class SiteSettingModel : BaseEntity
    {
        public string? Title { get;private set; }
        public string? SiteName { get; private set; }
        public string? ContectList { get; private set; }
        public string? Addresss { get; private set; }
       
    }
}
