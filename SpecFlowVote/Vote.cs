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

      public List<(String,int)> WinnerIs(List<(String,int)> applications, int voters)
      {
         (String,int) winner = ("",0);
         int limit = voters / 2;
         (String,int) looser = applications[0];
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
   }
}