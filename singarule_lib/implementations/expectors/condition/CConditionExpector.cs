using singarule.implementations.expressions;
using singarule.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.expectors.condition
{
   class CConditionExpector : CGenericExpector<ISingaExpression>
   {
      public override bool ExpectIt(ref IWordWalker ww, object currentSingaRule = null)
      {
         if (currentSingaRule is null)
         {
            throw new ArgumentNullException();
         }

         result = new COrExpression();
         var orExpector = new CExactWordExpector("||");
         var andsExpector = new CAndsExpector();
         var spaceSkipper = new CWhiteSpaceSkipper();

         do
         {
            if (!andsExpector.ExpectIt(ref ww, currentSingaRule))
            {
               error = andsExpector.error;
               return false;
            }

            result.Expressions.Add(andsExpector.result);
            spaceSkipper.ExpectIt(ref ww);

         } while (orExpector.ExpectIt(ref ww) && spaceSkipper.ExpectIt(ref ww));

         spaceSkipper.ExpectIt(ref ww);

         var semicolonExpector = new CExactWordExpector(";");
         if (!semicolonExpector.ExpectIt(ref ww))
         {
            error = semicolonExpector.error;
            return false;
         }

         return true;
      }
   }
}
