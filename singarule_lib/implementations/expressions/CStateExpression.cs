using singarule_lib.interfaces;
using singarule_lib.models;
using System;
using System.Collections.Generic;

namespace singarule_lib.implementations.expressions
{
   class CStateExpression : ISingaExpression
   {
      public List<ISingaExpression> Expressions { get; set; }
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
