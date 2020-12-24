using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace NicoDou.Utils
{
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
        private static WebClient _client
            = new WebClient();

        /// <summary>
        /// ヒダリウエの番号
        /// </summary>
        public int Number{ get; }
        /// <summary>
        /// ヒダリウエのGIFへのリンク
        /// </summary>
        public string URL { get; }
        private BitmapImage _downloadGif;
        /// <summary>
        /// ヒダリウエのGIF画像
        /// </summary>
        public BitmapImage GIF { get; private set; }

        public Hidariue(int number)
        {
            this.Number = number;
            this.URL = string.Format(URLFormat, number);
            Task.Run(() =>
            {

                this._downloadGif = new BitmapImage(new Uri(string.Format(@"http://exampleadlkfajfllafasdf.adfa", Number)));
                if (_downloadGif.IsDownloading)
                {
                    GIF = new BitmapImage();
                    _downloadGif.DownloadCompleted += (o, e) =>
                    {
                        GIF = _downloadGif;
                    };
                }
                else
                {
                    GIF = _downloadGif;
                }
            });
        }
    }
}
