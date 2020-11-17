using singarule.implementations;
using singarule.implementations.expectors;
using singarule.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.models
{
   class SingaRule
   {
      public string name { get; set; }
      public Dictionary<string, SingaSig> meta { get; set; }
      public Dictionary<string, SingaState> sigs { get; set; }
      public ISingaExpression condition { get; set; }

      public static SingaRule Compile(string code)
      {
         IWordWalker ww = new CCharWalker();
         ww.Init(code);

         var langExpector = new CLanguageExpector();
         if(!langExpector.ExpectIt(ref ww))
         {
            PrintCompilationError(
               $"{langExpector.error}\n" +
               $"On line: `{ww.GetCurrentLine().GetValue()}`");
            return null;
         }

         return langExpector.result;
      }

      static private void PrintCompilationError(string error) => Console.WriteLine("Error: " + error);
   }
}
