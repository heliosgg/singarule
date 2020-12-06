using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.expectors
{
   class CHexDigitExpector : CStringOfCharsExpector
   {
      public CHexDigitExpector() : base("1234567890abcdefABCDEF") { }
   }
}
