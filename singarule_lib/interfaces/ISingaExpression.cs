using singarule.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace singarule.interfaces
{
   public interface ISingaExpression
   {
      List<ISingaExpression> Expressions { get; set; }
      ISingaExpression Operation(ISingaExpression left, ISingaExpression right);
      bool Eval() => Expressions.Aggregate((l, r) => Operation(l, r)).Eval();
   }
}
