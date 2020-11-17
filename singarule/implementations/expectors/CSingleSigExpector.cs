using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.expectors
{
   class CSingleSigExpector : CGenericExpector<SingaState>
   {
      public override bool ExpectIt(ref IWordWalker ww, object additionalParam = null)
      {
         result = new SingaState();

         var sigNameExpector = new CNameExpector();
         if (!sigNameExpector.ExpectIt(ref ww))
         {
            error = sigNameExpector.error;
            return false;
         }
         result.Name = sigNameExpector.result;

         var colonExpector = new CExactWordExpector(":");
         if (!colonExpector.ExpectIt(ref ww) || !colonExpector.HasNoErrors())
         {
            error = colonExpector.error;
            return false;
         }

         new CWhiteSpaceSkipper().ExpectIt(ref ww);

         ww.LockLockableMoves = true;
         if (new CExactWordExpector("str").ExpectIt(ref ww))
         {
            ww.LockLockableMoves = false;
            var stringSigExpector = new CStringSignatureExpector();
            if (!stringSigExpector.ExpectIt(ref ww))
            {
               error = stringSigExpector.error;
               return false;
            }
            result.Signature = stringSigExpector.result;
         }
         else if(new CExactWordExpector("hex").ExpectIt(ref ww))
         {
            ww.LockLockableMoves = false;
            var hexSigExpector = new CHexSignatureExpector();
            if (!hexSigExpector.ExpectIt(ref ww))
            {
               error = hexSigExpector.error;
               return false;
            }
            result.Signature = hexSigExpector.result;
         }
         else
         {
            ww.LockLockableMoves = false;
            error = BuildExpectedError("str`, `hex", ww.GetConcatedNWords(3).GetValue());
            return false;
         }

         return true;
      }
   }
}
