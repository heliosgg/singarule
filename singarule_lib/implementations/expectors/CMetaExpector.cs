using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.expectors
{
   class CMetaExpector : CGenericExpector<List<SingaState>>
   {
      public override bool ExpectIt(ref IWordWalker ww, object additionalParam = null)
      {
         List<SingaState> metaSigs = new List<SingaState>();

         var sigExpector = new CSingleSigExpector();
         var spaceSkipper = new CWhiteSpaceSkipper();
         while (sigExpector.ExpectIt(ref ww))
         {
            metaSigs.Add(sigExpector.result);
            spaceSkipper.ExpectIt(ref ww);
         }

         result = metaSigs;
         return true;
      }
   }
}
