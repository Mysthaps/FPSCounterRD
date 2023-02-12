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
    [BepInPlugin("com.rhythmdr.fpscounterrd", "FPSCounterRD", "1.1.0")]
    [BepInProcess("Rhythm Doctor.exe")]
    public class Plugin : BaseUnityPlugin
    {
        private static ConfigEntry<ShowFpsOptions> configShowFPS;

        private enum ShowFpsOptions { Enabled, Legacy, Disabled }

        private void Awake()
        {
            configShowFPS = Config.Bind("General", "ShowFPS", ShowFpsOptions.Enabled, "Shows FPS counter at the top left of the screen");

            if (configShowFPS.Value != ShowFpsOptions.Disabled)
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

                    switch (configShowFPS.Value)
                    {
                        case ShowFpsOptions.Enabled:
                            if (scnGame.fps == 0.0) scnGame.fps = 1f / Time.unscaledDeltaTime;
                            scnGame.fps = scnGame.fps * 0.99f + (1f / Time.unscaledDeltaTime) * 0.01f;
                            __instance.debugText.text = "" + string.Format("<color=#ffffff>FPS:</color> <color={0}>{1}</color>", (object) (scnGame.fps < 30 ? "#ff0000" : (scnGame.fps < 50 ? "#ffff00" : "#00ff00")), (object) (int) scnGame.fps);
                            break;
                        case ShowFpsOptions.Legacy:
                            int num = Mathf.RoundToInt(1f / Time.unscaledDeltaTime);
                            __instance.debugText.text = "" + string.Format("<color=#ffffff>FPS:</color> <color={0}>{1}</color>", (object) (num < 30 ? "#ff0000" : (num < 50 ? "#ffff00" : "#00ff00")), (object) num);
                            break;
                    }
                    
                    __instance.currentLevel.Update();
                }
            }
        }
    }
}
