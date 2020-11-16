﻿using singarule.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace singarule.implementations
{
   class CCharWalker : IWordWalker
   {
      public bool LockLockableMoves { get; set; }

      private string _data;
      private int _currentIdx;
      private int _lockedMoves;

      public void Init(string data)
      {
         LockLockableMoves = false;
         _currentIdx = 0;
         _lockedMoves = 0;
         this._data = data;
      }

      public SingaWord GetNextWord(int offset = 1)
      {
         int IdxToReturn = _currentIdx + offset;

         if (IdxToReturn < 0)
         {
            return new SingaWord(SingaWordType.INVALUD);
         }

         if (IdxToReturn == _data.Length)
         {
            return new SingaWord(SingaWordType.EOF);
         }

         if (IdxToReturn > _data.Length)
         {
            return new SingaWord(SingaWordType.INVALUD);
         }

         return new SingaWord(Convert.ToString(_data[IdxToReturn]));
      }

      public SingaWord GetConcatedNWords(int n, int offset = 0)
      {
         StringBuilder result = new StringBuilder("");

         for (int i = offset; i < offset + n; i++)
         {
            var currentWord = GetNextWord(i);
            if (currentWord.IsStr() == false)
               break;

            result.Append(currentWord.GetValue());
         }

         return new SingaWord(result.ToString());
      }

      public bool Move(int offset = 1)
      {
         int NewIdx = _currentIdx + offset;

         if (NewIdx > _data.Length)
            NewIdx = _data.Length;

         if (_currentIdx < 0)
            NewIdx = 0;

         _currentIdx = NewIdx;
         return true;
      }

      public SingaWord GetCurrentLine()
      {
         int LineStart = 0;
         for (int i = _currentIdx; i >= 0; i--)
         {
            if (_data[i].Equals(Environment.NewLine))
            {
               LineStart = i;
               break;
            }
         }

         StringBuilder result = new StringBuilder("");
         while (  LineStart < _data.Length
               || Convert.ToString(_data[LineStart]).Equals(Environment.NewLine) == false
               )
         {
            result.Append(_data[LineStart]);
         }

         return new SingaWord(result.ToString());
      }
   }
}
