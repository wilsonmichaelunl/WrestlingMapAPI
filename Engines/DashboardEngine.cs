using Contracts.DataModels;
using Contracts.Interfaces.Engine;
using Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts.Enums;
using Contracts.Extensions;

namespace Engines
{
    public class DashboardEngine : IDashboardEngine
    {
        public List<WrestlerModel> BuildWrestlerModels(List<Champion> champions, List<Wrestler> wrestlers)
        {
            var result = new List<WrestlerModel>();

            foreach(Wrestler wrestler in wrestlers)
            {
                var relatedChampionships = champions.Where(x => x.WrestlerID == wrestler.WrestlerID).OrderBy(x => x.Year).ToList();
                var teams = relatedChampionships.Select(x => x.Team).Distinct().ToList();

                StringBuilder teamSB = new StringBuilder();
                StringBuilder yearsChampionSB = new StringBuilder();

                if (teams.Count == 1)
                {
                    teamSB.Append($"{teams.First()}, ");
                    foreach (Champion c in relatedChampionships)
                    {
                        yearsChampionSB.Append($"{c.Year} ({c.Weight} lbs), ");
                    }
                } else
                {
                    foreach(Champion c in relatedChampionships)
                    {
                        teamSB.Append($"{c.Team} ({c.Year}), ");
                        yearsChampionSB.Append($"{c.Year} ({c.Weight} lbs), ");
                    }
                }

                teamSB.Remove(teamSB.Length - 2, 2);
                yearsChampionSB.Remove(yearsChampionSB.Length - 2, 2);

                var wrestlerModel = new WrestlerModel
                {
                    Name = $"{wrestler.FirstName} {wrestler.LastName}",
                    State = Enum.GetName(typeof(StateEnum), wrestler.StateID),
                    Team = teamSB.ToString(),
                    Hometown = wrestler.Hometown,
                    Latitude = wrestler.Latitude,
                    Longitude = wrestler.Longitude,
                    YearsChampion = yearsChampionSB.ToString(),
                    WrestleStat = wrestler.WrestleStat
                };

                result.Add(wrestlerModel);
            }

            return result;
        }

        public List<WrestlerModel> BuildWrestlerModelsForYear(List<Champion> champions, List<Wrestler> wrestlers)
        {
            var result = new List<WrestlerModel>();

            foreach(Wrestler wrestler in wrestlers)
            {
                var champion = champions.Where(x => x.WrestlerID == wrestler.WrestlerID).First();
                var wrestlerModel = new WrestlerModel
                {
                    Name = $"{wrestler.FirstName} {wrestler.LastName}",
                    State = Enum.GetName(typeof(StateEnum), wrestler.StateID),
                    Team = champion.Team,
                    Hometown = wrestler.Hometown,
                    Latitude = wrestler.Latitude,
                    Longitude = wrestler.Longitude,
                    Weight = $"{champion.Weight} lbs",
                    WrestleStat = wrestler.WrestleStat
                };

                result.Add(wrestlerModel);
            }

            return result;
        }

        public List<StateTableModel> BuildStateTableModels(List<Champion> champions, List<Wrestler> wrestlers)
        {
            var result = new List<StateTableModel>();

            var stateList = wrestlers.Select(x => ((StateEnum)x.StateID).GetDisplayName()).ToList();
            var distinctStates = stateList.Distinct().ToList();

            var individualDictionary = distinctStates.ToDictionary(key => key.ToString(), value => 0);
            var totalDictionary = distinctStates.ToDictionary(key => key.ToString(), value => 0);

            foreach (string s in stateList)
            {
                individualDictionary[s]++;
            }

            foreach(Wrestler w in wrestlers)
            {
                var state = ((StateEnum)w.StateID).GetDisplayName();
                var championships = champions.Where(x => x.WrestlerID == w.WrestlerID).ToList().Count();
                totalDictionary[state] += championships;
            }

            foreach(string s in distinctStates)
            {
                var model = new StateTableModel { 
                    State = s,
                    IndividualChampions = individualDictionary[s],
                    TotalIndividualChampionships = totalDictionary[s]
                };

                result.Add(model);
            }

            return result.OrderByDescending(x => x.IndividualChampions).ThenByDescending(x => x.TotalIndividualChampionships).ToList();
        }

        public List<StateTableModel> BuildStateTableModelsByYear(List<Wrestler> wrestlers)
        {
            var result = new List<StateTableModel>();

            //var stateList = wrestlers.Select(x => Enum.GetName(typeof(StateEnum), x.StateID)).ToList();
            var stateList = wrestlers.Select(x => ((StateEnum)x.StateID).GetDisplayName()).ToList();
            var distinctStates = stateList.Distinct().ToList();

            var individualDictionary = distinctStates.ToDictionary(key => key.ToString(), value => 0);

            foreach (string s in stateList)
            {
                individualDictionary[s]++;
            }

            foreach (string s in distinctStates)
            {
                var model = new StateTableModel
                {
                    State = s,
                    IndividualChampions = individualDictionary[s]
                };

                result.Add(model);
            }

            return result.OrderByDescending(x => x.IndividualChampions).ToList();
        }
    }
}
