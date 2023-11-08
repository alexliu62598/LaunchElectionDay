using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchElectionDay
{
    internal class Election
    {
        public string Year;
        public List<Race> Races;

        public Election(string year)
        {
            Year = year;
            Races = new List<Race>();
        }

        public void AddRace(Race race)
        {
            Races.Add(race);
        }

        public List<Candidate> AllCandidates()
        {
            var candidates = new List<Candidate>();
            foreach (var race in Races)
            {
                foreach (var c in race.Candidates)
                {
                    candidates.Add(c);
                }
            }
            return candidates;
        }

        public Dictionary<string, int> VoteCounts()
        {
            var candidates = new Dictionary<string, int>();
            foreach(var race in Races)
            {
                foreach(var c in race.Candidates)
                {
                    candidates.Add(c.Name, c.Votes);
                }
            }
            return candidates;
        }
    }
}
