using BarbershopManagement_Services.DTOs.Dashboard;
using BarbershopManagement_Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop_Management.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    [Authorize]
    public class DashboardController(IDashboardService dashboardService) : Controller
    {
        private readonly IDashboardService _dashboardService = dashboardService;

        [HttpGet]
        public async Task<ActionResult<DashboardDto>> GetDashboardAsync()
        {
            var dashboard = await _dashboardService.GetDashboardAsync();

            return Ok(dashboard);
        }
    }
}
