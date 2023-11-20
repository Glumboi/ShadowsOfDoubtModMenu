using HarmonyLib;
using Il2Cpp;

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
            instance = __instance;
        }
    }
}