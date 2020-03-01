using ForTest.Core.Data.Enums;
using System;

namespace ForTest.Core.Models
{
    public class CustomerFiltering
    {
        public CustomerFiltering()
        {
            Sorting = ESortOrder.NoSorting;
        }

        public int? CustomerId { get; set; }

        public string Name { get; set; }

        public DateTime? BirthDayFrom { get; set; }
        public DateTime? BirthDayTo { get; set; }

        public ECustomerGender? Gender { get; set; }

        public int? QuantityRequest { get; set; }

        public ESortOrder Sorting { get; set; }
    }
}