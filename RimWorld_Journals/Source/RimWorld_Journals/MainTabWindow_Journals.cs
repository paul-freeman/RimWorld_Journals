using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using UnityEngine;

namespace Journals
{
    public class MainTabWindow_Journals : MainTabWindow
    {
        private const float FactionColorRectSize = 15f;
        private const float FactionColorRectGap = 10f;
        private const float RowMinHeight = 80f;
        private const float LabelRowHeight = 50f;
        private const float TypeColumnWidth = 100f;
        private const float NameColumnWidth = 220f;
        private const float RelationsColumnWidth = 100f;
        private const float NameLeftMargin = 15f;

        private Vector2 scrollPosition = Vector2.zero;
        private float scrollViewHeight;
        public String filter = "";
        public int ticker = 0;

        public override Vector2 RequestedTabSize
        {
            get
            {
                return new Vector2(1000f, 500f);
            }
        }

        public override void DoWindowContents(Rect inRect)
        {
            base.DoWindowContents(inRect);
            Text.Font = GameFont.Medium;
            Widgets.Label(inRect, "Journals");
            Rect position = new Rect(0f, 0f, inRect.width, inRect.height);
            GUI.BeginGroup(position);
            Text.Font = GameFont.Small;
            GUI.color = Color.white;
            Rect outRect = new Rect(0f, 50f, position.width, position.height - 50f);

            Rect rect = new Rect(0f, 0f, position.width - 16f, this.scrollViewHeight);

            Widgets.BeginScrollView(outRect, ref this.scrollPosition, rect);

            float num = 0f;
            List<Tale> currentTales = Find.TaleManager.AllTalesListForReading;
            currentTales.Sort((x,y) => x.AgeTicks.CompareTo(y.AgeTicks));
            foreach (Tale tale in currentTales)
            {
                Rect rect2 = new Rect(0f, num, rect.width, 30f);
                if (Mouse.IsOver(rect2))
                {
                    GUI.DrawTexture(rect2, TexUI.HighlightTex);
                }
                Widgets.Label(rect2, tale.ToString());
                num += 30f;
            }

            if (Event.current.type == EventType.Layout)
            {
                this.scrollViewHeight = num;
            }
            Widgets.EndScrollView();
            GUI.EndGroup();
        }
    }
}


