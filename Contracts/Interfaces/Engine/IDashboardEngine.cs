using Contracts.DataModels;
using Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Interfaces.Engine
{
    public interface IDashboardEngine
    {
        List<WrestlerModel> BuildWrestlerModels(List<Champion> champions, List<Wrestler> wrestlers);
        List<WrestlerModel> BuildWrestlerModelsForYear(List<Champion> champions, List<Wrestler> wrestlers);
        List<StateTableModel> BuildStateTableModels(List<Champion> champions, List<Wrestler> wrestlers);
        List<StateTableModel> BuildStateTableModelsByYear(List<Wrestler> wrestlers);
    }
}
