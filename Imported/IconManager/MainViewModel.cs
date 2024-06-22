using IconsRestorer.Code;

// Credits to Ivan Yakimov at codeproject. This is phenomenal code.
// https://www.codeproject.com/Articles/639486/Save-and-Restore-Icon-Positions-on-Desktop

namespace IconsRestorer.ViewModels
{
    internal class MainViewModel
    {
        private readonly DesktopRegistry registry = new DesktopRegistry();
        private readonly Desktop desktop = new Desktop();
        private readonly Storage storage = new Storage();

        public void SaveIconPositions()
        {
            var registryValues = registry.GetRegistryValues();
            var iconPositions = desktop.GetIconsPositions();
            storage.SaveIconPositions(iconPositions, registryValues);
        }

        public void RestoreIconPositions()
        {
            var registryValues = storage.GetRegistryValues();
            registry.SetRegistryValues(registryValues);
            var iconPositions = storage.GetIconPositions();
            desktop.SetIconPositions(iconPositions);
            desktop.Refresh();
        }
    }
}
