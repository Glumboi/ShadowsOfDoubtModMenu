using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using UnityEngine;
using static Il2Cpp.CityControls;

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
            instance.citySizes[instance.citySizes.Count - 1].v2 = new Vector2(newXcitySize, newYcitySize);
            instance.cityTileSize = new Vector3(tileSizeNewX, tileSizeNewY, tileSizeNewZ);

            MelonLogger.Log("===============================================");
            MelonLogger.Log("New Values:");

            CityControlsPatches.LogThings();
        }

        public static void LogThings()

        {
            MelonLogger.Log("tile size" + instance.cityTileSize);
            for (int i = 0; i < instance.citySizes.Count; i++)
            {
                MelonLogger.Log("vec2: " + instance.citySizes[i].v2.ToString() + " | actual size:" + instance.citySizes[i].size);
            }

            MelonLogger.Log("district size max: " + instance.districtSizeMax);
            MelonLogger.Log("district size min: " + instance.districtSizeMin);
            MelonLogger.Log("max block size: " + instance.maxBlockSize);
        }
    }
}