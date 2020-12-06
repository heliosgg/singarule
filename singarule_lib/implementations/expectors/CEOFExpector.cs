using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace singarule.implementations.expectors
{
   class CEOFExpector : CGenericExpector<object>
   {
      public CEOFExpector()
      {
         ExpectedWords = new SingaWord[] { new SingaWord(SingaWordType.EOF) }.ToList();
      }

      public override bool ExpectIt(ref IWordWalker ww, object additionalParam = null)
      {
         SingaWord currentWord = ww.GetCurrentWord();
         if (!currentWord.IsEof())
         {
            error = BuildExpectedError(currentWord.GetValue());
            return false;
         }

         return true;
      }
   }
}
