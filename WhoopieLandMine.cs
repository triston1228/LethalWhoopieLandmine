using BepInEx;
using BepInEx.Logging;
using GameNetcodeStuff;
using HarmonyLib;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace WhoopieLandMine
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class WhoopieLandMine : BaseUnityPlugin
    {
        public static WhoopieLandMine Instance { get; private set; } = null!;
        internal new static ManualLogSource Logger { get; private set; } = null!;
        internal static Harmony? Harmony { get; set; }

        public ConfigEntry<bool> explosionEffectConfig;
        public ConfigEntry<bool> goThroughCarConfig;

        public ConfigEntry<float> killRangeConfig;
        public ConfigEntry<float> physicsForceConfig;
        public ConfigEntry<float> damageRangeConfig;

        public ConfigEntry<int> nonLethalDamageConfig;

        private void Awake()
        {

            explosionEffectConfig = Config.Bind("General", "explosionEffectConfig", true, "Sets the explosion effect to active or disabled");
            goThroughCarConfig = Config.Bind("General", "goThroughCarConfig", false, "?");

            killRangeConfig = Config.Bind("General", "killRangeConfig", 1f, "Sets kill range");
            physicsForceConfig = Config.Bind("General", "physicsForceConfig", 5f, "Sets knockback force");
            damageRangeConfig = Config.Bind("General", "damageRangeConfig", 10f, "Sets damage range");

            nonLethalDamageConfig = Config.Bind("General", "nonLethalDamageConfig", 50, "Sets Non-Lethal damage");
        
            Logger = base.Logger;
            Instance = this;

            Patch();

            Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} v{MyPluginInfo.PLUGIN_VERSION} has loaded!");

            Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} v{MyPluginInfo.PLUGIN_VERSION} has loaded!");
            
            Logger.LogInfo($"explosionEffectConfig: {explosionEffectConfig.Value}");
            Logger.LogInfo($"goThroughCarConfig: {goThroughCarConfig.Value}");

            Logger.LogInfo($"killRangeConfig: {killRangeConfig.Value}");
            Logger.LogInfo($"physicsForceConfig: {physicsForceConfig.Value}");
            Logger.LogInfo($"damageRangeConfig: {damageRangeConfig.Value}");

            Logger.LogInfo($"nonLethalDamageConfig: {nonLethalDamageConfig.Value}");
        }

        internal static void Patch()
        {
            Harmony ??= new Harmony(MyPluginInfo.PLUGIN_GUID);

            Logger.LogDebug("Patching...");

            Harmony.PatchAll();

            Logger.LogDebug("Finished patching!");
        }

        internal static void Unpatch()
        {
            Logger.LogDebug("Unpatching...");

            Harmony?.UnpatchSelf();

            Logger.LogDebug("Finished unpatching!");
        }
    }


}
