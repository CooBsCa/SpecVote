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

        private bool _moreThan50;

        public VoteStepDefinitions()
        {
            _applications = new List<(string, int)>();
            _candidates = new List<String>();
        }

        [Given("following candidates")]
        public void GivenFollowingCandidates(Table table)
        {
            foreach (var row in table.Rows)
            {
                _candidates.Add(row["candidates"]);
            }
        }
        
        [Given("following votes")]
        public void GivenFollowingVotes(Table table)
        {
            int i = 0;
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
            _moreThan50 = vote.MoreThan50(_applications, _voters);
        }

        [Then("the vote is closed")]
        public void ThenTheResultShouldBe()
        {
            _votesCheck.Should().Be(true);
        }

        [Then("the candidate wins in the first round")]
        public void ThenCandidateWins()
        {
            _moreThan50.Should().Be(true);
        }
    }
}