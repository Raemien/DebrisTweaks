using HarmonyLib;
using IPA;
using IPA.Config;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;

namespace DebrisTweaks
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        public const string assemblyName = "DebrisTweaks";
        static Harmony harmPatcher;

        [Init]
        public Plugin(IPALogger logger, [Config.Prefer("json")] IConfigProvider cfgProvider)
        {
            Logger.log = logger;
        }

        [OnEnable]
        public void Enable()
        {
            PersistentSingleton<Settings>.TouchInstance();
            PersistentSingleton<UISingleton>.TouchInstance();
            UISingleton.RegMenuButton();
            ApplyPatches();
        }

        public static void ApplyPatches() 
        {
            if (Settings.instance.EnableTweaks && harmPatcher == null)
            {
                harmPatcher = new Harmony("DebrisTweaks");
                harmPatcher.PatchAll();
            }
        }

        [OnDisable]
        public static void Disable()
        {
            harmPatcher.UnpatchAll();
            harmPatcher = null;
        }

    }
}