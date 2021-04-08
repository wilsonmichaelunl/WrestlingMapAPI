using Contracts.DataModels;
using Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Accessors
{
    public class DashboardAccessor : IDashboardAccessor
    {
        private readonly ApplicationContext _dbContext;

        public DashboardAccessor(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Champion> GetChampions()
        {
            var champions = _dbContext.Champions.ToList();
            return champions;
        }

        public List<Champion> GetChampionsByYear(int year)
        {
            var champions = _dbContext.Champions.Where(x => x.Year == year).ToList();
            return champions;
        }

        public List<Wrestler> GetWrestlers()
        {
            var wrestlers = _dbContext.Wrestlers.ToList();
            return wrestlers;
        }

        public List<Wrestler> GetWrestlersByIds(List<Guid> ids)
        {
            var wrestlers = _dbContext.Wrestlers.Where(x => ids.Contains(x.WrestlerID)).ToList();
            return wrestlers;
        }
    }
}
