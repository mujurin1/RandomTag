using Prism.Regions;
using RandomTag.Core.Mvvm;
using RandomTag.Services.Interfaces;
using Reactive.Bindings;
using System.Diagnostics;
using System.Threading.Tasks;
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
            var image = gifService.GetGif();
            if (image.IsDownloading)
            {
                IMG = new(new(@"C:\Users\てつよい\Desktop\画像\d46f8c0068993ee3464eb1b60ea69b70.jpg"));
                image.DownloadCompleted += (o, e) =>
                {
                    Debug.WriteLine("COMPLETED!");
                    IMG = image;
                };
            }
            else
            {
                IMG = image;
            }
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}
