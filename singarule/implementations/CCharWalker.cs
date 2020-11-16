using singarule.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations
{
   class CCharWalker : IWordWalker
   {
      private string Data;
      private int CurrentIdx;

      public void Init(string data)
      {
         CurrentIdx = 0;
         this.Data = data;
      }

      public SingaWord GetNextWord(int offset = 1)
      {
         int IdxToReturn = CurrentIdx + offset;

         if (IdxToReturn < 0)
         {
            return new SingaWord(SingaWordType.INVALUD);
         }

         if (IdxToReturn == Data.Length)
         {
            return new SingaWord(SingaWordType.EOF);
         }

         if (IdxToReturn > Data.Length)
         {
            return new SingaWord(SingaWordType.INVALUD);
         }

         return new SingaWord(Convert.ToString(Data[IdxToReturn]));
      }

      public SingaWord GetConcatedNWords(int n, int offset = 0)
      {
         StringBuilder result = new StringBuilder("");

         for (int i = offset; i < offset + n; i++)
         {
            var currentWord = GetNextWord(i);
            if (currentWord.IsStr() == false)
               break;

            result.Append(currentWord.GetValue());
         }

         return new SingaWord(result.ToString());
      }

      public bool Move(int offset = 1)
      {
         int NewIdx = CurrentIdx + offset;

         if (NewIdx > Data.Length)
            NewIdx = Data.Length;

         if (CurrentIdx < 0)
            NewIdx = 0;

         CurrentIdx = NewIdx;
         return true;
      }

      public SingaWord GetCurrentLine()
      {
         int LineStart = 0;
         for (int i = CurrentIdx; i >= 0; i--)
         {
            if (Data[i].Equals(Environment.NewLine))
            {
               LineStart = i;
               break;
            }
         }

         StringBuilder result = new StringBuilder("");
         while (  LineStart < Data.Length
               || Convert.ToString(Data[LineStart]).Equals(Environment.NewLine) == false
               )
         {
            result.Append(Data[LineStart]);
         }

         return new SingaWord(result.ToString());
      }
   }
}
