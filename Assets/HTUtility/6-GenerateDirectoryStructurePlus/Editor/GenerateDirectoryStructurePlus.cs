/****************************************************
	文件：GenerateDirectoryStructurePlus.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2019/12/30 16:38:52
	功能：创建文件夹目录结构（升级版）可以自定义名称，同时会创建同名脚本。
*****************************************************/

using UnityEngine;
using UnityEditor;

namespace HTUtility
{
    public class GenerateDirectoryStructurePlus : EditorWindow
    {
        #region Configs
        private const string SAVE_KEY = "GenerateDirectoryStructurePlusSave1";
        #endregion

        private string mContent;
        /// <summary>
        /// 窗口输入的内容
        /// </summary>
        private string Content
        {
            set
            {
                if (mContent != value)
                {
                    mContent = value;
                    PlayerPrefs.SetString(SAVE_KEY, value);
                }
            }
            get
            {
                mContent = PlayerPrefs.GetString(SAVE_KEY);
                return mContent;
            }
        }

        [MenuItem("HTUtility/6.GenerateDirectoryStructurePlus #&p", false, 6)]
        private static void MenuClick()
        {
            var window = GetWindow<GenerateDirectoryStructurePlus>("设置单元学习名称");
            window.Show();
        }
        private void OnGUI()
        {
            GUILayout.Label(" 填写单元学习名称", new GUIStyle
            {
                fontSize = 16,
                fontStyle = FontStyle.Bold,
            });
            GUILayout.BeginHorizontal();
            GUILayout.Label("名称：", GUILayout.Width(80));
            Content = GUILayout.TextField(Content);
            GUILayout.EndHorizontal();
            if (GUILayout.Button("确认", GUILayout.Width(75), GUILayout.Height(25)))
            {
                GenerateDirectoryStructure.Generate(Content);
                Close();
                AssetDatabase.Refresh();
                Debug.LogFormat("{0}目录结构生成完毕", Content);
            }
        }
    }
}
