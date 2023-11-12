using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using static MelonLoader.MelonLogger;

namespace ShadowsOfDoubtModMenu.Patches
{
    [HarmonyPatch(typeof(Player))]
    internal class PlayerPatches
    {
        public static Player playerInstance;
        public static bool disableTresspassing;
        public static bool disableIllegalActivities;

        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        private static void Postfix_Awake(Player __instance)

        {
            MelonLogger.Msg("Player awake!");
            playerInstance = __instance;
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void Postfix_Update(Player __instance)
        {
            if (disableIllegalActivities)
            {
                __instance.illegalActionActive = false;
            }
        }

        [HarmonyPatch("IsTrespassing")]
        [HarmonyPostfix]
        private static bool Postfix_IsTrespassing(bool __result)

        {
            if (disableTresspassing)
            {
                __result = false;
            }

            return __result;
        }
    }
}