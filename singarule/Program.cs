using singarule.models;
using System;
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

         SingaRule rule = SingaRule.Compile(ruleContent);
         Directory.GetFiles(Directory.GetCurrentDirectory(), fileMaskToScan).ToList().ForEach(f =>
         {
            string normalizedPath = Path.GetFullPath(f);
            byte[] fileToScanContent = File.ReadAllBytes(normalizedPath);

            if (rule.Scan(fileToScanContent))
            {
               Console.WriteLine($"`{rule.name}` triggered on `{normalizedPath}`");
            }
         });
      }
   }
}
