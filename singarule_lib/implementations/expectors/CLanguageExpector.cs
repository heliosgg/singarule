﻿using singarule_lib.interfaces;
using singarule_lib.models;

namespace singarule_lib.implementations.expectors
{
   public class CLanguageExpector : CGenericExpector<SingaRule>
   {
      public override bool ExpectIt(ref IWordWalker ww, object additionalParam = null)
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
         if (!ruleExpector.ExpectIt(ref ww, result))
         {
            error = ruleExpector.error;
            return false;
         }
         result = ruleExpector.result;

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
