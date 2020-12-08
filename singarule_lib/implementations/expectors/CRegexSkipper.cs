using singarule_lib.interfaces;
using System.Text.RegularExpressions;

namespace singarule_lib.implementations.expectors
{
   public class CRegexSkipper : CGenericExpector<object>
   {
      private readonly string _rePattern;

      public CRegexSkipper(string rePattern)
      {
         _rePattern = rePattern;
      }

      public override bool ExpectIt(ref IWordWalker ww, object additionalParam = null)
      {
         var currentWord = ww.GetCurrentWord();
         while (currentWord.IsEof() == false
               && Regex.IsMatch(currentWord.GetValue(), _rePattern)
               )
         {
            ww.Move();
            currentWord = ww.GetCurrentWord();
         }

         return true;
      }
   }
}
