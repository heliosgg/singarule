﻿using singarule.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace singarule.implementations.lexpectors
{
   class CHexSignatureExpector : CGenericExpector<byte[]>
   {
      public override bool ExpectIt(ref IWordWalker ww)
      {
         var headExpector = new CExactWordExpector(new SingaWord("hex("));
         if (!headExpector.ExpectIt(ref ww))
         {
            error = headExpector.error;
            return false;
         }

         List<string> stringBytes = new List<string>();
         var hexDigitExpector = new CHexDigitExpector();
         var spaceSkipper = new CWhiteSpaceSkipper();

         while (ww.GetCurrentWord().GetValue().Equals(")") == false)
         {
            spaceSkipper.ExpectIt(ref ww);

            var currentByte = "";

            for (int i = 0; i < 2; i++)
            {
               if (!hexDigitExpector.ExpectIt(ref ww))
               {
                  error = hexDigitExpector.error;
                  return false;
               }

               currentByte += hexDigitExpector.result;
            }

            stringBytes.Add(currentByte);
            spaceSkipper.ExpectIt(ref ww);
         }

         var tailExpector = new CExactWordExpector(new SingaWord(");"));
         if (!tailExpector.ExpectIt(ref ww))
         {
            error = tailExpector.error;
            return false;
         }

         result = stringBytes.Select(x => Convert.ToByte(x, 16)).ToArray();
         return true;
      }
   }
}
