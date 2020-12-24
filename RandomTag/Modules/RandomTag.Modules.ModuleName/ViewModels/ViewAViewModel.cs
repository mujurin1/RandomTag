using Prism.Regions;
using RandomTag.Core.Mvvm;
using RandomTag.Services.Interfaces;
using Reactive.Bindings;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace RandomTag.Modules.ModuleName.ViewModels
{
    public class ViewAViewModel : RegionViewModelBase
    {
        private BitmapImage _img;
        public BitmapImage IMG
        {
            get => _img;
            set => SetProperty(ref _img, value);
        }

        ReactiveProperty<BitmapImage> Gif = new();

        public ViewAViewModel(IRegionManager regionManager, IGifService gifService) :
            base(regionManager)
        {
            _img = gifService.GetGif();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}
