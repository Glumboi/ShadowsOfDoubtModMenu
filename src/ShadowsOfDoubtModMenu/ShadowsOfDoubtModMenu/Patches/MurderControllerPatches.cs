using HarmonyLib;
using Il2Cpp;
using MelonLoader;

namespace ShadowsOfDoubtModMenu.Patches
{
    [HarmonyPatch(typeof(MurderController))]
    public class MurderControllerPatches
    {
        public static MurderController instance;

        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        public static void Postfix_Awake(MurderController __instance)
        {
            MelonLogger.Msg("MurderController awake!");
            instance = __instance;
        }
    }
}
