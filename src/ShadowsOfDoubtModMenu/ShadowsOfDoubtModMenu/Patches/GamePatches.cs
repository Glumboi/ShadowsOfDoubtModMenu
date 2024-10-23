using HarmonyLib;
using Il2Cpp;
using MelonLoader;

namespace ShadowsOfDoubtModMenu.Patches
{
    [HarmonyPatch(typeof(Game))]
    public class GamePatches
    {
        public static Game gameInstance;
        public static string forcePasscode;

        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        private static void Postfix_Awake(Game __instance)
        {
            MelonLogger.Msg("Game awake!");
            gameInstance = __instance;
        }
    }
}
