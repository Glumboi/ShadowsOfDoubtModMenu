using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using ShadowsOfDoubtModMenu.Patches;
using UnityEngine;

namespace ShadowsOfDoubtModMenu
{
    internal class UI
    {
        public static void MenuUI()
        {
            GUILayout.BeginVertical(GUI.skin.window, GUILayout.Width(300));
            GUI.backgroundColor = new Color32(255, 0, 147, 255);
            GUI.contentColor = new Color32(0, 198, 255, 255);

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Close", new GUILayoutOption[0]))
            {
                ShadowsOfDoubtModMenu.ToggleMenu(false, false);
            }

            GUILayout.Space(6);
            GUILayout.Label("Shadows of Doubt ModMenu", new GUILayoutOption[0]);
            GUILayout.EndHorizontal();

            GUILayout.Space(6);

            if (GUILayout.Button("Kill Player", new GUILayoutOption[0]))
            {
                PlayerPatches.playerInstance.KillPlayer();
            }

            GUILayout.Space(6);
            GUILayout.BeginHorizontal();
            PlayerPatches.disableTresspassing = GUILayout.Toggle(PlayerPatches.disableTresspassing, "No Tresspassing");
            PlayerPatches.disableIllegalActivities = GUILayout.Toggle(PlayerPatches.disableIllegalActivities, "No illegal activities");
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();
        }
    }
}