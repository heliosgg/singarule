using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.lexpectors
{
   class CLanguageExpector : CGenericExpector<SingaRule>
   {
      public override bool ExpectIt(ref IWordWalker ww)
      {
         result = new SingaRule();

         var spaceSkipper = new CWhiteSpaceSkipper();

         spaceSkipper.ExpectIt(ref ww);

         var rExpector = new CExactWordExpector("r");
         if (!rExpector.ExpectIt(ref ww))
         {
            error = rExpector.error;
            return false;
         }

         spaceSkipper.ExpectIt(ref ww);

         var genericNameExpector = new CNameExpector();
         if (!genericNameExpector.ExpectIt(ref ww))
         {
            error = genericNameExpector.error;
            return false;
         }
         result.name = genericNameExpector.result.ToString();

         spaceSkipper.ExpectIt(ref ww);

         var openBraceExpector = new CExactWordExpector("{");
         if (!openBraceExpector.ExpectIt(ref ww))
         {
            error = openBraceExpector.error;
            return false;
         }

         spaceSkipper.ExpectIt(ref ww);

         var ruleExpector = new CRuleExpector();
         if (!ruleExpector.ExpectIt(ref ww))
         {
            error = ruleExpector.error;
            return false;
         }

         spaceSkipper.ExpectIt(ref ww);

         var closeBraceExpector = new CExactWordExpector("}");
         if (!closeBraceExpector.ExpectIt(ref ww))
         {
            error = closeBraceExpector.error;
            return false;
         }

         spaceSkipper.ExpectIt(ref ww);

         var eofExpector = new CEOFExpector();
         if (!eofExpector.ExpectIt(ref ww))
         {
            error = closeBraceExpector.error;
            return false;
         }

         return true;
      }
   }
}
