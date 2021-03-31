using UnityEngine;
using System.Reflection;
using HarmonyLib;
using BepInEx;


namespace MoreControlOptionsMod
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    [BepInProcess("Dorfromantik.exe")]
    public class MoreControlOptionsMod : BaseUnityPlugin
    {
        public const string pluginGuid = "MoreControlOptions";
        public const string pluginName = "MoreControlOptions";
        public const string pluginVersion = "0.3";
        public static BepInEx.Configuration.ConfigEntry<bool> configEnhancedCameraZoomEnabled;
        public static BepInEx.Configuration.ConfigEntry<bool> configSpeedPanEnabled;
        public static BepInEx.Configuration.ConfigEntry<float> configZoomOutDistance;
        public static BepInEx.Configuration.ConfigEntry<float> configZoomInDistance;
        public static BepInEx.Configuration.ConfigEntry<int> configSpeedPanMultiplier;

        public void Awake()
        {
            configEnhancedCameraZoomEnabled = Config.Bind("CameraZoom.Toggles",
                                    "MoreCameraZoomEnabled",
                                    true,
                                    "Whether to use enhanced camera zoom limits.");

            configZoomOutDistance = Config.Bind("CameraZoom",   // The section under which the option is shown
                             "zoomOutDistance",  // The key of the configuration option in the configuration file
                             -20f, // The default value
                             "A value that limits the maximum zoom out distance. Default is -2.3. Recommended value is -20. Must be between -100 and zoomInDistance." +
                             "Values lower than -20 lead to clipping."); // Description of the option to show in the config file

            configZoomInDistance = Config.Bind("CameraZoom",   // The section under which the option is shown
                             "zoomInDistance",  // The key of the configuration option in the configuration file
                             8f, // The default value
                             "A value that limits the maximum zoom out distance. Default is 2.3. Recommended value is 8. Must be between 0 and 100."); // Description of the option to show in the config file

            configSpeedPanEnabled = Config.Bind("SpeedPan.Toggles",
                        "SpeedPanEnabled",
                        true,
                        "Whether to use enhanced camera zoom limits.");

            configSpeedPanMultiplier = Config.Bind("SpeedPan",
                                                "keyboardCameraMoveSpeed",
                                                2,
                                                "Multiplier for the speed of panning camera when using WASD keys. " +
                                                "Value of 2 means that camera will move twice as quickly when using WASD to move it. Default is 1. " +
                                                "Recommended value is 2. Must be between 1 and 50." +
                                                "Fractional numbers are currently not supported, neither are values lower than 1.");
            Harmony harmonyInstance = new Harmony(pluginGuid);
            harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());

            Debug.Log("MoreControlOptionsMod successfully loaded!");
        }
    }

    public class Patches
    {
        [HarmonyPatch(typeof(CameraZoom), "Zoom", new[] { typeof(float) })]
        public static class CameraZoom_Zoom_Patch
        {
            [HarmonyPrefix]
            private static bool preZoom(ref float ___zoomInDistance, ref float ___zoomOutDistance)
            {
                if (MoreControlOptionsMod.configEnhancedCameraZoomEnabled.Value)
                {
                    
                    ___zoomInDistance = MoreControlOptionsMod.configZoomInDistance.Value;
                    ___zoomOutDistance = MoreControlOptionsMod.configZoomOutDistance.Value;

                    if (___zoomInDistance < 0f) ___zoomInDistance = 0f;
                    if (___zoomInDistance > 100f) ___zoomInDistance = 100f;
                    if (___zoomOutDistance < -100f) ___zoomInDistance = -100f;
                    if (___zoomOutDistance > ___zoomInDistance) ___zoomOutDistance = ___zoomInDistance -1f;

                    Debug.Log($"preZoom, MoreCameraZoomEnabled = true, zoomInDistance: {___zoomInDistance}, zoomOutDistance {___zoomOutDistance}");
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(CameraMovement), "MoveCameraBy", new[] { typeof(Vector2), typeof(float), typeof(Space) })]
        public static class CameraMovement_MoveCameraBy_Patch
        {
            [HarmonyPrefix]
            private static bool preMove(ref Vector2 inputDelta)
            {
                if (MoreControlOptionsMod.configSpeedPanEnabled.Value)
                {
                    int speedPanMultiplier = MoreControlOptionsMod.configSpeedPanMultiplier.Value;

                    if (speedPanMultiplier < 1) speedPanMultiplier = 1;
                    if (speedPanMultiplier > 50) speedPanMultiplier = 50;
                    Debug.Log($"preMove, SpeedPanEnabled = true, SpeedPanMultiplier: {speedPanMultiplier}");
                    inputDelta = inputDelta * speedPanMultiplier;
                }
                return true;
            }
        }
    }
}
