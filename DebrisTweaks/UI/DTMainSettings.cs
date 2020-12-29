using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using BS_Utils.Utilities;
using BeatSaberMarkupLanguage.Components.Settings;
using UnityEngine;

namespace DebrisTweaks
{
    class DTMainSettings : BSMLResourceViewController
    {
        public override string ResourceName => "DebrisTweaks.Views.MainMenu.bsml";

        internal bool _EnableTweaks = Settings.instance.EnableTweaks;
        internal bool _DisableDebris = Settings.instance.DisableDebris;

        [UIComponent("element-nospawn")]
        private ToggleSetting nospawnSetting;

        [UIValue("master-enabled")]
        internal bool EnableTweaks
        {
            get => _EnableTweaks;
            set => _EnableTweaks = value;
        }

        [UIValue("nospawn")]
        internal bool DisableDebris
        {
            get => _DisableDebris;
            set
            {
                _DisableDebris = value;
                Settings.instance.DisableDebris = value;
                NotifyPropertyChanged();
            }
        }

        //Actions

        [UIAction("enabled-onchange")]
        internal void _EnableToggleAction(bool newval)
        {
            Settings.instance.EnableTweaks = newval;
            DTFlowCoordinator flowCord = UISingleton.flowCoordinator;
            flowCord.ApplyResponsiveVisibility(true);
            if (nospawnSetting) nospawnSetting.interactable = newval;
            if (newval) Plugin.ApplyPatches();
            else Plugin.Disable();
        }

        [UIAction("reset")]
        internal void ResetSettings()
        {   
            _DisableDebris = false;
            nospawnSetting.Value = false;
            Settings.instance.EnableGravity = true;
            Settings.instance.DisableDebris = false;
            Settings.instance.OverrideLifespan = false;
            Settings.instance.MonochromeColors = false;
            Settings.instance.FreezeRotations = false;
            Settings.instance.DebrisLifespan = 2;
            Settings.instance.Velocity = 1;
            Settings.instance.Scale = 1;
            Settings.instance.Drag = 0;
            UISingleton.flowCoordinator.RefreshCache();
            UISingleton.flowCoordinator.ApplyResponsiveVisibility(true);
        }

        [UIAction("test-debris")]
        internal void TestDebris()
        {
            Object[] levelStartArray = Resources.FindObjectsOfTypeAll(typeof(SimpleLevelStarter));
            for (int i = 0; i < levelStartArray.Length; i++)
            {
                SimpleLevelStarter lstart = (SimpleLevelStarter)levelStartArray[i];
                if (lstart.gameObject.name == "PerformanceTestLevelButton") 
                {
                    Logger.log.Info("Starting debris test...");
                    lstart.StartLevel();
                    return;
                } 
            }
        }

    }
}
