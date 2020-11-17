using singarule.implementations;
using singarule.implementations.expectors;
using singarule.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace singarule.models
{
   class SingaRule
   {
      public string name { get; set; }
      public Dictionary<string, SingaSig> meta { get; set; }
      public Dictionary<string, SingaState> sigs { get; set; }
      public ISingaExpression condition { get; set; }

      public void Reset() => sigs.Values.ToList().ForEach(x => x.Reset());

      public bool Scan(byte[] bytesToScan)
      {
         Reset();
         Enumerable.Range(0, bytesToScan.Length).ToList().ForEach(i
            => sigs.Values.ToList().ForEach(x => x.Process(bytesToScan, i)));

         return condition.Eval();
      }

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

      static private void PrintCompilationError(string error) => Console.WriteLine("[Compilation error]: " + error);
      static private void PrintScanningError(string error) => Console.WriteLine("[Scanning error]: " + error);
   }
}
