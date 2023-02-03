using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace GarbagePlugins
{
    [BepInPlugin("com.rhythmdr.fpscounterrd", "FPSCounterRD", "1.0.0")]
    [BepInProcess("Rhythm Doctor.exe")]
    public class Plugin : BaseUnityPlugin
    {
        private static ConfigEntry<bool> configShowFPS;

        private void Awake()
        {
            configShowFPS = Config.Bind("General", "ShowFPS", true, "Shows FPS counter at the top left of the screen");

            if (configShowFPS.Value)
                Harmony.CreateAndPatchAll(typeof(ShowFPS));

            Logger.LogInfo($"Plugin is loaded!");
        }

        private void OnDestroy()
        {
            Harmony.UnpatchAll();
        }

        private static class ShowFPS
        {
            [HarmonyPostfix]
            [HarmonyPatch(typeof(scnGame), "Update")]
            public static void Postfix(scnGame __instance)
            {
                if (!RDC.debug){
                    __instance.debugText.gameObject.SetActive(true);
                    int num4 = Mathf.RoundToInt(1f / Time.unscaledDeltaTime);
                    __instance.debugText.text = "" + string.Format("<color=#ffffff>FPS:</color> <color={0}>{1}</color>", (object) (num4 < 30 ? "#ff0000" : (num4 < 50 ? "#ffff00" : "#00ff00")), (object) num4);
                    __instance.currentLevel.Update();
                }
            }
        }
    }
}
