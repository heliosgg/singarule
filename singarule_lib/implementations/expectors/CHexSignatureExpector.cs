using singarule_lib.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace singarule_lib.implementations.expectors
{
   public class CHexSignatureExpector : CGenericExpector<byte[]>
   {
      public override bool ExpectIt(ref IWordWalker ww, object additionalParam = null)
      {
         var headExpector = new CExactWordExpector("hex(");
         if (!headExpector.ExpectIt(ref ww))
         {
            error = headExpector.error;
            return false;
         }

         List<string> stringBytes = new List<string>();
         var hexDigitExpector = new CHexDigitExpector();
         var spaceSkipper = new CWhiteSpaceSkipper();
         var closedBracketExpector = new CExactWordExpector(")");

         while (!closedBracketExpector.ExpectItLockable(ref ww))
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

         var tailExpector = new CExactWordExpector(");");
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
