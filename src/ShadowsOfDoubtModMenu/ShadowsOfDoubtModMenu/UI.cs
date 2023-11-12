using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2Cpp;
using MelonLoader;
using ShadowsOfDoubtModMenu.Patches;
using UnityEngine;
using static MelonLoader.MelonLogger;

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
            PlayerPatches.disableTresspassing = GUILayout.Toggle(PlayerPatches.disableTresspassing, "No Trespassing");
            PlayerPatches.disableIllegalActivities = GUILayout.Toggle(PlayerPatches.disableIllegalActivities, "No illegal Activities");
            LockpickingPatches.instaLockpick = GUILayout.Toggle(LockpickingPatches.instaLockpick, "Instant Lockpicking");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            //KeypadControllerPatches.alwaysCorrectCode = GUILayout.Toggle(KeypadControllerPatches.alwaysCorrectCode, "Always correct Keycode");

            GUILayout.EndHorizontal();

            GUILayout.Space(4);

            GameplayControllerPatches.lockpicksToAdd =
                Int32.Parse(GUILayout.TextField(GameplayControllerPatches.lockpicksToAdd.ToString()));

            if (GUILayout.Button("Add Lockpick amount"))
            {
                GameplayControllerPatches.instance.AddLockpicks(GameplayControllerPatches.lockpicksToAdd, true);
            }

            GUILayout.Space(2);

            GameplayControllerPatches.moneyToAdd =
                Int32.Parse(GUILayout.TextField(GameplayControllerPatches.moneyToAdd.ToString()));

            if (GUILayout.Button("Add money amount"))
            {
                GameplayControllerPatches.instance.AddMoney(GameplayControllerPatches.moneyToAdd, true, "Money added from Mod Menu!");
            }

            GUILayout.Space(2);

            GameplayControllerPatches.socialCreditsToAdd =
                Int32.Parse(GUILayout.TextField(GameplayControllerPatches.socialCreditsToAdd.ToString()));

            if (GUILayout.Button("Add social credit amount"))
            {
                GameplayControllerPatches.instance.AddSocialCredit(GameplayControllerPatches.socialCreditsToAdd, true, "Social credit added from Mod Menu!");
            }

            GUILayout.Space(6);
            GUILayout.Label("City generation parameters");
            GUILayout.Space(2);
            GUILayout.Label("City size (affects only the very large city generation)");
            GUILayout.Space(2);
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            GUILayout.Label("X vector value");
            CityControlsPatches.newXcitySize = float.Parse(GUILayout.TextField(CityControlsPatches.newXcitySize.ToString()));
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.Label("Y vector value");
            CityControlsPatches.newYcitySize = float.Parse(GUILayout.TextField(CityControlsPatches.newYcitySize.ToString()));
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();

            GUILayout.Space(2);

            GUILayout.Label("City tile size (affects all city sizes)");
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            GUILayout.Label("X vector value");
            CityControlsPatches.tileSizeNewX = float.Parse(GUILayout.TextField(CityControlsPatches.tileSizeNewX.ToString()));
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.Label("Y vector value");
            CityControlsPatches.tileSizeNewY = float.Parse(GUILayout.TextField(CityControlsPatches.tileSizeNewY.ToString()));
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.Label("Z vector value");
            CityControlsPatches.tileSizeNewZ = float.Parse(GUILayout.TextField(CityControlsPatches.tileSizeNewZ.ToString()));
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();

            if (GUILayout.Button("Set city generation parameters"))
            {
                CityControlsPatches.ApplyNewParameters();
            }
            GUILayout.EndVertical();
        }
    }
}