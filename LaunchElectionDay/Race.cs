using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchElectionDay
{
    public class Race
    {
        public string Office;
        public List<Candidate> Candidates;
        public bool isOpen;

        public Race(string office) 
        { 
            Office = office;
            Candidates = new List<Candidate>();
            isOpen = true;
        }

        public void RegisterCandidate(Candidate candidate)
        {
            Candidates.Add(candidate);
        }

        public void Close()
        {
            isOpen = false;
        }

        public dynamic Winner()
        {
            if (isOpen)
            {
                return false;
            } else
            {
                Candidate winner = Candidates[0];
                for (var i = 1; i < Candidates.Count; i++)
                {
                    if (Candidates[i].Votes > Candidates[0].Votes)
                    {
                        winner = Candidates[i];
                    }
                }
                return winner;
            }
        }

        public bool IsTie()
        {
            var isTie = false;
            var numWinners = 0;
            Candidate winner = Candidates[0];
            for (var i = 1; i < Candidates.Count; i++)
            {
                if (Candidates[i].Votes > Candidates[0].Votes)
                {
                    winner = Candidates[i];
                }
            }
            foreach(var candidate in Candidates)
            {
                if(candidate.Votes == winner.Votes)
                {
                    numWinners++;
                }
            }
            if (numWinners > 1)
            {
                    isTie = true;
            }
            return isTie;
        }
    }
}
