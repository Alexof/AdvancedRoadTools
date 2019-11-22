﻿using AdvancedRoadTools.Util;
using ColossalFramework.UI;
using UnityEngine;

namespace AdvancedRoadTools.UI
{
    public class ThreeRoundButton : UIButton
    {
        public RoadsOptionPanel baseBuildingWindow;
        public override void Start()
        {
            name = "ThreeRoundButton";
            text = "T";
            //atlas = SpriteUtilities.GetAtlas(Loader.m_atlasName2);
            //normalBgSprite = "CSUR_BUTTON";
            //hoveredBgSprite = "CSUR_BUTTON_S";
            //focusedBgSprite = "CSUR_BUTTON_S";
            //pressedBgSprite = "CSUR_BUTTON_S";
            //UISprite internalSprite = AddUIComponent<UISprite>();
            //internalSprite.atlas = SpriteUtilities.GetAtlas(Loader.m_atlasName);
            //internalSprite.spriteName = "RcButton";
            //internalSprite.relativePosition = new Vector3(0, 0);
            //internalSprite.width = 50f;
            //internalSprite.height = 50f;
            size = new Vector2(30f, 30f);
            zOrder = 11;
            eventClick += delegate (UIComponent component, UIMouseEventParameter eventParam)
            {
                if (AdvancedTools.instance.enabled == false)
                {
                    //base.Hide();
                    ToolBase currentTool = ToolsModifierControl.GetCurrentTool<ToolBase>();
                    if (currentTool != null)
                    {
                        NetTool netTool = currentTool as NetTool;
                        if (netTool.m_prefab != null)
                        {
                            AdvancedTools.m_netInfo = netTool.m_prefab;
                        }
                    }
                    ToolsModifierControl.SetTool<DefaultTool>();
                    AdvancedTools.instance.enabled = true;
                    AdvancedTools.m_step = 0;
                    AdvancedTools.rampMode = 0;
                    AdvancedTools.height = 0;
                }
                else
                {
                    ToolsModifierControl.SetTool<DefaultTool>();
                    AdvancedTools.instance.enabled = false;
                    AdvancedTools.m_step = 0;
                    AdvancedTools.height = 0;
                }
            };
        }
    }
}
