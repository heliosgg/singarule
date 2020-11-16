using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace singarule.implementations.lexpectors
{
   class CExactWordExpector : CGenericExpector
   {
      public CExactWordExpector(SingaWord expected_value)
      {
         ExpectedWords = new SingaWord[] { expected_value }.ToList();
      }

      public override bool ExpectIt(ref IWordWalker ww, ref SingaRule resultRule)
      {
         if (!ExpectString(ref ww))
         {
            return false;
         }

         var currentWordValue = ww.GetCurrentWord().GetValue();
         if (!currentWordValue.Equals(ExpectedWords.First().GetValue()))
         {
            error = BuildExpectedError(currentWordValue);
            return false;
         }

         result = currentWordValue;
         ww.Move();
         return true;
      }
   }
}