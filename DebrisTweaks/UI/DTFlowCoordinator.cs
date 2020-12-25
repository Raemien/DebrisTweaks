using BeatSaberMarkupLanguage;
using HMUI;

namespace DebrisTweaks
{
    public class DTFlowCoordinator : FlowCoordinator
    {
        private DTMainSettings mainView;
        private DTPhysicsSettings cachedPhysicsView;
        private DTCosmeticSettings cachedCosmeticView;
        private DTPhysicsSettings leftView;
        private DTCosmeticSettings rightView;

        public void RefreshCache() 
        {
            cachedPhysicsView = BeatSaberUI.CreateViewController<DTPhysicsSettings>();
            cachedCosmeticView = BeatSaberUI.CreateViewController<DTCosmeticSettings>();
        }

        public void ApplyResponsiveVisibility(bool replace = false) 
        {
            leftView = Settings.instance.EnableTweaks ? cachedPhysicsView : null;
            rightView = Settings.instance.EnableTweaks ? cachedCosmeticView : null;
            if (replace)
            {
                SetLeftScreenViewController(leftView, (ViewController.AnimationType)(Settings.instance.EnableTweaks ? 1 : 2));
                SetRightScreenViewController(rightView, (ViewController.AnimationType)(Settings.instance.EnableTweaks ? 1 : 2));
            }
        }

        private void Awake()
        {
            if (!mainView)
            {
                mainView = BeatSaberUI.CreateViewController<DTMainSettings>();
            }
            if (!cachedPhysicsView)
            {
                cachedPhysicsView = BeatSaberUI.CreateViewController<DTPhysicsSettings>();
            }
            if (!cachedCosmeticView)
            {
                cachedCosmeticView = BeatSaberUI.CreateViewController<DTCosmeticSettings>();
            }
            ApplyResponsiveVisibility();
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            if (firstActivation)
            {
                SetTitle("Debris Tweaks");
                showBackButton = true;
                ProvideInitialViewControllers(mainView, leftView, rightView);
            }
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            BeatSaberUI.MainFlowCoordinator.DismissFlowCoordinator(this, null, ViewController.AnimationDirection.Horizontal);
        }


    }
}
