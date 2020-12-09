using singarule_lib.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace singarule_lib.implementations.expectors
{
   abstract public class CGenericExpector<T>
   {
      public T result { get; set; }
      public string error { get; set; }
      public List<SingaWord> ExpectedWords { get; protected set; }

      // times = -1 means infinity
      abstract public bool ExpectIt(ref IWordWalker ww, object additionalParam = null);
      public bool ExpectItLockable(ref IWordWalker ww, object additionalParam = null)
      {
         ww.LockLockableMoves = true;
         bool result = ExpectIt(ref ww, additionalParam);
         ww.LockLockableMoves = false;

         return result;
      }
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

      protected string BuildExpectedError(string expected, string found) =>
         $"{Localization.Expected} `{expected}`, {Localization.Found.ToLower()} `{found}`";

      protected string BuildExpectedError(string found) =>
         BuildExpectedError(string.Join("`, `", ExpectedWords.Select(x => x.GetValue())), found);

      public bool HasNoErrors() => string.IsNullOrEmpty(error);
   }
}
