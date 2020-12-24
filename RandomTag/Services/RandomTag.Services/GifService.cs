using NicoDou.Utils;
using RandomTag.Services.Interfaces;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace RandomTag.Services
{
    public class GifService : IGifService
    {
        private Hidariue _nicoDou;

        public GifService()
        {
            this._nicoDou = new Hidariue(666);
        }

        public BitmapImage GetGif()
            => _nicoDou.GIF;
    }
}
