using singarule_lib.interfaces;
using System.Text;

namespace singarule_lib.implementations.expectors
{
   public class CNameExpector : CGenericExpector<string>
   {
      public CNameExpector()
      {

      }

      public override bool ExpectIt(ref IWordWalker ww, object additionalParam = null)
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
         return true;
      }
   }
}
