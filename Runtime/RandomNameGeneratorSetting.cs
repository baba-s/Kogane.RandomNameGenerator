using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Kogane.Internal
{
    /// <summary>
    /// ランダムに生成される名前を管理する ScriptableObject
    /// </summary>
    internal sealed class RandomNameGeneratorSetting : ScriptableObject
    {
        //==============================================================================
        // 変数(SerializeField)
        //==============================================================================
        [SerializeField][TextArea( minLines: 32, maxLines: 32 )] private string m_names = string.Empty;

        //==============================================================================
        // プロパティ(static)
        //==============================================================================
        public static RandomNameGeneratorSetting Instance { get; private set; }

        //==============================================================================
        // 関数
        //==============================================================================
#if UNITY_EDITOR
#else
        /// <summary>
        /// Preloaded Assets に設定されているアセットが読み込まれる時に呼び出されます
        /// </summary>
        private void OnEnable()
        {
            Instance = this;
        }
#endif

        /// <summary>
        /// 名前をランダムに返します
        /// </summary>
        public string GetNameAtRandom()
        {
            var nameArray = m_names.Split( '\n', StringSplitOptions.RemoveEmptyEntries );
            var index     = Random.Range( 0, nameArray.Length );

            return nameArray[ index ];
        }

        //==============================================================================
        // 関数(static)
        //==============================================================================
#if UNITY_EDITOR
        /// <summary>
        /// ゲーム起動時に呼び出されます
        /// </summary>
        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
        private static void RuntimeInitializeOnLoadMethod()
        {
            var guid = UnityEditor.AssetDatabase
                    .FindAssets( $"t:{nameof( RandomNameGeneratorSetting )}" )
                    .FirstOrDefault()
                ;

            var assetPath = UnityEditor.AssetDatabase.GUIDToAssetPath( guid );

            Instance = UnityEditor.AssetDatabase.LoadAssetAtPath<RandomNameGeneratorSetting>( assetPath );
        }
#endif
    }
}