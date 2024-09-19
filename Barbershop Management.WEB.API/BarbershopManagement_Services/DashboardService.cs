using BarbershopManagemen_Infrastructure.Persistence;
using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Services.DTOs.Dashboard;
using BarbershopManagement_Services.DTOs.EnrollmentDtos;
using BarbershopManagement_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services
{
    public class DashboardService(BarbershopDbContext context) : IDashboardService
    {
        private readonly BarbershopDbContext _context = context
            ?? throw new ArgumentNullException(nameof(context));
        public async Task<DashboardDto> GetDashboardAsync()
        {
            var summary = await GetSummaryAsync();
            var enrollmentsByBarber = await GetEnrollmentsByBarberAsync();
            var transactions = await GetLatestTransactionsAsync();
            var chartData = await GetChartsAsync();

            var dashboard = new DashboardDto
            {
                Summary = summary,
                EnrollmentsByBarbers = enrollmentsByBarber,
                SplineCharts = chartData,
                Transaction = transactions,
            };

            return dashboard;
        }
        private async Task<SummaryDto> GetSummaryAsync()
        {
            var summary = new SummaryDto();
            summary.Revenue = _context.Enrollments.Sum(x => x.TotalPrice);
            summary.LowQuantityBarbers = _context.Employees.Count();
            summary.CustomersAmount = _context.Customers.Count();

            return summary;
        }
        private async Task<List<EnrollmentsByBarber>> GetEnrollmentsByBarberAsync()
        {
            var enrollmentsByBarber = from enrollment in _context.Enrollments
                                      join barber in _context.Employees on enrollment.EmployeeId equals barber.Id
                                      where enrollment.Date.Month == DateTime.Now.Month && enrollment.Date.Year == DateTime.Now.Year
                                      orderby barber.FirstName
                                      group enrollment by new { barber.Id, barber.FirstName } into groupedEnrollments
                                      select new EnrollmentsByBarber
                                      {
                                          Barber = groupedEnrollments.Key.FirstName,
                                          EnrollmentsCount = groupedEnrollments.Count()
                                      };

            return await enrollmentsByBarber.ToListAsync();
         }

        private async Task<List<SplineChart>> GetChartsAsync()
        {
            var incomeTotal = _context
                .Enrollments
                .Where(x => x.Date > DateTime.Now.AddYears(-1))
                .ToList()
                .GroupBy(x => x.Date.ToString("MMMM"))
                .Select(x => new SplineChart
                {
                    Month =x.Key,
                    Income = x.Sum(x => x.TotalPrice)
                });
            var months = Enumerable.Range(0, 12)
                .Select(x => DateTime.Now.AddMonths(-x).ToString("MMMM"))
                .ToList();

            var chartData = from month in months
                            join income in incomeTotal on month equals income.Month into joinedIncome
                            from income in joinedIncome.DefaultIfEmpty()
                            select new SplineChart
                            {
                                Month = month,
                                Income = income?.Income ?? 0
                            };

            return chartData.ToList();
        }
        private async Task<List<TransactionDto>> GetLatestTransactionsAsync()
        {
            var enrollments = _context
                .Enrollments
                .Where(x => x.Date.Day == DateTime.Now.Day)
                .Select(x => new TransactionDto
                {
                    Id = x.Id,
                    Amount = x.InitialPayment,
                    Date = x.Date,
                    Type = "Enrollment"
                });

            List<TransactionDto> transactions = [.. enrollments];
            List<TransactionDto> orderedTransactions = transactions.Take(10).OrderBy(x => x.Date).ToList();

            return orderedTransactions;
        }

    }
}
