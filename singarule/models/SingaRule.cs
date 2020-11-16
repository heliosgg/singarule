using singarule.implementations;
using singarule.implementations.lexpectors;
using singarule.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.models
{
   enum SingaConditionOp : uint
   {
      OR = 0,
      AND = 1
   }

   class SingaRule
   {
      public bool valid { get; set; } = false;
      public string name { get; set; }
      public List<ISingaSigState> meta { get; set; }
      public List<ISingaSigState> sigs { get; set; }
      public List<SingaConditionOp> condition { get; set; }

      public static SingaRule Compile(string code)
      {
         SingaRule result = new SingaRule();

         IWordWalker ww = new CCharWalker();
         ww.Init(code);

         var spaceSkipper = new CWhiteSpaceSkipper();

         spaceSkipper.ExpectIt(ref ww, ref result);

         var rExpector = new CExactWordExpector(new SingaWord("r"));
         if (!rExpector.ExpectIt(ref ww, ref result))
         {
            PrintCompilationError(rExpector.error);
            return result;
         }

         spaceSkipper.ExpectIt(ref ww, ref result);

         var genericNameExpector = new CNameExpector();
         if (!genericNameExpector.ExpectIt(ref ww, ref result))
         {
            PrintCompilationError(genericNameExpector.error);
            return result;
         }
         result.name = genericNameExpector.result;

         spaceSkipper.ExpectIt(ref ww, ref result);

         var openBraceExpector = new CExactWordExpector(new SingaWord("{"));
         if (!openBraceExpector.ExpectIt(ref ww, ref result))
         {
            PrintCompilationError(openBraceExpector.error);
            return result;
         }

         spaceSkipper.ExpectIt(ref ww, ref result);

         // TODO: expect rule

         spaceSkipper.ExpectIt(ref ww, ref result);

         var closeBraceExpector = new CExactWordExpector(new SingaWord("}"));
         if (!closeBraceExpector.ExpectIt(ref ww, ref result))
         {
            PrintCompilationError(closeBraceExpector.error);
            return result;
         }

         spaceSkipper.ExpectIt(ref ww, ref result);

         var eofExpector = new CEOFExpector();
         if (!eofExpector.ExpectIt(ref ww, ref result))
         {
            PrintCompilationError(closeBraceExpector.error);
            return result;
         }

         result.valid = true;
         return result;
      }

      static private void PrintCompilationError(string error) => Console.WriteLine("Error: " + error);
   }
}
