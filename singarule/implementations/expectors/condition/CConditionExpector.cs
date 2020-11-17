using singarule.implementations.expressions;
using singarule.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.expectors.condition
{
   class CConditionExpector : CGenericExpector<ISingaExpression>
   {
      public override bool ExpectIt(ref IWordWalker ww)
      {
         result = new COrExpression();

         return true;
      }
   }
}
