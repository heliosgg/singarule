using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.lexpectors
{
   class CNameExpector : CGenericExpector
   {
      public CNameExpector()
      {

      }

      public override bool ExpectIt(ref IWordWalker ww, ref SingaRule resultRule)
      {
         if (!ExpectString(ref ww))
         {
            return false;
         }

         StringBuilder resultName = new StringBuilder("");

         CLetterExpector letterExpector = new CLetterExpector();
         if (!letterExpector.ExpectIt(ref ww, ref resultRule))
         {
            error = letterExpector.error;
            return false;
         }
         resultName.Append(letterExpector.result);

         CCharExpector charExpector = new CCharExpector();
         while (charExpector.ExpectIt(ref ww, ref resultRule))
         {
            resultName.Append(charExpector.result);
         }

         result = resultName.ToString();
         ww.Move();
         return true;
      }
   }
}
