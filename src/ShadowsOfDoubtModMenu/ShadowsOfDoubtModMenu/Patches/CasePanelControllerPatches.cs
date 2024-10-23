using HarmonyLib;
using Il2Cpp;
using MelonLoader;

namespace ShadowsOfDoubtModMenu.Patches
{
    [HarmonyPatch(typeof(CasePanelController))]
    public class CasePanelControllerPatches
    {
        public static CasePanelController instance;

        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        public static void Postfix_Awake(CasePanelController __instance)
        {
            MelonLogger.Msg("CasePanelController awake!");
            instance = __instance;
        }
    }
}
