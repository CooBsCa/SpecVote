using System;
using System.Collections.Generic;
using FluentAssertions;
using SpecVote;
using TechTalk.SpecFlow;

namespace SpecFlowVote.Specs.Steps
{
    [Binding]
    public sealed class VoteStepDefinitions
    {
        private readonly List<String> _candidates;
        private List<(String, int)> _applications;
        
        private int _voters;
        
        private bool _votesCheck;

        private List<(String,int)> winnerIs;

        private bool _secondRound = false;

        public VoteStepDefinitions()
        {
            _applications = new List<(string, int)>();
            _candidates = new List<String>();
        }

        [Given("following candidates")]
        public void GivenFollowingCandidates(Table table)
        {
            _candidates.Clear();
            foreach (var row in table.Rows)
            {
                _candidates.Add(row["candidates"]);
            }
        }
        
        [Given("following votes")]
        public void GivenFollowingVotes(Table table)
        {
            int i = 0;
            _applications.Clear();
            foreach (var row in table.Rows)
            {
                _applications.Add((_candidates[i],int.Parse(row["votes"])));
                i++;
            }
        }
        
        [Given("we have(.*) voters")]
        public void GivenWeHaveVoters(int voters)
        {
            _voters = voters;
        }

        [When("All voters have voted")]
        public void WhenTheVotingPeriodIsOver()
        {
            Vote vote = new Vote();
            _votesCheck = vote.EndingVote(_applications,_voters);
        }

        [When("a candidate obtains more than 50% of the votes")]
        public void WhenObtainMoreThan50()
        {
            Vote vote = new Vote();
            winnerIs = vote.WinnerIs(_applications, _voters, _secondRound);
        }

        [When("any candidate obtains more than 50% of the votes")]
        public void WhenNobodyObtainMoreThan50()
        {
            Vote vote = new Vote();
            winnerIs = vote.WinnerIs(_applications, _voters,_secondRound);
        }

        [When("the first round is passed we pass to the round 2")]
        public void TheFirstRoundIsPassed()
        {
            _secondRound = _votesCheck;
            _secondRound.Should().Be(true);
        }

        [When("we count the final score")]
        public void WeCountFinalScore()
        {
            Vote vote = new Vote();
            winnerIs = vote.WinnerIs(_applications, _voters, _secondRound);
        }

        [Then("the vote is closed")]
        public void ThenTheResultShouldBe()
        {
            _votesCheck.Should().Be(true);
        }

        [Then("the candidate wins at the first round")]
        public void ThenCandidateWins()
        {
            winnerIs.Should().OnlyHaveUniqueItems();
        }
        
        [Then("there is a second round")]
        public void ThenThereIsSecondRound()
        {
            winnerIs.Should().HaveCount(2);
        }

        [Then("the candidate with more votes win")]
        public void ThenTheCandidateWithMoreVotesWin()
        {
            winnerIs.Should().HaveCount(1);
        }
        
        [Then("there is no winner if equality in votes")]
        public void ThenThereIsEquality()
        {
            winnerIs.Should().HaveCount(2);
        }
    }
}