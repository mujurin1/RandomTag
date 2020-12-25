using NicoDou.Utils;
using RandomTag.Services.Interfaces;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RandomTag.Services
{
    public class GifService : IGifService
    {
        private HidariueSt _nicoDou;

        public GifService()
        {
            this._nicoDou = HidariueSt.Get(666);
        }

        public BitmapImage GetGif()
        {
            return _nicoDou.GIF;
        }
    }
}
