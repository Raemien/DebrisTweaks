using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;

namespace DebrisTweaks
{
    public class UISingleton : PersistentSingleton<UISingleton>
    {
        public static MenuButton dtButton = new MenuButton("Debris Tweaks", "Modify note debris settings!", OpenBGMenu);
        public static DTFlowCoordinator flowCoordinator;

        private static void OpenBGMenu()
        {
            if (flowCoordinator == null)
            {
                flowCoordinator = BeatSaberUI.CreateFlowCoordinator<DTFlowCoordinator>();
            }
            BeatSaberUI.MainFlowCoordinator.PresentFlowCoordinator(flowCoordinator, null, HMUI.ViewController.AnimationDirection.Horizontal, false);
        }
        public static void RegMenuButton()
        {
            MenuButtons.instance.RegisterButton(dtButton);
        }
        public static void RemoveMenuButton()
        {
            MenuButtons.instance.UnregisterButton(dtButton);
        }
    }
}
