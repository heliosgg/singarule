using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace singarule.implementations.expectors
{
   class CExactWordExpector : CGenericExpector<string>
   {
      public CExactWordExpector(SingaWord expected_value)
      {
         ExpectedWords = new SingaWord[] { expected_value }.ToList();
      }

      public CExactWordExpector(string expected_value) : this(new SingaWord(expected_value)) { }

      public override bool ExpectIt(ref IWordWalker ww)
      {
         if (!ExpectString(ref ww))
         {
            return false;
         }

         string expectedLongWord = ExpectedWords.First().GetValue();
         string currentWordValue = ww.GetConcatedNWords(expectedLongWord.Length).GetValue();
         if (!currentWordValue.Equals(expectedLongWord))
         {
            error = BuildExpectedError(currentWordValue);
            return false;
         }

         result = currentWordValue;
         ww.LockableMove(expectedLongWord.Length);
         return true;
      }
   }
}