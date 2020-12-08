using singarule_lib.interfaces;
using System.Linq;

namespace singarule_lib.implementations.expectors
{
   public class CExactWordExpector : CGenericExpector<string>
   {
      public CExactWordExpector(SingaWord expected_value)
      {
         ExpectedWords = new SingaWord[] { expected_value }.ToList();
      }

      public CExactWordExpector(string expected_value) : this(new SingaWord(expected_value)) { }

      public override bool ExpectIt(ref IWordWalker ww, object additionalParam = null)
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