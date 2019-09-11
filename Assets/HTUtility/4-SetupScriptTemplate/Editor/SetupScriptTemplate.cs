/****************************************************
	文件：SetupScriptTemplate.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2019/9/8 1:55:46
	功能：设置脚本模板
*****************************************************/

using UnityEngine;
using UnityEditor;

namespace HTUtility
{
    public class SetupScriptTemplate : EditorWindow
    {
        [MenuItem("HTUtility/4.SetupScriptTemplate &s", false, 4)]
        private static void MenuClick()
        {
            var window = GetWindow<SetupScriptTemplate>("设置脚本模板");
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label(" 填写命名空间", new GUIStyle
            {
                fontSize = 16,
                fontStyle = FontStyle.Bold,
            });
            GUILayout.BeginHorizontal();
            GUILayout.Label("namespace：", GUILayout.Width(80));
            ScriptTemplateData.CustomNamespace = GUILayout.TextField(ScriptTemplateData.CustomNamespace);
            GUILayout.EndHorizontal();
            //开关
            ScriptTemplateData.IsEditScriptTemplate = GUILayout.Toggle(ScriptTemplateData.IsEditScriptTemplate, "是否开启编辑脚本模板", GUILayout.Width(150));
            if (GUILayout.Button("确认", GUILayout.Width(75), GUILayout.Height(25)))
            {
                Close();
            }
        }
    }
}
