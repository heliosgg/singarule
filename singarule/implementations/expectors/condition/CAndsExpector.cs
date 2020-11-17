using singarule.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.expectors.condition
{
   class CAndsExpector : CGenericExpector<ISingaExpression>
   {
      public override bool ExpectIt(ref IWordWalker ww)
      {
         throw new NotImplementedException();
      }
   }
}
