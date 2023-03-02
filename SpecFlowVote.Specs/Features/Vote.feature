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
	
	
Scenario: more than 50% display the winner
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
	Then the candidate wins at the first round
	
Scenario: second round
	Given following candidates
	  | candidates |
	  |	Charlie    |
	  |	Yoan       |
	  |	Carla      |
	And following votes
	  | votes |
	  | 11    |
	  | 10    |
	  | 9     | 
   	And we have 30 voters
   	When any candidate obtains more than 50% of the votes
   	Then there is a second round
   	
Scenario: 2 round max
	Given following candidates
	  | candidates |
	  |	Charlie    |
	  |	Yoan       |
	  |	Carla      |
	And following votes
	  | votes |
	  | 11    |
	  | 10    |
	  | 9     | 
   And we have 30 voters
   When All voters have voted
   When the first round is passed we pass to the round 2
   Given following candidates
     | candidates |
     |	Charlie   |
     |	Yoan      |
	And following votes
	  | votes |
	  | 14    |
	  | 16    |
   And we have 30 voters
   When All voters have voted
   When we count the final score
   Then the candidate with more votes win
   
Scenario: Equality in round 2 with white vote
	Given following candidates
	  | candidates |
	  |	Lucien    |
	  |	Joel       |
	  |	Carla      |
	And following votes
	  | votes |
	  | 11    |
	  | 10    |
	  | 9     | 
   And we have 30 voters
   When All voters have voted
   When the first round is passed we pass to the round 2
   Given following candidates
     | candidates |
     |	Lucien    |
     |	Joel      |
     | Blank      |	
     
   And following votes
	  | votes |
	  | 14    |
	  | 14    |
	  | 2     |	
   And we have 30 voters
   When All voters have voted
   When we count the final score
   Then there is no winner if equality in votes
   