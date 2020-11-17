using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.expectors
{
   class CRuleExpector : CGenericExpector<SingaRule>
   {
      public override bool ExpectIt(ref IWordWalker ww)
      {
         var metaStringExpector = new CExactWordExpector("meta");
         if (!metaStringExpector.ExpectIt(ref ww))
         {
            error = metaStringExpector.error;
            return false;
         }

         var spaceSkipper = new CWhiteSpaceSkipper();

         spaceSkipper.ExpectIt(ref ww);

         var openBraceExpector = new CExactWordExpector("{");
         if (!openBraceExpector.ExpectIt(ref ww))
         {
            error = openBraceExpector.error;
            return false;
         }

         spaceSkipper.ExpectIt(ref ww);

         var metaExpector = new CMetaExpector();
         if (!metaExpector.ExpectIt(ref ww))
         {
            error = metaExpector.error;
            return false;
         }

         spaceSkipper.ExpectIt(ref ww);

         var closeBraceExpector = new CExactWordExpector("}");
         if (!closeBraceExpector.ExpectIt(ref ww))
         {
            error = closeBraceExpector.error;
            return false;
         }

         var sigsStringExpector = new CExactWordExpector("sigs");
         if (!sigsStringExpector.ExpectIt(ref ww))
         {
            error = sigsStringExpector.error;
            return false;
         }

         spaceSkipper.ExpectIt(ref ww);

         if (!openBraceExpector.ExpectIt(ref ww))
         {
            error = openBraceExpector.error;
            return false;
         }

         spaceSkipper.ExpectIt(ref ww);

         // TODO: expect sigs

         spaceSkipper.ExpectIt(ref ww);

         if (!closeBraceExpector.ExpectIt(ref ww))
         {
            error = closeBraceExpector.error;
            return false;
         }

         spaceSkipper.ExpectIt(ref ww);

         var condStringExpector = new CExactWordExpector("cond");
         if (!condStringExpector.ExpectIt(ref ww))
         {
            error = condStringExpector.error;
            return false;
         }

         spaceSkipper.ExpectIt(ref ww);

         if (!openBraceExpector.ExpectIt(ref ww))
         {
            error = openBraceExpector.error;
            return false;
         }

         spaceSkipper.ExpectIt(ref ww);

         // TODO: expect cond

         spaceSkipper.ExpectIt(ref ww);

         if (!closeBraceExpector.ExpectIt(ref ww))
         {
            error = closeBraceExpector.error;
            return false;
         }

         return true;
      }
   }
}
