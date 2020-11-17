using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace singarule.models
{
   class SingaState : SingaSig
   {
      public int position { get; set; } = -1;

      public bool IsTriggered() => position != -1;
      public void Reset() => position = -1;
      public void Process(byte[] bytesToScan, int offset)
      {
         if (bytesToScan.Skip(offset).Take(Signature.Length).SequenceEqual(Signature))
         {
            position = offset;
         }
      }
   }
}
