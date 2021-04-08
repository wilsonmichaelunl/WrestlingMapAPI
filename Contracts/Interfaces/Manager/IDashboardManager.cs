using Contracts.DataModels;
using Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Interfaces.Manager
{
    public interface IDashboardManager
    {
        List<WrestlerModel> GetChampions();
        List<WrestlerModel> GetChampionsByYear(int year);
        List<StateTableModel> GetStateTableModels();
        List<StateTableModel> GetStateTableModelsByYear(int year);
    }
}
