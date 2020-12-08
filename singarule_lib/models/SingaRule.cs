using singarule_lib.implementations;
using singarule_lib.implementations.expectors;
using singarule_lib.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace singarule_lib.models
{
   public class SingaError
   {
      public string ErrorMessage { get; set; } = null;
      public IWordWalker ww { get; set; } = null;
      public SingaRule rule = null;
   }

   public class SingaRule
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

      public static SingaError Compile(string code)
      {
         SingaError res = new SingaError();

         IWordWalker ww = new CCharWalker();
         ww.Init(code);

         var langExpector = new CLanguageExpector();
         if(langExpector.ExpectIt(ref ww))
         {
            res.rule = langExpector.result;
         }
         else
         {
            res.ErrorMessage =
               $"{langExpector.error}\n" +
               Localization.OnLine + $": `{ww.GetCurrentLine().GetValue()}`";
         }

         res.ww = ww;

         return res;
      }

      static private void PrintCompilationError(string error) => Console.WriteLine($"[{Localization.CompilationError}]: " + error);
      static private void PrintScanningError(string error) => Console.WriteLine($"[{Localization.ScanningError}]: " + error);
   }
}
