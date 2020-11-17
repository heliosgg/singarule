using singarule.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.expressions
{
   class COrExpression : ISingaExpression
   {
      public List<ISingaExpression> Expressions { get; set; } = new List<ISingaExpression>();

      public ISingaExpression Operation(ISingaExpression left, ISingaExpression right)
         => new CConstantExpression(left.Eval() || right.Eval());
   }
}
