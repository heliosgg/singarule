using singarule_lib.implementations.expressions;
using singarule_lib.interfaces;
using singarule_lib.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace singarule_lib.implementations.expectors.condition
{
   class CAndsExpector : CGenericExpector<ISingaExpression>
   {
      public override bool ExpectIt(ref IWordWalker ww, object currentSingaRule = null)
      {
         if (currentSingaRule is null)
         {
            throw new ArgumentNullException();
         }

         List<string> sigNames = new List<string>();

         var andExpector = new CExactWordExpector("&&");
         var existingSigNameExpector = new CExistingSigNameExpector();
         var spaceSkipper = new CWhiteSpaceSkipper();

         do
         {
            if (!existingSigNameExpector.ExpectIt(ref ww, currentSingaRule))
            {
               error = existingSigNameExpector.error;
               return false;
            }

            sigNames.Add(existingSigNameExpector.result);
            spaceSkipper.ExpectIt(ref ww);

         } while (andExpector.ExpectIt(ref ww) && spaceSkipper.ExpectIt(ref ww));

         result = new CAndExpression();
         result.Expressions = sigNames.Select(x => new CStateExpression(((SingaRule)currentSingaRule).sigs[x])).ToList<ISingaExpression>();
         return true;
      }
   }
}
