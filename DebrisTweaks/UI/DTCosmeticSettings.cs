using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using BeatSaberMarkupLanguage.Components.Settings;
using System;

namespace DebrisTweaks
{
    class DTCosmeticSettings : BSMLResourceViewController
    {
        public override string ResourceName => "DebrisTweaks.Views.CosmeticMenu.bsml";

        internal bool _MonochromeColors = Settings.instance.MonochromeColors;
        internal bool _OverrideLifespan = Settings.instance.OverrideLifespan;
        internal float _DebrisLifespan = Settings.instance.DebrisLifespan;
        internal float _DebrisScale = Settings.instance.Scale;

        [UIComponent("element-lifespan")]
        private IncrementSetting lifespanSetting;

        [UIValue("override-lifespan")]
        internal bool OverrideLifespan
        {
            get => _OverrideLifespan;
            set
            {
                _OverrideLifespan = value;
                Settings.instance.OverrideLifespan = value;
                if (lifespanSetting) lifespanSetting.interactable = value;
            }
        }

        [UIValue("mono-colors")]
        internal bool MonochromeColors
        {
            get => _MonochromeColors;
            set
            {
                _MonochromeColors = value;
                Settings.instance.MonochromeColors = value;
            }
        }

        [UIValue("lifespan")]
        internal float DebrisLifespan
        {
            get => _DebrisLifespan;
            set
            {
                _DebrisLifespan = value;
                Settings.instance.DebrisLifespan = value;
                NotifyPropertyChanged();
            }
        }

        [UIValue("debris-scale")]
        internal float DebrisScale
        {
            get => _DebrisScale;
            set
            {
                _DebrisScale = value;
                Settings.instance.Scale = value;
                NotifyPropertyChanged();
            }
        }

    }
}
