﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Graphics.UserInterface;
using osu.Game.Rulesets;

namespace osu.Game.Overlays.BeatmapListing
{
    public class BeatmapSearchRulesetFilterRow : BeatmapSearchFilterRow<RulesetInfo>
    {
        public BeatmapSearchRulesetFilterRow()
            : base(@"Mode")
        {
        }

        protected override BeatmapSearchFilter CreateFilter() => new RulesetFilter();

        private class RulesetFilter : BeatmapSearchFilter
        {
            [BackgroundDependencyLoader]
            private void load(RulesetStore rulesets)
            {
                AddItem(new RulesetInfo
                {
                    Name = @"Any"
                });

                foreach (var r in rulesets.AvailableRulesets)
                    AddItem(r);
            }

            protected override TabItem<RulesetInfo> CreateTabItem(RulesetInfo value) => new RulesetTabItem(value);

            private class RulesetTabItem : FilterTabItem
            {
                public RulesetTabItem(RulesetInfo value)
                    : base(value)
                {
                }

                protected override string GetText(RulesetInfo value) => value.Name;
            }
        }
    }
}
