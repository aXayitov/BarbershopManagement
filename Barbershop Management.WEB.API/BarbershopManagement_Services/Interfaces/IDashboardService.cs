using BarbershopManagement_Services.DTOs.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboardAsync();
    }
}
