using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace NicoDou.Utils
{
    /// <summary>
    /// ヒダリウエ
    /// </summary>
    public record HidariueSt
    {
        /// <summary>
        /// ヒダリウエのGIFのURL
        /// </summary>
        public static string URLFormat { get; }
            = "https://nicovideo.cdn.nimg.jp/web/img/base/head/icon/nico/{0}.gif";
        /// <remarks>番号の部分は#NUMBER#</remarks>
        public int Number { get; }
        /// <summary>ヒダリウエのGIFのリンク</summary>
        public string URL { get; }
        /// <summary>ヒダリウエのGIF画像</summary>
        public BitmapImage GIF { get; }

        /// <summary>
        /// 今まで取得したヒダリウエ
        /// </summary>
        private static List<HidariueSt> _hidariueSts = new();

        private HidariueSt(int number)
        {
            this.Number = number;
            this.URL = string.Format(URLFormat, number);
            var testUrl = @"https://s17.aconvert.com/convert/p3r68-cdx67/i52t0-djfmh.gif";
            this.GIF = new(new(testUrl));
            //this.GIF = new(new(URL));
        }

        public static HidariueSt Get(int number)
        {
            // 既に取得済みのヒダリウエなら
            if (_hidariueSts.FirstOrDefault(h => h.Number == number) is HidariueSt hidariue and not null)
            {
                return hidariue;
            }

            hidariue = new HidariueSt(number);

            return hidariue;
        }
    }

    /// <summary>
    /// ヒダリウエ
    /// </summary>
    public record Hidariue
    {
        /// <summary>
        /// ヒダリウエのGIFのURL
        /// </summary>
        /// <remarks>
        /// 番号の部分は#NUMBER#
        /// </remarks>
        public static string URLFormat { get; }
            = "https://nicovideo.cdn.nimg.jp/web/img/base/head/icon/nico/{0}.gif";
        /// <summary>
        /// ヒダリウエの画像をダウンロードするため専用
        /// </summary>
        private static WebClient _client = new();

        /// <summary>
        /// ヒダリウエの番号
        /// </summary>
        public int Number{ get; }
        /// <summary>
        /// ヒダリウエのGIFのリンク
        /// </summary>
        public string URL { get; }
        /// <summary>
        /// ヒダリウエのGIF画像
        /// </summary>
        public BitmapImage GIF { get; }

        public Hidariue(int number)
        {
            this.Number = number;
            this.URL = string.Format(URLFormat, number);
            var testUrl = @"https://s19.aconvert.com/convert/p3r68-cdx67/atmpc-gs2oz.gif";
            //this.GIF = new(new Uri(@"C:\Users\てつよい\Desktop\画像\d46f8c0068993ee3464eb1b60ea69b70.jpg"));
            this.GIF = new(new Uri(testUrl));
        }

        //private void DownloadGif()
        //{
        //    var bitmap = new BitmapImage(new Uri(URL));
        //    if (bitmap.IsDownloading)
        //    {
        //        bitmap.DownloadCompleted += (o, e) =>
        //        {
        //            Debug.WriteLine("FINISHED");
        //            GIF.Value = bitmap;
        //        };
        //    }
        //    else
        //    {
        //        GIF.Value = bitmap;
        //    }
        //}

        //private async Task<BitmapImage> DownloadGifAsync()
        //{
        //    var bytes = await _client.DownloadDataTaskAsync(new Uri(URL)).ConfigureAwait(false);
        //    using var stream = new MemoryStream(bytes);
        //    var bitmap = new BitmapImage();
        //    bitmap.BeginInit();
        //    bitmap.StreamSource = stream;
        //    bitmap.CacheOption = BitmapCacheOption.OnLoad;
        //    bitmap.EndInit();
        //    bitmap.Freeze();
        //    GIF.Value = bitmap;
        //    return bitmap;
        //}
    }
}
