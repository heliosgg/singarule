using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.expectors
{
   class CLetterExpector : CStringOfCharsExpector
   {
      public CLetterExpector() : base("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ") { }
   }
}
