using System.Linq;
using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace ShadowsOfDoubtModMenu.Patches
{
    [HarmonyPatch(typeof(CityControls))]
    internal class CityControlsPatches
    {
        public static CityControls instance;
        public static float newXcitySize = 7;
        public static float newYcitySize = 6;

        public static float tileSizeNewX = 37.80f;
        public static float tileSizeNewY = 37.80f;
        public static float tileSizeNewZ = 37.80f;

        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        private static void Postfix_Awake(CityControls __instance)
        {
            instance = __instance;

            LogThings();
        }

        public static void ApplyNewParameters()
        {
            if (instance.citySizes.Count > 0)
            {
                instance.citySizes._items.Last().v2 = new Vector2(newXcitySize, newYcitySize);
                instance.cityTileSize = new Vector3(tileSizeNewX, tileSizeNewY, tileSizeNewZ);
            }


            MelonLogger.Msg("===============================================");
            MelonLogger.Msg("New Values:");

            LogThings();
        }

        public static void LogThings()
        {
            MelonLogger.Msg("tile size" + instance.cityTileSize);
            for (int i = 0; i < instance.citySizes.Count; i++)
            {
                MelonLogger.Msg("vec2: " + instance.citySizes._items[i].v2 + " | actual size:" +
                                instance.citySizes._items[i].size);
            }

            MelonLogger.Msg("district size max: " + instance.districtSizeMax);
            MelonLogger.Msg("district size min: " + instance.districtSizeMin);
            MelonLogger.Msg("max block size: " + instance.maxBlockSize);
        }
    }
}
