﻿using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace singarule.implementations.lexpectors
{
   class CStringOfCharsExpector : CGenericExpector<string>
   {
      public CStringOfCharsExpector(string expected_chars)
      {
         ExpectedWords = expected_chars.Select(x => new SingaWord(x)).ToList();
      }

      public override bool ExpectIt(ref IWordWalker ww)
      {
         if (!ExpectString(ref ww))
         {
            return false;
         }

         var currentWordValue = ww.GetCurrentWord().GetValue();
         foreach (var w in ExpectedWords)
         {
            if (!currentWordValue.Equals(w.GetValue()))
            {
               error = BuildExpectedError(currentWordValue);
               return false;
            }
         }

         result = currentWordValue;
         ww.LockableMove();
         return true;
      }
   }
}
