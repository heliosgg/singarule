﻿using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace singarule.implementations.lexpectors
{
   class CEOFExpector : CGenericExpector
   {
      public CEOFExpector()
      {
         ExpectedWords = new SingaWord[] { new SingaWord(SingaWordType.EOF) }.ToList();
      }

      public override bool ExpectIt(ref IWordWalker ww, ref SingaRule resultRule)
      {
         SingaWord currentWord = ww.GetCurrentWord();
         if (!currentWord.IsEof())
         {
            error = BuildExpectedError(currentWord.GetValue());
            return false;
         }

         return true;
      }
   }
}
