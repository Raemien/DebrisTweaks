using BeatSaberMarkupLanguage;
using HarmonyLib;
using UnityEngine;

namespace DebrisTweaks.HarmonyPatches
{
    [HarmonyPatch(typeof(NoteDebris), "Init")]
    internal class NoteDebris_Init
    {
        internal static void Prefix(NoteDebris __instance, ref ColorType colorType, ref Vector3 force, ref float lifeTime)
        {
            var config = Settings.instance;
            lifeTime = config.OverrideLifespan ? config.DebrisLifespan : lifeTime;
            colorType = config.MonochromeColors ? ColorType.None : colorType;
            force *= config.Velocity;
        }
        internal static void Postfix(NoteDebris __instance)
        {
            var config = Settings.instance;
            Rigidbody rbody = __instance.GetComponent<Rigidbody>();
            rbody.useGravity = config.EnableGravity;
            rbody.freezeRotation = config.FreezeRotations;
            rbody.drag *= config.Drag;
            __instance.transform.localScale = Vector3.one * config.Scale;
        }
    }

}