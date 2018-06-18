﻿// Decompiled with JetBrains decompiler
// Type: SRPG.FlowNode_MultiPlayVersusType
// Assembly: Assembly-CSharp, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9BA76916-D0BD-4DB6-A90B-FE0BCC53E511
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using GR;

namespace SRPG
{
  [FlowNode.Pin(100, "Free", FlowNode.PinTypes.Input, 0)]
  [FlowNode.Pin(102, "Friend", FlowNode.PinTypes.Input, 0)]
  [FlowNode.Pin(103, "Check", FlowNode.PinTypes.Input, 0)]
  [FlowNode.Pin(104, "CheckBeginTower", FlowNode.PinTypes.Input, 0)]
  [FlowNode.Pin(105, "CheckTowerReceipt", FlowNode.PinTypes.Input, 0)]
  [FlowNode.Pin(200, "Out", FlowNode.PinTypes.Output, 0)]
  [FlowNode.Pin(201, "OK", FlowNode.PinTypes.Output, 0)]
  [FlowNode.Pin(202, "NG", FlowNode.PinTypes.Output, 0)]
  [FlowNode.NodeType("Multi/MultiPlayVersusType", 32741)]
  [FlowNode.Pin(101, "Tower", FlowNode.PinTypes.Input, 0)]
  public class FlowNode_MultiPlayVersusType : FlowNode
  {
    private readonly int FREE = 100;
    private readonly int TOWER = 101;
    private readonly int FRIEND = 102;
    private readonly int CHECK = 103;
    private readonly int CHECK_TOWER = 104;
    private readonly int CHECK_RECEIPT = 105;
    public VERSUS_TYPE type;

    public override void OnActivate(int pinID)
    {
      GameManager instance = MonoSingleton<GameManager>.Instance;
      if (pinID == this.FREE)
        GlobalVars.SelectedMultiPlayVersusType = VERSUS_TYPE.Free;
      else if (pinID == this.TOWER)
        GlobalVars.SelectedMultiPlayVersusType = VERSUS_TYPE.Tower;
      else if (pinID == this.FRIEND)
      {
        GlobalVars.SelectedMultiPlayVersusType = VERSUS_TYPE.Friend;
      }
      else
      {
        if (pinID == this.CHECK)
        {
          if (GlobalVars.SelectedMultiPlayVersusType == this.type)
          {
            if (this.type == VERSUS_TYPE.Tower)
            {
              if (instance.VersusTowerMatchBegin)
              {
                this.ActivateOutputLinks(201);
                return;
              }
            }
            else
            {
              this.ActivateOutputLinks(201);
              return;
            }
          }
          this.ActivateOutputLinks(202);
          return;
        }
        if (pinID == this.CHECK_TOWER)
        {
          if (instance.VersusTowerMatchBegin)
          {
            this.ActivateOutputLinks(201);
            return;
          }
          this.ActivateOutputLinks(202);
          return;
        }
        if (pinID == this.CHECK_RECEIPT)
        {
          if (instance.VersusTowerMatchReceipt)
          {
            this.ActivateOutputLinks(201);
            return;
          }
          this.ActivateOutputLinks(202);
          return;
        }
      }
      this.ActivateOutputLinks(200);
    }
  }
}