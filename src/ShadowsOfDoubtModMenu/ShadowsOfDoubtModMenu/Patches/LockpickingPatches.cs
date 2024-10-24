using HarmonyLib;
using Il2Cpp;
using MelonLoader;

namespace ShadowsOfDoubtModMenu.Patches
{
    internal class LockpickingPatches
    {
        public static bool instaLockpick = false;

        [HarmonyPatch(typeof(Interactable))]
        private class InteractablePatches
        {
            [HarmonyPatch("OnLockpick")]
            [HarmonyPrefix]
            private static void Prefix_OnLockpick(Interactable __instance)

            {
                MelonLogger.Msg($"Lockpicking {__instance.GetName()}");
                if (instaLockpick)
                {
                    __instance.SetLockedState(false, PlayerPatches.playerInstance);
                }
            }
        }

        [HarmonyPatch(typeof(NewDoor))]
        private class NewDoorPatches
        {
            [HarmonyPatch("OnLockpick")]
            [HarmonyPrefix]
            private static void Prefix_OnLockpick(NewDoor __instance)

            {
                MelonLogger.Msg($"Lockpicking {__instance.GetName()}");
                if (instaLockpick)
                {
                    __instance.SetLocked(false, PlayerPatches.playerInstance);
                }
            }
        }
    }
}
