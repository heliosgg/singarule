using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.models
{
   class SingaState : SingaSig
   {
      public int position { get; set; } = -1;

      public bool IsTriggered() => position != 0;
   }
}
