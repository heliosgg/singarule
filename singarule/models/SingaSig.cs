using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.models
{
   class SingaSig
   {
      public string Name { get; set; }
      public byte[] Signature { get; set; }

      public SingaSig()
      {
         Name = null;
         Signature = null;
      }
   }
}
