using Contracts.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Interfaces
{
    public interface IDashboardAccessor
    {
        List<Champion> GetChampions();
        List<Champion> GetChampionsByYear(int year);
        List<Wrestler> GetWrestlers();
        List<Wrestler> GetWrestlersByIds(List<Guid> ids);


    }
}
