using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace singarule.implementations.lexpectors
{
   abstract class CGenericExpector
   {
      public string result { get; set; }
      public string error { get; set; }
      public List<SingaWord> ExpectedWords { get; protected set; }

      // times = -1 means infinity
      abstract public bool ExpectIt(ref IWordWalker ww, ref SingaRule resultRule);
      protected bool ExpectString(ref IWordWalker ww)
      {
         var currentWord = ww.GetCurrentWord();

         if (currentWord.IsEof())
         {
            error = BuildExpectedError("EOF");
            return false;
         }

         return true;
      }

      protected string BuildExpectedError(string found) =>
         $"Expected `{string.Join("`, `", ExpectedWords.Select(x => x.GetValue()))}`, found `{found}`";
   }
}
