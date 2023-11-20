using System;
using Il2Cpp;
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
            GUILayout.Space(6);
            GUILayout.Label("Shadows of Doubt ModMenu", new GUILayoutOption[0]);
            GUILayout.EndHorizontal();

            GUILayout.Space(2);
            GUILayout.Label("Player");
            GUILayout.Space(6);

            if (GUILayout.Button("Kill Player", new GUILayoutOption[0]))
            {
                PlayerPatches.playerInstance.KillPlayer();
            }

            GUILayout.Space(6);
            GUILayout.BeginHorizontal();
            PlayerPatches.disableIllegalActivities =
                GUILayout.Toggle(PlayerPatches.disableIllegalActivities, "No illegal Activities");
            LockpickingPatches.instaLockpick =
                GUILayout.Toggle(LockpickingPatches.instaLockpick, "Instant Lockpicking");
            GUILayout.EndHorizontal();

            GUILayout.Space(4);
            GUILayout.Label("Game");
            GUILayout.BeginHorizontal();
            GamePatches.gameInstance.invisiblePlayer =
                GUILayout.Toggle(GamePatches.gameInstance.invisiblePlayer, "Invisible Player");
            GamePatches.gameInstance.inaudiblePlayer =
                GUILayout.Toggle(GamePatches.gameInstance.inaudiblePlayer, "Inaudible Player");
            GamePatches.gameInstance.invinciblePlayer =
                GUILayout.Toggle(GamePatches.gameInstance.invinciblePlayer, "Invincible Player");
            GamePatches.gameInstance.pauseAI = GUILayout.Toggle(GamePatches.gameInstance.pauseAI, "Pause AI");
            GamePatches.gameInstance.disableTrespass =
                GUILayout.Toggle(GamePatches.gameInstance.disableTrespass, "Disable Trespass");
            GUILayout.EndHorizontal();
            GUILayout.Space(4);

            GUILayout.Label("Force keycode");

            GamePatches.gameInstance.overriddenPasscode =
                Int32.Parse(GUILayout.TextField(GamePatches.gameInstance.overriddenPasscode.ToString()));

            GamePatches.gameInstance.overridePasscodes =
                GUILayout.Toggle(GamePatches.gameInstance.overridePasscodes, "Override Passcodes");

            GUILayout.Space(8);

            GUILayout.Label("Stats");

            GUILayout.Space(4);
            
            GUILayout.Label("Lockpicks");
            
            GameplayControllerPatches.lockpicksToSet =
                Int32.Parse(GUILayout.TextField(GameplayControllerPatches.lockpicksToSet.ToString()));

            if (GUILayout.Button("Set"))
            {
                GameplayControllerPatches.instance.lockPicks = GameplayControllerPatches.lockpicksToSet;
            }

            if (GUILayout.Button("Add"))
            {
                GameplayControllerPatches.instance.AddLockpicks(GameplayControllerPatches.lockpicksToSet, true);
            }

            GameplayControllerPatches.lockLockpicks =
                GUILayout.Toggle(GameplayControllerPatches.lockLockpicks, "Freeze Lockpick amount");

            if (GameplayControllerPatches.lockLockpicks)
            {
                GameplayControllerPatches.instance.SetLockpicks(GameplayControllerPatches.lockpicksToSet);
            }
            
            GUILayout.Space(4);
            
            GUILayout.Label("Money");

            GameplayControllerPatches.moneyToSet =
                Int32.Parse(GUILayout.TextField(GameplayControllerPatches.moneyToSet.ToString()));

            if (GUILayout.Button("Set"))
            {
                GameplayControllerPatches.instance.money = GameplayControllerPatches.moneyToSet;
            }

            if (GUILayout.Button("Add"))
            {
                GameplayControllerPatches.instance.AddMoney(GameplayControllerPatches.moneyToSet, true,
                    "Added from ModMenu");
            }

            GameplayControllerPatches.lockMoney =
                GUILayout.Toggle(GameplayControllerPatches.lockMoney, "Freeze Money amount");

            if (GameplayControllerPatches.lockMoney)
            {
                GameplayControllerPatches.instance.SetMoney(GameplayControllerPatches.moneyToSet);
            }
            
            GUILayout.Space(4);
            
            GUILayout.Label("Social credits");

            GameplayControllerPatches.socialCreditsToSet =
                Int32.Parse(GUILayout.TextField(GameplayControllerPatches.socialCreditsToSet.ToString()));

            if (GUILayout.Button("Set"))
            {
                GameplayControllerPatches.instance.socialCredit = GameplayControllerPatches.socialCreditsToSet;
            }

            if (GUILayout.Button("Add"))
            {
                GameplayControllerPatches.instance.AddSocialCredit(GameplayControllerPatches.socialCreditsToSet, true,
                    "Added from ModMenu");
            }

            GameplayControllerPatches.lockSocialCredits =
                GUILayout.Toggle(GameplayControllerPatches.lockSocialCredits, "Freeze social credit amount");
            
            if (GameplayControllerPatches.lockSocialCredits)
            {
                GameplayControllerPatches.instance.SetSocialCredit(GameplayControllerPatches.socialCreditsToSet);
            }
            
            GUILayout.Space(6);
            GUILayout.Label("City generation parameters");
            GUILayout.Space(2);
            GUILayout.Label("City size (affects only the very large city generation)");
            GUILayout.Space(2);
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            GUILayout.Label("X vector value");
            CityControlsPatches.newXcitySize =
                float.Parse(GUILayout.TextField(CityControlsPatches.newXcitySize.ToString()));
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.Label("Y vector value");
            CityControlsPatches.newYcitySize =
                float.Parse(GUILayout.TextField(CityControlsPatches.newYcitySize.ToString()));
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();

            GUILayout.Space(2);

            GUILayout.Label("City tile size (affects all city sizes)");
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            GUILayout.Label("X vector value");
            CityControlsPatches.tileSizeNewX =
                float.Parse(GUILayout.TextField(CityControlsPatches.tileSizeNewX.ToString()));
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.Label("Y vector value");
            CityControlsPatches.tileSizeNewY =
                float.Parse(GUILayout.TextField(CityControlsPatches.tileSizeNewY.ToString()));
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.Label("Z vector value");
            CityControlsPatches.tileSizeNewZ =
                float.Parse(GUILayout.TextField(CityControlsPatches.tileSizeNewZ.ToString()));
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();

            if (GUILayout.Button("Set city generation parameters"))
            {
                CityControlsPatches.ApplyNewParameters();
            }

            GUILayout.EndVertical();
        }

        public static void CaseUI()
        {
            GUILayout.BeginVertical(GUI.skin.window, GUILayout.Width(0b100101100));
            GUI.backgroundColor = new Color32(0b11111111, 0b0, 0b10010011, 0b11111111);
            GUI.contentColor = new Color32(0b0, 0b11000110, 0b11111111, 0b11111111);
            
            GUILayout.Space(0b110);
            GUILayout.Label("Current case menu", new GUILayoutOption[0b0]);
            GUILayout.Space(0b100);
            GUILayout.Label($"Murderer Name: {MurderControllerPatches.instance.currentMurderer.citizenName}");
            GUILayout.Space(0b100);
            GUILayout.Label($"Murderer Home: {MurderControllerPatches.instance.currentMurderer.home.district.name}, " +
                            $"{MurderControllerPatches.instance.currentMurderer.home.residence.name}");

            if (GUILayout.Button("Teleport to murderer's home bedroom"))
            {
                var tp = PlayerPatches.playerInstance.FindSafeTeleport(MurderControllerPatches.instance.currentMurderer.residence.bedrooms._items[0]);
                PlayerPatches.playerInstance.Teleport(tp, tp.building.mainEntrance.door.doorInteractable.usagePoint);
            }
            
            GUILayout.EndVertical();
        }
    }
}