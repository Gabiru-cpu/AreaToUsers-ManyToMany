using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AreaApi.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {

        public virtual List<Area> Areas { get; set; }
        public virtual List<Area> AreasOwned { get; set; }
    }
}
