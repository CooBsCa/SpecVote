namespace SpecVote
{
   public class Vote
   {
      public Boolean EndingVote(List<(String,int)> _applications, int voters)
      {
         bool endVotePeriod = false;
         int numberOfVotes = 0;
         _applications.ForEach(x => { numberOfVotes += x.Item2;});

         if (numberOfVotes == voters)
            endVotePeriod = true;

         return endVotePeriod;
      }

      public List<(String,int)> WinnerIs(List<(String,int)> applications, int voters, bool secondRound)
      {
         (String,int) winner = ("",0);
         int limit = voters / 2;
         (String,int) looser = applications[0];
         (String, int) candidateA;
         (String, int) candidateB;
         bool blankVote = false;
         (String, int) blankVoteCandidate = ("",0);
         String blank = "Blank";
         
         if (secondRound.Equals(false))
         {
            applications.ForEach(x =>
            {
               if (x.Item1 == blank)
               {
                  blankVote = true;
                  blankVoteCandidate = x;
               }
            });

            if (blankVote == true)
               applications.Remove(blankVoteCandidate);
            
            applications.ForEach(x =>
            {
               if (x.Item2 < looser.Item2)
                  looser = x;
            });

            applications.ForEach(x =>
            {
               if (x.Item2 >= limit)
               {
                  winner = x;
               }
            });


            if (winner.Equals(("", 0)))
            {
               applications.Remove(looser);
            }
            else
            {
               applications.Clear();
               applications.Add(winner);
            }

            return applications;
         }

         applications.ForEach(x =>
         {
            if (x.Item1 == blank)
            {
               blankVote = true;
               blankVoteCandidate = x;
            }
         });

         if (blankVote == true)
            applications.Remove(blankVoteCandidate);
         
         candidateA = applications[0];
         candidateB = applications[1];
         applications.Clear();
         if (candidateA.Item2 > candidateB.Item2)
         {
            applications.Add(candidateA);
            return applications;
         }
         if(candidateA.Item2 == candidateB.Item2)
         {
            applications.Add(candidateA);
            applications.Add(candidateB);
            return applications;
         }

         applications.Add(candidateB);
         return applications;
      }
   }
}