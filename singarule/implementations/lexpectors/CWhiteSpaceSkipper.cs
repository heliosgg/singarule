using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace singarule.implementations.lexpectors
{
   class CWhiteSpaceSkipper : CGenericExpector<object>
   {
      public override bool ExpectIt(ref IWordWalker ww)
      {
         var currentWord = ww.GetCurrentWord();
         while (  currentWord.IsEof() == false
               && Regex.IsMatch(currentWord.GetValue(), @"\s")
               )
         {
            ww.Move();
            currentWord = ww.GetCurrentWord();
         }

         return true;
      }
   }
}
