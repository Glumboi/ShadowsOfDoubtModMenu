using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Il2Cpp;
using MelonLoader;

namespace ShadowsOfDoubtModMenu.Patches
{
    [HarmonyPatch(typeof(KeypadController))]
    internal class KeypadControllerPatches
    {
        public static bool alwaysCorrectCode = false;

        [HarmonyPatch("SubmitCode")]
        [HarmonyPrefix]
        private static void Prefix_SubmitCode(KeypadController __instance)
        {
            MelonLogger.Log($"Submitting code:");

            for (int i = 0; i < __instance.input.Count; i++)
            {
                MelonLogger.Log(__instance.input[i]);
            }
        }
    }
}