using singarule_lib.interfaces;
using System.Linq;

namespace singarule_lib.implementations.expectors
{
   public class CEOFExpector : CGenericExpector<object>
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
