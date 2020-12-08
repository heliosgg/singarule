using singarule_lib.interfaces;
using System.Text;

namespace singarule_lib.implementations.expectors
{
   public class CStringSignatureExpector : CGenericExpector<byte[]>
   {
      public override bool ExpectIt(ref IWordWalker ww, object additionalParam = null)
      {
         var headExpector = new CExactWordExpector("str(\"");
         if (!headExpector.ExpectIt(ref ww))
         {
            error = headExpector.error;
            return false;
         }

         StringBuilder stringSig = new StringBuilder();
         var characterExpector = new CCharExpector();
         while (characterExpector.ExpectIt(ref ww))
         {
            stringSig.Append(characterExpector.result);
         }

         var tailExpector = new CExactWordExpector("\");");
         if (!tailExpector.ExpectIt(ref ww))
         {
            error = tailExpector.error;
            return false;
         }

         result = Encoding.UTF8.GetBytes(stringSig.ToString());

         return true;
      }
   }
}
