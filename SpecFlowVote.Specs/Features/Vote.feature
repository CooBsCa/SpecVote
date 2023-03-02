Feature: Vote
	Simple Vote Check


Scenario: Vote validation
	Given following candidates
	  | candidates |
	  |	Charlie    |
	  |	Yoan       |
	  |	Carla      |
	And following votes
	  | votes |
	  | 10    |
	  | 10    |
	  | 10    |
	And we have 30 voters
	When All voters have voted
	Then the vote is closed
	
	
Scenario: more than 50% 
	Given following candidates
	  | candidates |
	  |	Charlie    |
	  |	Yoan       |
	  |	Carla      |
   	And following votes
      | votes |
      | 15    |
      | 10    |
      | 5	  |
    And we have 30 voters
	When a candidate obtains more than 50% of the votes
	Then the candidate wins in the first round