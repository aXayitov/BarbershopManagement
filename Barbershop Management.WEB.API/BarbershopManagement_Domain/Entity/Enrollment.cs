using BarbershopManagement_Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.Entity
{
    public class Enrollment : EntityBase
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Status Status { get; set; }
    }
    public enum Status
    {
        Scheduled,
        Completed,
        Cancelled,
        NoShow,
        InProgress,
        Rescheduled
    }
}
