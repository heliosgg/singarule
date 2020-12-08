using singarule_lib.interfaces;
using System.Collections.Generic;

namespace singarule_lib.implementations.expressions
{
   class COrExpression : ISingaExpression
   {
      public List<ISingaExpression> Expressions { get; set; } = new List<ISingaExpression>();

      public ISingaExpression Operation(ISingaExpression left, ISingaExpression right)
         => new CConstantExpression(left.Eval() || right.Eval());
   }
}
