using HarmonyLib;
using Il2Cpp;
using static MelonLoader.MelonLogger;

namespace ShadowsOfDoubtModMenu.Patches
{
    [HarmonyPatch(typeof(Player))]
    internal class PlayerPatches
    {
        public static Player playerInstance;
        public static bool disableIllegalActivities;


        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        private static void Postfix_Awake(Player __instance)

        {
            Msg("Player awake!");
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
    }
}
