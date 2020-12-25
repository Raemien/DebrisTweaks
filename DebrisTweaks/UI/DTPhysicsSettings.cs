using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using System;

namespace DebrisTweaks
{
    class DTPhysicsSettings : BSMLResourceViewController
    {
        public override string ResourceName => "DebrisTweaks.Views.PhysicsMenu.bsml";

        internal bool _EnableGravity = Settings.instance.EnableGravity;
        internal bool _FreezeRotations = Settings.instance.FreezeRotations;
        internal float _Velocity = Settings.instance.Velocity;
        internal float _Drag = Settings.instance.Drag;

        [UIValue("velocity")]
        internal float Velocity
        {
            get => _Velocity;
            set
            {
                _Velocity = value;
                Settings.instance.Velocity = value;
                NotifyPropertyChanged();
            }
        }

        [UIValue("drag")]
        internal float Drag
        {
            get => _Drag;
            set
            {
                _Drag = value;
                Settings.instance.Drag = value;
                NotifyPropertyChanged();
            }
        }

        [UIValue("rot-freeze")]
        internal bool FreezeRotations
        {
            get => _FreezeRotations;
            set
            {
                _FreezeRotations = value;
                Settings.instance.FreezeRotations = value;
            }
        }

        [UIValue("enable-gravity")]
        internal bool EnableGravity
        {
            get => _EnableGravity;
            set
            {
                _EnableGravity = value;
                Settings.instance.EnableGravity = value;
            }
        }

    }
}
