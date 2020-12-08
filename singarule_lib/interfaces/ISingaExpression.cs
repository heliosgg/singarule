using System.Collections.Generic;
using System.Linq;

namespace singarule_lib.interfaces
{
   public interface ISingaExpression
   {
      List<ISingaExpression> Expressions { get; set; }
      ISingaExpression Operation(ISingaExpression left, ISingaExpression right);
      bool Eval() => Expressions.Aggregate((l, r) => Operation(l, r)).Eval();
   }
}
