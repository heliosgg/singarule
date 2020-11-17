using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace singarule.implementations.expressions
{
   class CStateExpression : ISingaExpression
   {
      public List<ISingaExpression> Expressions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
      private SingaState _state;

      public CStateExpression(SingaState state)
      {
         _state = state;
      }

      public ISingaExpression Operation(ISingaExpression left, ISingaExpression right)
      {
         throw new NotImplementedException();
      }

      public bool Eval() => _state.IsTriggered();
   }
}
