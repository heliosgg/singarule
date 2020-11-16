using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.interfaces
{
   enum SingaWordType : int
   { 
      STR = 0,
      EOF = 1,
      INVALUD = 2
   }
   class SingaWord
   {
      public SingaWord(string value)
      {
         this.value = value;
         this.type = SingaWordType.STR;
      }

      public SingaWord(char value) : this(value.ToString()) { }

      public SingaWord(SingaWordType type)
      {
         this.value = "";

         if (type == SingaWordType.EOF)
         {
            this.value = "EOF";
         }

         this.type = type;
      }

      public bool Equals(SingaWord sw) => this.value.Equals(sw.value) && this.type == sw.type;

      public bool IsStr() => type == SingaWordType.STR;
      public bool IsEof() => type == SingaWordType.EOF;
      public bool IsValid() => type != SingaWordType.INVALUD;
      public string GetValue() => value;

      private string value;
      private SingaWordType type;
   }

   interface IWordWalker
   {
      void Init(string data);
      SingaWord GetNextWord(int offset = 1);
      SingaWord GetConcatedNWords(int n, int offset = 0);
      SingaWord GetCurrentWord() => GetNextWord(0);
      SingaWord GetCurrentLine();
      bool Move(int offset = 1);
   }
}
