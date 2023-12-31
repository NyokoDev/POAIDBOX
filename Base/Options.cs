using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using AlgernonCommons.UI;
using ColossalFramework.UI;
using UnityEngine;
using System.Diagnostics;
using POAIDBOX.Structure;
using System.Diagnostics.Eventing.Reader;

namespace POAIDBOX
{
    /// <summary>
    /// The mod's settings options panel.
    /// </summary>
    public sealed class OptionsPanel : OptionsPanelBase
    {
        // Layout constants.
        private const float Margin = 5f;
        private const float LeftMargin = 24f;
        private const float GroupMargin = 40f;
        private const float LabelWidth = 40f;
        private const float TabHeight = 20f;

        /// <summary>
        /// Performs on-demand panel setup.
        /// </summary>
        protected override void Setup()
        {
            autoLayout = false;
            float currentY = Margin;
            m_BackgroundSprite = "UnlockingPanel";

            UISprite image2Sprite = this.AddUIComponent<UISprite>();

            image2Sprite.height = 1000f;
            image2Sprite.relativePosition = new Vector3(0f, -50f);
            image2Sprite.width = 1000f;
            image2Sprite.atlas = UITextures.LoadSingleSpriteAtlas("..\\Resources\\bck");
            image2Sprite.spriteName = "normal";
            image2Sprite.zOrder = 1;



            UILabel miscellanous = UILabels.AddLabel(this, LabelWidth, currentY, "Procedural Objects | AidBox", textScale: 0.9f, alignment: UIHorizontalAlignment.Center);
            currentY += 31f;
            UILabel miscellanous2 = UILabels.AddLabel(this, LabelWidth, currentY, "This build resets two settings files in an attempt to fix null references.", textScale: 1.1f, alignment: UIHorizontalAlignment.Center);
            currentY += 30f;

            UILabel miscellanous3 = UILabels.AddLabel(this, LabelWidth, currentY, "Be mindful of making a backup of your city beforehand.", textScale: 1.1f, alignment: UIHorizontalAlignment.Center);
            currentY += 30f;

            bool POFound = ModUtils.IsModEnabled("proceduralobjects");


                

            UILabel enable = UILabels.AddLabel(this, LabelWidth, currentY, "Looking for PO", textScale: 1.3f, alignment: UIHorizontalAlignment.Center);
            currentY += 35f;
            if (POFound)
            {
                enable.text = "Procedural Objects has been found.";
                
            }
            else
            enable.text = "Procedural Objects has not been found.";


            UIButton procedurebutton = UIButtons.AddButton(this, LabelWidth, currentY, "Start procedure");
            currentY += 50f;
            procedurebutton.eventClicked += (sender, args) =>
            {
                Mechanism.Main();
            };

            UIButton supportbutton = UIButtons.AddSmallerButton(this, LabelWidth, currentY, "Support");
            currentY += 50f;
            supportbutton.eventClicked += (sender, args) =>
            {
                Process.Start("https://discord.gg/gdhyhfcj7A");
            };





            UILabel version = UILabels.AddLabel(this, LabelWidth, currentY, Assembly.GetExecutingAssembly().GetName().Version.ToString(), textScale: 0.7f, alignment: UIHorizontalAlignment.Center);



        }
    }
}
