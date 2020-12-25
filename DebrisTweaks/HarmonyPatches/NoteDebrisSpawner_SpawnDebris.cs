using BeatSaberMarkupLanguage;
using HarmonyLib;
using UnityEngine;

namespace DebrisTweaks.HarmonyPatches
{
    [HarmonyPatch(typeof(NoteDebrisSpawner), "SpawnDebris")]
    internal class NoteDebrisSpawner_SpawnDebris
    {
        internal static bool Prefix()
        {
            return !Settings.instance.DisableDebris;
        }
    }

}