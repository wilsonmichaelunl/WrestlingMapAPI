using Contracts.DataModels;
using Contracts.Interfaces.Manager;
using Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : Controller        
    {
        private IDashboardManager _dashboardManager;

        public DashboardController(IDashboardManager dashboardManager)
        {
            _dashboardManager = dashboardManager;
        }

        [HttpGet("champions")]
        public List<WrestlerModel> GetChampions()
        {
            var champions = _dashboardManager.GetChampions();

            return champions;
        }

        [HttpGet("champions/{year}")]
        public List<WrestlerModel> GetChampions(int year)
        {
            var champions = _dashboardManager.GetChampionsByYear(year);

            return champions;
        }

        [HttpGet("table/")]
        public List<StateTableModel> GetStateTableModels()
        {
            var result = _dashboardManager.GetStateTableModels();

            return result;
        }

        [HttpGet("table/{year}")]
        public List<StateTableModel> GetStateTableModels(int year)
        {
            var result = _dashboardManager.GetStateTableModelsByYear(year);

            return result;
        }
    }
}
