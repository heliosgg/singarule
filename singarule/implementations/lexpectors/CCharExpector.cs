using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace singarule.implementations.lexpectors
{
   class CCharExpector : CStringOfCharsExpector
   {
      public CCharExpector() : base("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890") { }
   }
}
