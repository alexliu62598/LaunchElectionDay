using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchElectionDay.UnitTests
{
    class ElectionTests
    {
        [Fact]
        public void Election_WhenInstantiated_IsCreatedWithProperties(){
            var election = new Election("2023");

            Assert.Equal("2023", election.Year);
        }

        [Fact]
        public void AddRace_AddsRaceToRacesList(){
            var election = new Election("2023");
            var race = new Race("mayor");
            election.AddRace(race);

            Assert.Equal(election.Races[0], race);
        }

        [Fact]
        public void AllCandidates_ReturnsListOfAllCandidates(){
            var election = new Election("2023");
            var race = new Race("mayor");
            var candidate1 = new Candidate("diana", "democrat");
            var candidate2 = new Candidate("ross", "republican");
            race.RegisterCandidate(candidate1);
            race.RegisterCandidate(candidate2);
            election.AddRace(race);

            Assert.Equal(new List<Candidate> { candidate1, candidate2 }, election.AllCandidates());
        }

        [Fact]
        public void VoteCounts_ReturnsDictionaryWithCandidateNamesAndVotes(){
            var election = new Election("2023");
            var race = new Race("mayor");
            var candidate1 = new Candidate("diana", "democrat");
            var candidate2 = new Candidate("ross", "republican");
            candidate1.VoteFor();
            candidate2.VoteFor();
            race.RegisterCandidate(candidate1);
            race.RegisterCandidate(candidate2);
            election.AddRace(race);

            Assert.Equal(new Dictionary { { "diana", 1 }, { "ross", 1 }, election.VoteCounts());
        }
    }
}
