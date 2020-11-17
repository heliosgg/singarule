using singarule.models;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace singarule
{
   class Program
   {
      static void Main(string[] args)
      {
         if (args.Length != 1)
         {
            Console.WriteLine($"{AppDomain.CurrentDomain.FriendlyName} ruleFileName");
            return;
         }

         string ruleFileName = args[0];
         string ruleContent = File.ReadAllText(ruleFileName);

         SingaRule rule = SingaRule.Compile(ruleContent);
         string jsonRule = JsonSerializer.Serialize(rule);

         Console.Write(jsonRule);
      }
   }
}
