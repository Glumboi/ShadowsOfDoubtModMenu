using System.Globalization;
using Il2Cpp;
using Il2CppSystem;
using MelonLoader;
using ShadowsOfDoubtModMenu.Patches;
using UnityEngine;
using Array = System.Array;

namespace ShadowsOfDoubtModMenu
{
    internal class UI
    {
        public static void MenuUI()
        {
            //TODO Remake menu in Imgui :)
            if (!PlayerPatches.playerInstance) return;
            if (!GamePatches.gameInstance) return;
            if (!GameplayControllerPatches.instance) return;
            if (!CityControlsPatches.instance) return;

            GUILayout.BeginVertical(GUI.skin.window, GUILayout.Width(300));
            GUI.backgroundColor = new Color32(255, 0, 147, 255);
            GUI.contentColor = new Color32(0, 198, 255, 255);

            GUILayout.BeginHorizontal();
            GUILayout.Space(6);
            GUILayout.Label("Shadows of Doubt ModMenu");
            GUILayout.EndHorizontal();

            GUILayout.Space(2);
            GUILayout.Label("Player");
            GUILayout.Space(6);

            if (GUILayout.Button("Kill Player"))
            {
                PlayerPatches.playerInstance.KillPlayer();
            }

            GUILayout.Space(6);
            GUILayout.BeginHorizontal();

            PlayerPatches.disableIllegalActivities =
                GUILayout.Toggle(PlayerPatches.disableIllegalActivities, "No illegal Activities");
            LockpickingPatches.instaLockpick =
                GUILayout.Toggle(LockpickingPatches.instaLockpick, "Instant Lock picking");
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
            GamePatches.gameInstance.disableFallDamage =
                GUILayout.Toggle(GamePatches.gameInstance.disableFallDamage, "Disable Fall Damage");
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

            GUILayout.Label("Lock picks");

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
                GUILayout.Toggle(GameplayControllerPatches.lockLockpicks, "Freeze Lock pick amount");

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
                float.Parse(GUILayout.TextField(CityControlsPatches.newXcitySize.ToString(CultureInfo.CurrentCulture)));
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.Label("Y vector value");
            CityControlsPatches.newYcitySize =
                float.Parse(GUILayout.TextField(CityControlsPatches.newYcitySize.ToString(CultureInfo.CurrentCulture)));
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();

            GUILayout.Space(2);

            GUILayout.Label("City tile size (affects all city sizes)");
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            GUILayout.Label("X vector value");
            CityControlsPatches.tileSizeNewX =
                float.Parse(GUILayout.TextField(CityControlsPatches.tileSizeNewX.ToString(CultureInfo.CurrentCulture)));
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.Label("Y vector value");
            CityControlsPatches.tileSizeNewY =
                float.Parse(GUILayout.TextField(CityControlsPatches.tileSizeNewY.ToString(CultureInfo.CurrentCulture)));
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.Label("Z vector value");
            CityControlsPatches.tileSizeNewZ =
                float.Parse(GUILayout.TextField(CityControlsPatches.tileSizeNewZ.ToString(CultureInfo.CurrentCulture)));
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
            GUILayout.BeginVertical(GUI.skin.window, GUILayout.Width(300));
            GUI.backgroundColor = new Color32(255, 0, 147, 255);
            GUI.contentColor = new Color32(0, 198, 255, 255);

            GUILayout.Space(1);
            GUILayout.Label("Current case menu", Array.Empty<GUILayoutOption>());
            GUILayout.Space(1);

            //TODO: Loop activeMurders instead of currentMurderer 

            if (MurderControllerPatches.instance != null
                && MurderControllerPatches.instance.chosenMO != null
                && MurderControllerPatches.instance.currentMurderer != null)
            {
                GUILayout.Label($"Murderer Case: {MurderControllerPatches.instance.name} {MurderControllerPatches.instance.chosenMO.name}");
                GUILayout.Space(1);
                GUILayout.Label($"Murderer Name: {MurderControllerPatches.instance.currentMurderer.citizenName}");
                GUILayout.Space(1);
                GUILayout.Label($"Murderer Home: {MurderControllerPatches.instance.currentMurderer.home.name}");
                GUILayout.Space(1);
                GUILayout.Label($"Murderer District: {MurderControllerPatches.instance.currentMurderer.home.district.name}");
                GUILayout.Space(1);

                if (MurderControllerPatches.instance.currentMurderer.den != null)
                {
                    GUILayout.Label($"Murderer Den: {MurderControllerPatches.instance.currentMurderer.den.name}");
                    GUILayout.Space(1);
                    GUILayout.Label($"Murderer Den District: {MurderControllerPatches.instance.currentMurderer.den.district.name}");
                    GUILayout.Space(1);
                }

                if (GUILayout.Button("Teleport to murderer's home bedroom"))
                {
                    NewNode tp = PlayerPatches.playerInstance.FindSafeTeleport(MurderControllerPatches.instance.currentMurderer.residence.bedrooms._items[0]);
                    PlayerPatches.playerInstance.Teleport(tp, tp.building.mainEntrance.door.doorInteractable.usagePoint);
                }

                GUILayout.Space(1);

                if (MurderControllerPatches.instance.currentVictim != null)
                {
                    GUILayout.Label($"Victim Name: {MurderControllerPatches.instance.currentVictim.citizenName}");
                    GUILayout.Space(1);
                    GUILayout.Label($"Victim Home: {MurderControllerPatches.instance.currentVictim.home.name}");
                    GUILayout.Space(1);
                    GUILayout.Label($"Victim District: {MurderControllerPatches.instance.currentVictim.home.district.name}");
                    GUILayout.Space(1);

                    if (MurderControllerPatches.instance.currentVictimSite != null)
                    {
                        GUILayout.Label($"Victim Killed at: {MurderControllerPatches.instance.currentVictimSite.district.name} {MurderControllerPatches.instance.currentVictimSite.building.name}");
                        GUILayout.Space(1);
                    }

                    if (MurderControllerPatches.instance.currentVictim != null
                        && GUILayout.Button($"Teleport to {MurderControllerPatches.instance.currentVictim.citizenName}'s home bedroom"))
                    {
                        NewNode tp = PlayerPatches.playerInstance.FindSafeTeleport(MurderControllerPatches.instance.currentVictim.residence.bedrooms._items[0]);
                        PlayerPatches.playerInstance.Teleport(tp, tp.building.mainEntrance.door.doorInteractable.usagePoint);
                    }

                    GUILayout.Space(1);
                }
                else if (MurderControllerPatches.instance.activeMurders.Count > 0)
                {
                    GUILayout.Label($"Victims: {MurderControllerPatches.instance.activeMurders.Count}");
                    GUILayout.Space(1);
                    foreach (MurderController.Murder murder in MurderControllerPatches.instance.activeMurders)
                    {
                        GUILayout.Label($"Victim Name: {murder.victim.citizenName}");
                        GUILayout.Space(1);
                        GUILayout.Label($"Victim Home: {murder.victim.home.name}");
                        GUILayout.Space(1);
                        GUILayout.Label($"Victim District: {murder.victim.home.district.name}");
                        GUILayout.Space(1);

                        if (murder.victim != null
                            && GUILayout.Button($"Teleport to {murder.victim.citizenName}'s home bedroom"))
                        {
                            NewNode tp = PlayerPatches.playerInstance.FindSafeTeleport(murder.victim.residence.bedrooms._items[0]);
                            PlayerPatches.playerInstance.Teleport(tp, tp.building.mainEntrance.door.doorInteractable.usagePoint);
                        }

                        GUILayout.Space(1);
                    }
                }
                else
                {
                    GUILayout.Label("Victim: None for now :)");
                    GUILayout.Space(1);
                }
            }
            else
            {
                GUILayout.Label("Murderer Case: None");
                GUILayout.Space(1);
            }

            GUILayout.Space(1);
            GUILayout.Space(1);

            if (CasePanelControllerPatches.instance != null
                && CasePanelControllerPatches.instance.activeCase != null
                && CasePanelControllerPatches.instance.activeCase.caseType == Case.CaseType.sideJob)
            {
                GUILayout.Label($"Side job Case: {CasePanelControllerPatches.instance.activeCase.name}");
                GUILayout.Space(1);


                if (CasePanelControllerPatches.instance.activeCase.job.purp != null)
                {
                    GUILayout.Label($"Perpetrator Name: {CasePanelControllerPatches.instance.activeCase.job.purp.name}");
                    GUILayout.Space(1);
                    GUILayout.Label($"Perpetrator Home: {CasePanelControllerPatches.instance.activeCase.job.purp.home.name}");
                    GUILayout.Space(1);
                    GUILayout.Label($"Perpetrator District: {CasePanelControllerPatches.instance.activeCase.job.purp.home.district.name}");
                    GUILayout.Space(1);
                }

                if (CasePanelControllerPatches.instance.activeCase.job.poster != null)
                {
                    GUILayout.Label($"Poser Name: {CasePanelControllerPatches.instance.activeCase.job.poster.name}");
                    GUILayout.Space(1);
                    GUILayout.Label($"Poser Home: {CasePanelControllerPatches.instance.activeCase.job.poster.home.name}");
                    GUILayout.Space(1);
                    GUILayout.Label($"Poser District: {CasePanelControllerPatches.instance.activeCase.job.poster.home.district.name}");
                    GUILayout.Space(1);
                }

                GUILayout.Space(1);

                if (CasePanelControllerPatches.instance.activeCase.job.purp != null
                    && GUILayout.Button("Teleport to perpetrator's home bedroom"))
                {
                    NewNode tp = PlayerPatches.playerInstance.FindSafeTeleport(CasePanelControllerPatches.instance.activeCase.job.purp.residence.bedrooms._items[0]);
                    PlayerPatches.playerInstance.Teleport(tp, tp.building.mainEntrance.door.doorInteractable.usagePoint);
                    GUILayout.Space(1);
                }

                if (CasePanelControllerPatches.instance.activeCase.job.poster != null
                    && GUILayout.Button("Teleport to poster's home bedroom"))
                {
                    NewNode tp = PlayerPatches.playerInstance.FindSafeTeleport(CasePanelControllerPatches.instance.activeCase.job.poster.residence.bedrooms._items[0]);
                    PlayerPatches.playerInstance.Teleport(tp, tp.building.mainEntrance.door.doorInteractable.usagePoint);
                    GUILayout.Space(1);
                }
            }
            else
            {
                GUILayout.Label("Side job Case: None");
                GUILayout.Space(1);
            }

            GUILayout.Space(1);

            if (PlayerPatches.playerInstance != null
                && GUILayout.Button("Teleport to City Hall"))
            {
                foreach (NewBuilding building in Resources.FindObjectsOfTypeAll<NewBuilding>())
                {
                    if (building.name != "City Hall") continue;
                    MelonLogger.Msg(building.name);
                    PlayerPatches.playerInstance.Teleport(building.mainEntrance.node, building.mainEntrance.door.doorInteractable.usagePoint);
                    break;
                }
            }

            GUILayout.EndVertical();
        }
    }
}
