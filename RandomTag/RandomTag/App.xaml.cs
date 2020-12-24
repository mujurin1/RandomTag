using Prism.Ioc;
using Prism.Modularity;
using RandomTag.Modules.ModuleName;
using RandomTag.Services;
using RandomTag.Services.Interfaces;
using RandomTag.Views;
using System.Windows;

namespace RandomTag
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IGifService, GifService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
