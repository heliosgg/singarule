using singarule_lib.implementations.expectors.condition;
using singarule_lib.interfaces;
using singarule_lib.models;
using System;
using System.Linq;

namespace singarule_lib.implementations.expectors
{
   public class CRuleExpector : CGenericExpector<SingaRule>
   {
      public override bool ExpectIt(ref IWordWalker ww, object additionalParam = null)
      {
         if (additionalParam is null)
         {
            throw new ArgumentNullException();
         }

         result = (SingaRule)additionalParam;

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
         result.meta = metaExpector.result.ToDictionary(x => x.Name, x => (SingaSig)x);

         spaceSkipper.ExpectIt(ref ww);

         var closeBraceExpector = new CExactWordExpector("}");
         if (!closeBraceExpector.ExpectIt(ref ww))
         {
            error = closeBraceExpector.error;
            return false;
         }

         spaceSkipper.ExpectIt(ref ww);

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

         var sigsExpector = new CSigsExpector();
         if (!sigsExpector.ExpectIt(ref ww))
         {
            error = sigsExpector.error;
            return false;
         }
         result.sigs = sigsExpector.result.ToDictionary(x => x.Name, x => x);

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

         var conditionExpector = new CConditionExpector();
         if (!conditionExpector.ExpectIt(ref ww, result))
         {
            error = conditionExpector.error;
            return false;
         }
         result.condition = conditionExpector.result;

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
