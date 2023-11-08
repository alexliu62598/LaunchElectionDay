using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchElectionDay.UnitTests
{
    public class RaceTests
    {
        [Fact]
        public void Race_WhenInstantiated_SetsProperties()
        {
            var race = new Race("mayor");
            Assert.Equal("mayor", race.Office);
        }

        [Fact]
        public void RegisterCandidate_AddsCandidate_ToCandidateList()
        {
            var candidate = new Candidate("diana", "democrat");
            var race = new Race("governor");
            Assert.Equal(race.Candidates[0], candidate);
        }

        [Fact]

        public void Close_ChangesValueOfIsOpen()
        {
            var race = new Race("mayor");

            Assert.True(race.isOpen);

            race.Close();

            Assert.False(race.isOpen);
        }

        [Fact]
        public void Winner_ReturnsFalseIfRaceIsOpen_ElseReturnsWinner()
        {
            var race = new Race("mayor");
            Assert.False(race.Winner());

            race.Close();
            var candidate1 = new Candidate("diana", "democrat");
            var candidate2 = new Candidate("ross", "republican");

            candidate1.VoteFor();

            Assert.Equal(candidate1, race.Winner());
        }

        [Fact]

        public void IsTie_ReturnsCorrectValueOfIsTie()
        {
            var race = new Race("mayor");
            var candidate1 = new Candidate("diana", "democrat");
            var candidate2 = new Candidate("ross", "republican");
            candidate1.VoteFor();
            candidate2.VoteFor();

            Assert.True(race.IsTie());

            candidate2.VoteFor();

            Assert.False(race.IsTie());
        }
    }
}
