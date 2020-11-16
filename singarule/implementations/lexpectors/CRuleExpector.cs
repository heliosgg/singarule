using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.lexpectors
{
   class CRuleExpector : CGenericExpector
   {
      public override bool ExpectIt(ref IWordWalker ww, ref SingaRule resultRule)
      {
         var metaStringExpector = new CExactWordExpector(new SingaWord("meta"));
         if (!metaStringExpector.ExpectIt(ref ww, ref resultRule))
         {
            error = metaStringExpector.error;
            return false;
         }

         var spaceSkipper = new CWhiteSpaceSkipper();

         spaceSkipper.ExpectIt(ref ww, ref resultRule);

         var openBraceExpector = new CExactWordExpector(new SingaWord("{"));
         if (!openBraceExpector.ExpectIt(ref ww, ref resultRule))
         {
            error = openBraceExpector.error;
            return false;
         }

         spaceSkipper.ExpectIt(ref ww, ref resultRule);

         // TODO: expect meta

         spaceSkipper.ExpectIt(ref ww, ref resultRule);

         var closeBraceExpector = new CExactWordExpector(new SingaWord("}"));
         if (!closeBraceExpector.ExpectIt(ref ww, ref resultRule))
         {
            error = closeBraceExpector.error;
            return false;
         }

         var sigsStringExpector = new CExactWordExpector(new SingaWord("sigs"));
         if (!sigsStringExpector.ExpectIt(ref ww, ref resultRule))
         {
            error = sigsStringExpector.error;
            return false;
         }

         spaceSkipper.ExpectIt(ref ww, ref resultRule);

         if (!openBraceExpector.ExpectIt(ref ww, ref resultRule))
         {
            error = openBraceExpector.error;
            return false;
         }

         spaceSkipper.ExpectIt(ref ww, ref resultRule);

         // TODO: expect sigs

         spaceSkipper.ExpectIt(ref ww, ref resultRule);

         if (!closeBraceExpector.ExpectIt(ref ww, ref resultRule))
         {
            error = closeBraceExpector.error;
            return false;
         }

         spaceSkipper.ExpectIt(ref ww, ref resultRule);

         var condStringExpector = new CExactWordExpector(new SingaWord("cond"));
         if (!condStringExpector.ExpectIt(ref ww, ref resultRule))
         {
            error = condStringExpector.error;
            return false;
         }

         spaceSkipper.ExpectIt(ref ww, ref resultRule);

         if (!openBraceExpector.ExpectIt(ref ww, ref resultRule))
         {
            error = openBraceExpector.error;
            return false;
         }

         spaceSkipper.ExpectIt(ref ww, ref resultRule);

         // TODO: expect cond

         spaceSkipper.ExpectIt(ref ww, ref resultRule);

         if (!closeBraceExpector.ExpectIt(ref ww, ref resultRule))
         {
            error = closeBraceExpector.error;
            return false;
         }

         return true;
      }
   }
}
