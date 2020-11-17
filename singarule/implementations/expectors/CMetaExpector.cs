using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.expectors
{
   class CMetaExpector : CGenericExpector<List<SingaSig>>
   {
      public override bool ExpectIt(ref IWordWalker ww)
      {
         List<SingaSig> metaSigs = new List<SingaSig>();

         var sigExpector = new CSigExpector();
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
