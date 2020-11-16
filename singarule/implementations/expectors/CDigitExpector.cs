using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.expectors
{
   class CDigitExpector : CStringOfCharsExpector
   {
      public CDigitExpector() : base("1234567890") { }
   }
}
