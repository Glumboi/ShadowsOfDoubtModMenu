using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2Cpp;
using HarmonyLib;
using MelonLoader;

namespace ShadowsOfDoubtModMenu.Patches
{
    [HarmonyPatch(typeof(GameplayController))]
    internal class GameplayControllerPatches
    {
        public static GameplayController instance;
        public static int lockpicksToAdd;
        public static int moneyToAdd;
        public static int socialCreditsToAdd;

        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        private static void Postfix_Awake(GameplayController __instance)

        {
            MelonLogger.Msg("GameplayController awake!");
            instance = __instance;
        }
    }
}