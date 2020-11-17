using singarule.models;
using System;
using System.IO;

namespace singarule
{
   class Program
   {
      static void Main(string[] args)
      {
         if (args.Length != 2)
         {
            Console.WriteLine($"{AppDomain.CurrentDomain.FriendlyName} ruleFileName fileToScan");
            return;
         }

         string ruleFileName = args[0];
         string fileToScanName = args[1];

         string ruleContent = File.ReadAllText(ruleFileName);
         byte[] fileToScanContent = File.ReadAllBytes(fileToScanName);

         SingaRule rule = SingaRule.Compile(ruleContent);
         if (rule.Scan(fileToScanContent))
         {
            Console.WriteLine($"Rule `{rule.name}` triggered on `{fileToScanName}` file");
         }
         else
         {
            Console.Write($"Rule `{rule.name}` found nothing");
         }
      }
   }
}
