using System;

namespace NicoDou
{

    public abstract record Search
    {
        /// <summary>
        /// <para>検索時の名前</para>
        /// <para>AND OR 検索非対応</para>
        /// </summary>
        public string SearchName { get; }
        /// <summary>
        /// 検索結果の動画数
        /// </summary>
        public int VideoCount { get; }
    }
}
