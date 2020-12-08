using singarule_lib;
using singarule_lib.models;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace singarule
{
   class Program
   {
      static void Main(string[] args)
      {
         if (args.Length != 2)
         {
            Console.WriteLine($"{AppDomain.CurrentDomain.FriendlyName} ruleFileName fileMaskToScan");
            return;
         }

         string ruleFileName = args[0];
         string fileMaskToScan = args[1];

         string ruleContent = File.ReadAllText(ruleFileName);

         SingaError compilerResult = SingaRule.Compile(ruleContent);
         Directory.GetFiles(Directory.GetCurrentDirectory(), fileMaskToScan).ToList().ForEach(f =>
         {
            string normalizedPath = Path.GetFullPath(f);
            byte[] fileToScanContent = File.ReadAllBytes(normalizedPath);

            if (compilerResult.rule.Scan(fileToScanContent))
            {
               Console.WriteLine($"`{compilerResult.rule.name}` {Localization.ResourceManager.GetString("TriggeredOn", CultureInfo.GetCultureInfo("en"))} `{normalizedPath}`");
            }
         });
      }
   }
}
