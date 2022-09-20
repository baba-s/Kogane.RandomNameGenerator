using Kogane.Internal;

namespace Kogane
{
    /// <summary>
    /// ランダムに名前を生成して返すクラス
    /// </summary>
    public static class RandomNameGenerator
    {
        //================================================================================
        // 関数(static)
        //================================================================================
        /// <summary>
        /// ランダムに名前を生成して返します
        /// </summary>
        public static string Generate()
        {
            return RandomNameGeneratorSetting.Instance.GetNameAtRandom();
        }
    }
}