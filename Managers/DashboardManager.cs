using Contracts.DataModels;
using Contracts.Interfaces;
using Contracts.Interfaces.Engine;
using Contracts.Interfaces.Manager;
using Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Managers
{
    public class DashboardManager : IDashboardManager
    {
        private IDashboardAccessor _dashboardAccessor;
        private IDashboardEngine _dashboardEngine;

        public DashboardManager(IDashboardAccessor dashboardAccessor, IDashboardEngine dashboardEngine)
        {
            _dashboardAccessor = dashboardAccessor;
            _dashboardEngine = dashboardEngine;
        }

        public List<WrestlerModel> GetChampions()
        {
            var champions = _dashboardAccessor.GetChampions();
            var wrestlers = _dashboardAccessor.GetWrestlers();
            var result = _dashboardEngine.BuildWrestlerModels(champions, wrestlers);

            return result;
        }

        public List<WrestlerModel> GetChampionsByYear(int year)
        {
            var champions = _dashboardAccessor.GetChampionsByYear(year);
            var wrestlerIds = champions.Select(x => x.WrestlerID).Distinct().ToList();
            var wrestlers = _dashboardAccessor.GetWrestlersByIds(wrestlerIds);
            var wrestlerModels = _dashboardEngine.BuildWrestlerModelsForYear(champions, wrestlers);

            return wrestlerModels;
        }

        public List<StateTableModel> GetStateTableModels()
        {
            var champions = _dashboardAccessor.GetChampions();
            var wrestlers = _dashboardAccessor.GetWrestlers();
            var result = _dashboardEngine.BuildStateTableModels(champions, wrestlers);

            return result;
        }

        public List<StateTableModel> GetStateTableModelsByYear(int year)
        {
            var champions = _dashboardAccessor.GetChampionsByYear(year);
            var wrestlerIds = champions.Select(x => x.WrestlerID).Distinct().ToList();
            var wrestlers = _dashboardAccessor.GetWrestlersByIds(wrestlerIds);
            var result = _dashboardEngine.BuildStateTableModelsByYear(wrestlers);

            return result;
        }
    }
}
