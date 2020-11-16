using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.models
{
   interface ISingaSigState
   {
      string name { get; set; }
      string GetSigType();
   }
}
