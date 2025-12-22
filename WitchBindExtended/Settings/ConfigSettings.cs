using BepInEx.Configuration;
using TeamCherry.Localization;

namespace WitchBindExtended.Settings
{
    public static class ConfigSettings
    {
        /// <summary>
        /// Integrates with UI to set the multiplier of Witch Crest's tentacles
        /// </summary>
        public static ConfigEntry<float> multiplier;

        /// <summary>
        /// Integrates with UI to set the multiplier of Witch Crest's tentacles when Longclaw is equipped
        /// </summary>
        public static ConfigEntry<float> longclawMultiplier;

        /// <summary>
        /// Initializes the settings
        /// </summary>
        /// <param name="config"></param>
        public static void Initialize(ConfigFile config)
        {
            // Bind set methods to Config
            LocalisedString name = new LocalisedString($"Mods.{WitchBindExtended.Id}", "NAME");
            LocalisedString description = new LocalisedString($"Mods.{WitchBindExtended.Id}", "DESC");
            float defaultValue = 1.2f;
            if (name.Exists &&
                description.Exists)
            {
                multiplier = config.Bind<float>("Modifier", name, defaultValue, description);
            }
            else
            {
                multiplier = config.Bind("Modifier", "Multiplier", defaultValue, "How much to enlarge Witch Crest's tentacles");
            }

            name = new LocalisedString($"Mods.{WitchBindExtended.Id}", "LN_NAME");
            description = new LocalisedString($"Mods.{WitchBindExtended.Id}", "LN_DESC");
            defaultValue = 1.52f;
            if (name.Exists &&
                description.Exists)
            {
                longclawMultiplier = config.Bind<float>("Modifier", name, defaultValue, description);
            }
            else
            {
                longclawMultiplier = config.Bind("Modifier", "Longclaw Multiplier", defaultValue, "How much to enlarge Witch Crest's tentacles with Longclaw equipped");
            }
        }
    }
}