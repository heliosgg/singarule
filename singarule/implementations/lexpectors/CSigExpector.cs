using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.lexpectors
{
   class CSigExpector : CGenericExpector<SingaSig>
   {
      public override bool ExpectIt(ref IWordWalker ww)
      {
         result = new SingaSig();

         var sigNameExpector = new CNameExpector();
         if (!sigNameExpector.ExpectIt(ref ww))
         {
            error = sigNameExpector.error;
            return false;
         }
         result.Name = sigNameExpector.result;

         var colonExpector = new CExactWordExpector(new SingaWord(":"));
         if (!colonExpector.ExpectIt(ref ww))
         {
            error = colonExpector.error;
            return false;
         }

         new CWhiteSpaceSkipper().ExpectIt(ref ww);

         ww.LockLockableMoves = true;
         if (new CExactWordExpector(new SingaWord("str")).ExpectIt(ref ww))
         {
            var stringSigExpector = new CStringSignatureExpector();
            if (!stringSigExpector.ExpectIt(ref ww))
            {
               error = stringSigExpector.error;
               return false;
            }
            result.Signature = stringSigExpector.result;
         }
         else if(new CExactWordExpector(new SingaWord("hex")).ExpectIt(ref ww))
         {
            // TODO: expect hex signature
         }
         else
         {
            error = BuildExpectedError("str!hex", ww.GetConcatedNWords(3).GetValue());
            ww.LockLockableMoves = false;
            return false;
         }
         ww.LockLockableMoves = false;

         return true;
      }
   }
}
