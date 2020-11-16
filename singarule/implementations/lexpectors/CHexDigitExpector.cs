using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.lexpectors
{
   class CHexDigitExpector : CStringOfCharsExpector
   {
      public CHexDigitExpector() : base("1234567890abcdefABCDEF") { }
   }
}
