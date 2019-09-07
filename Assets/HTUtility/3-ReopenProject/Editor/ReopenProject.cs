/****************************************************
	文件：ReopenProject.cs
	作者：HuskyT
	邮箱:  1005240602@qq.com
	日期：2019/09/07 23:51   	
	功能：一键重启项目
*****************************************************/

using UnityEngine;
using UnityEditor;

namespace HTUtility
{
    public class ReopenProject : EditorWindow
    {
        [MenuItem("HTUtility/3.ReopenProject &r", false, 3)]
        private static void DoReopenProject()
        {
            var window = GetWindow<ReopenProject>("重启项目");
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("是否重启当前项目", new GUIStyle
            {
                fontSize = 18,
                fontStyle = FontStyle.Bold,
            });
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("重启", GUILayout.Width(75), GUILayout.Height(25)))
            {
                //关闭当前窗口
                Close();
                //打开当前项目
                EditorUtil.OpenCurrentProject();
            }
            else if (GUILayout.Button("取消", GUILayout.Width(75), GUILayout.Height(25)))
            {
                //关闭当前窗口
                Close();
            }
            GUILayout.EndHorizontal();
        }
    }
}