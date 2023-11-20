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
        public static int lockpicksToSet;
        public static int moneyToSet;
        public static int socialCreditsToSet;
        public static bool lockMoney = false; 
        public static bool lockSocialCredits = false;
        public static bool lockLockpicks = false;

        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        private static void Postfix_Awake(GameplayController __instance)
        {
            MelonLogger.Msg("GameplayController awake!");
            instance = __instance;
        }
    }
}