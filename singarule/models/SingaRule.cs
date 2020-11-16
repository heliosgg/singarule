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
      public string name { get; set; }
      public List<SingaSig> meta { get; set; }
      public List<ISingaSigState> sigs { get; set; }
      public List<SingaConditionOp> condition { get; set; }

      public static SingaRule Compile(string code)
      {
         IWordWalker ww = new CCharWalker();
         ww.Init(code);

         var langExpector = new CLanguageExpector();
         if(!langExpector.ExpectIt(ref ww))
         {
            PrintCompilationError(langExpector.error);
            return null;
         }

         return (SingaRule)langExpector.result;
      }

      static private void PrintCompilationError(string error) => Console.WriteLine("Error: " + error);
   }
}
