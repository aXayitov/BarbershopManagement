using BarbershopManagement_Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.Entity
{
    public class Customer : EntityBase
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public MarketingType marketingType { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
    public enum MarketingType
    {
        Instagram,
        StreetBanners,
        FromFriends
    }
}
