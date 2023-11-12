using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using System;
using UnityEngine;

namespace ShadowsOfDoubtModMenu
{
    public static class BuildInfo
    {
        public const string Name = "ShadowsOfDoubtModMenu"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "ModMenu for Shadows Of Doubt"; // Description for the Mod.  (Set as null if none)
        public const string Author = "Glumboi"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class ShadowsOfDoubtModMenu : MelonMod
    {
        private static bool menuEnabled = false;
        private static Rect windowRect = new Rect(20, 20, 350, 700);

        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("OnApplicationStart");
        }

        public override void OnLateInitializeMelon() // Runs after OnApplicationStart.
        {
            MelonLogger.Msg("OnApplicationLateStart");
        }

        public override void OnUpdate()
        {
            if (menuEnabled && Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            if (Input.GetKeyDown(KeyCode.F2))
            {
                ToggleMenu(true);
            }

            if (Input.GetKeyDown(KeyCode.F3))
            {
                ToggleMenu(true, true);
            }
        }

        public override void OnGUI() // Can run multiple times per frame. Mostly used for Unity's IMGUI.
        {
            if (menuEnabled)
            {
                UI.MenuUI();
            }
        }

        public static void ToggleMenu(bool enable, bool mouseOnly = false)
        {
            if (enable && menuEnabled)
                enable = !enable;

            if (!mouseOnly)
            {
                menuEnabled = enable;
            }

            Cursor.lockState = enable ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = enable;
        }
    }
}