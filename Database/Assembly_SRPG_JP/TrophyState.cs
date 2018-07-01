﻿// Decompiled with JetBrains decompiler
// Type: SRPG.TrophyState
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85BFDF7F-5712-4D45-9CD6-3465C703DFDF
// Assembly location: S:\Desktop\Assembly-CSharp.dll

using System;

namespace SRPG
{
  public class TrophyState
  {
    public int[] Count = new int[0];
    public string iname;
    public bool IsEnded;
    public int StartYMD;
    public DateTime RewardedAt;
    public bool IsDirty;
    public TrophyParam Param;
    public bool IsSending;

    public bool IsCompleted
    {
      get
      {
        if (this.Param == null || this.Count.Length < this.Param.Objectives.Length)
          return false;
        for (int index = 0; index < this.Param.Objectives.Length && index < this.Count.Length; ++index)
        {
          if (this.Count[index] < this.Param.Objectives[index].RequiredCount)
            return false;
        }
        return true;
      }
    }
  }
}