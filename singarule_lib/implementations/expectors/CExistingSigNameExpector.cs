using singarule_lib.interfaces;
using singarule_lib.models;
using System;

namespace singarule_lib.implementations.expectors
{
   public class CExistingSigNameExpector : CNameExpector
   {
      public override bool ExpectIt(ref IWordWalker ww, object currentSingaRule = null)
      {
         if (currentSingaRule is null)
         {
            throw new ArgumentNullException();
         }

         if (!base.ExpectIt(ref ww))
         {
            return false;
         }

         if (!((SingaRule)currentSingaRule).sigs.ContainsKey(result))
         {
            error = BuildExpectedError(Localization.ExistingSignatureName.ToLower(), result);
            return false;
         }

         return true;
      }
   }
}
