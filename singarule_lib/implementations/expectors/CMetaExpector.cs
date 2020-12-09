using singarule_lib.interfaces;
using singarule_lib.models;
using System.Collections.Generic;

namespace singarule_lib.implementations.expectors
{
   public class CMetaExpector : CGenericExpector<List<SingaState>>
   {
      public override bool ExpectIt(ref IWordWalker ww, object additionalParam = null)
      {
         List<SingaState> metaSigs = new List<SingaState>();

         var sigExpector = new CSingleSigExpector();
         var spaceSkipper = new CWhiteSpaceSkipper();
         var closedBraceExpector = new CExactWordExpector("}");

         while (!closedBraceExpector.ExpectItLockable(ref ww))
         {
            if (!sigExpector.ExpectIt(ref ww))
            {
               error = sigExpector.error;
               return false;
            }

            metaSigs.Add(sigExpector.result);
            spaceSkipper.ExpectIt(ref ww);
         }

         result = metaSigs;
         return true;
      }
   }
}
