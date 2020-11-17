using singarule.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.expressions
{
   class CConstantExpression : ISingaExpression
   {
      public List<ISingaExpression> Expressions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
      private bool _value;

      public CConstantExpression(bool value)
      {
         _value = value;
      }

      public ISingaExpression Operation(ISingaExpression left, ISingaExpression right)
      {
         throw new NotImplementedException();
      }

      public bool Eval() => _value;
   }
}
