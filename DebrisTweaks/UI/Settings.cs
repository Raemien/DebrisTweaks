using BS_Utils.Utilities;

namespace DebrisTweaks
{
    internal class PluginConfig
    {
        public bool RegenerateConfig = true;
    }


    class Settings : PersistentSingleton<Settings>
    {
        private Config config;

        // Main
        public bool EnableTweaks
        {
            get => config.GetBool("Main", "Enable Tweaks", false);
            set => config.SetBool("Main", "Enable Tweaks", value);
        }
        public bool DisableDebris
        {
            get => config.GetBool("Main", "Force Disable Debris", false);
            set => config.SetBool("Main", "Force Disable Debris", value);
        }

        // Physics
        public float Velocity
        {
            get => config.GetFloat("Physics", "Velocity Multiplier", 1);
            set => config.SetFloat("Physics", "Velocity Multiplier", value);
        }
        public float Drag
        {
            get => config.GetFloat("Physics", "Drag Multiplier", 1);
            set => config.SetFloat("Physics", "Drag Multiplier", value);
        }
        public bool FreezeRotations
        {
            get => config.GetBool("Physics", "Prevent Rotations", true);
            set => config.SetBool("Physics", "Prevent Rotations", value);
        }
        public bool EnableGravity
        {
            get => config.GetBool("Physics", "Enable Gravity", true);
            set => config.SetBool("Physics", "Enable Gravity", value);
        }

        // Cosmetic
        public bool MonochromeColors
        {
            get => config.GetBool("Cosmetic", "Monochrome Colors", false);
            set => config.SetBool("Cosmetic", "Monochrome Colors", value);
        }
        public bool OverrideLifespan
        {
            get => config.GetBool("Cosmetic", "Override Lifespan", true);
            set => config.SetBool("Cosmetic", "Override Lifespan", value);
        }
        public float DebrisLifespan
        {
            get => config.GetFloat("Cosmetic", "Debris Lifespan", 2);
            set => config.SetFloat("Cosmetic", "Debris Lifespan", value);
        }
        public float Scale
        {
            get => config.GetFloat("Cosmetic", "Debris Scale", 1);
            set => config.SetFloat("Cosmetic", "Debris Scale", value);
        }

        public void Awake()
        {
            config = new Config("DebrisTweaks");
        }
    }

}