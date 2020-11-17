﻿using singarule.interfaces;
using singarule.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations.expectors
{
   class CExistingSigNameExpector : CNameExpector
   {
      public override bool ExpectIt(ref IWordWalker ww, object currentSingaRule = null)
      {
         if (currentSingaRule is null)
         {
            throw new ArgumentNullException();
         }

         if (!base.ExpectIt(ref ww))
         {
            return false;
         }

         if (!((SingaRule)currentSingaRule).sigs.ContainsKey(result))
         {
            error = BuildExpectedError("existing signature name", result);
            return false;
         }

         return true;
      }
   }
}
