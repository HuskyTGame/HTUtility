/****************************************************
    文件：ScriptTemplateData.cs
	作者：HuskyT
    邮箱：1005240602@qq.com
    日期：2019/9/8 0:26:3
	功能：脚本模板数据
*****************************************************/

using UnityEngine;
using UnityEditor;

namespace HTUtility
{
    public class ScriptTemplateData
    {
        public readonly static string GENERATE_SCRIPT_TEMPLATE_KEY = Application.productName + "@GenerateScriptTemplate";
        public const bool DefaultIsEditScriptTemplate = false;//是否开启编辑脚本模板  的默认值

        public readonly static string NAMESPACE_KEY = Application.productName + "@Namespace";
        public const string DefaultNamespace = "DefaultNamespace";//命名空间  的默认值

        /// <summary>
        /// 是否开启编辑脚本模板
        /// </summary>
        public static bool IsEditScriptTemplate
        {
            get
            {
                bool val = EditorPrefs.GetBool(GENERATE_SCRIPT_TEMPLATE_KEY);
                return val == false ? DefaultIsEditScriptTemplate : val;
            }
            set { EditorPrefs.SetBool(GENERATE_SCRIPT_TEMPLATE_KEY, value); }
        }

        /// <summary>
        /// 是否为默认命名空间
        /// </summary>
        public static bool IsDefaultNamespace
        {
            get { return CustomNamespace == DefaultNamespace; }
        }

        /// <summary>
        /// 自定义命名空间
        /// </summary>
        public static string CustomNamespace
        {
            get
            {
                string val = EditorPrefs.GetString(NAMESPACE_KEY);
                return string.IsNullOrEmpty(val) ? DefaultNamespace : val;
            }
            set { EditorPrefs.SetString(NAMESPACE_KEY, value); }
        }
    }
}