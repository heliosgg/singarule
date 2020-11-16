using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.lexpectors
{
   class CNameExpector : CGenericExpector<string>
   {
      public CNameExpector()
      {

      }

      public override bool ExpectIt(ref IWordWalker ww)
      {
         if (!ExpectString(ref ww))
         {
            return false;
         }

         StringBuilder resultName = new StringBuilder("");

         CLetterExpector letterExpector = new CLetterExpector();
         if (!letterExpector.ExpectIt(ref ww))
         {
            error = letterExpector.error;
            return false;
         }
         resultName.Append(letterExpector.result);

         CCharExpector charExpector = new CCharExpector();
         while (charExpector.ExpectIt(ref ww))
         {
            resultName.Append(charExpector.result);
         }

         result = resultName.ToString();
         ww.LockableMove();
         return true;
      }
   }
}
