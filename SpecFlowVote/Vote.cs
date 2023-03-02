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

      public String WinnerIs(List<(String,int)> _applications, int voters)
      {
         String winner = String.Empty;
         int limit = voters / 2;
         _applications.ForEach(x =>
         {
            if (x.Item2 >= limit)
            {
               winner = x.Item1;
            }
         });

         return winner;
      }
   }
}