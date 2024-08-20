using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.DTOs.Dashboard
{
    public class DashboardDto
    {
        public SummaryDto Summary { get; set; }
        public List<EnrollmentsByBarber> EnrollmentsByBarbers { get; set; }
        public List<SplineChart> SplineCharts { get; set; }
        public List<TransactionDto> Transaction { get; set; }
    }
    public class SummaryDto
    {
        public decimal Revenue { get; set; }
        public int LowQuantityBarbers { get; set; }
        public int CustomersAmount { get; set; }
    }
    public class EnrollmentsByBarber
    {
        public string Barber { get; set; }
        public int EnrollmentsCount { get; set; }
    }
    public class SplineChart
    {
        public string Month { get; set; }
        public decimal Income { get; set; }
        public decimal Refunds { get; set; }
    }
    public class TransactionDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

    }
}
