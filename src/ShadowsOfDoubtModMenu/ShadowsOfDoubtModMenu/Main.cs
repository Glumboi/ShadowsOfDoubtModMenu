using MelonLoader;
using UnityEngine;

namespace ShadowsOfDoubtModMenu
{
    public static class BuildInfo
    {
        public const string Name = "ShadowsOfDoubtModMenu"; // Name of the Mod.  (MUST BE SET)

        public const string
            Description = "ModMenu for Shadows Of Doubt"; // Description for the Mod.  (Set as null if none)

        public const string Author = "Glumboi and Linkis"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "2.2.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class ShadowsOfDoubtModMenu : MelonMod
    {
        private static bool menuEnabled;
        private static bool caseMenuEnabled;
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
                ToggleAMenu(ref menuEnabled, true);
            }

            if (Input.GetKeyDown(KeyCode.F3))
            {
                ToggleMouse(Cursor.lockState == CursorLockMode.Locked);
            }

            if (Input.GetKeyDown(KeyCode.F4))
            {
                ToggleAMenu(ref caseMenuEnabled, true);
            }
        }

        public override void OnGUI() // Can run multiple times per frame. Mostly used for Unity's IMGUI.
        {
            if (menuEnabled)
            {
                UI.MenuUI();
            }

            if (caseMenuEnabled)
            {
                UI.CaseUI();
            }
        }

        private static void ToggleMouse(bool enable)
        {
            Cursor.lockState = enable ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = enable;
        }

        private static void ToggleAMenu(ref bool menuBool, bool enable, bool mouseOnly = false)
        {
            if (!mouseOnly)
            {
                if (enable && menuBool)
                    enable = false;

                menuBool = enable;
            }

            ToggleMouse(enable);
        }
    }
}
