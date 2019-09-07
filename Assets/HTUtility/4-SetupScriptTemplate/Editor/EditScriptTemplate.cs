/****************************************************
    文件：EditScriptTemplate.cs
	作者：HuskyT
    邮箱：1005240602@qq.com
    日期：2019/9/8 0:16:45
	功能：编辑脚本模板
*****************************************************/

using System;
using System.Text;

namespace HTUtility
{
    public class EditScriptTemplate
    {
        /// <summary>
        /// 编辑Code模板
        /// </summary>
        /// <param 命名空间="nameSpace"></param>
        /// <param 类名="className"></param>
        /// <returns></returns>
        public static string EditCodeTemplate(string nameSpace, string className)
        {
            StringBuilder sb = new StringBuilder();
            //Using
            sb.AppendLine("using System;");
            sb.AppendLine("using UnityEngine;");
            sb.AppendLine();
            //命名空间
            sb.AppendLine($"namespace {nameSpace}");
            sb.AppendLine("{");
            //类名
            sb.AppendLine($"\tpublic class {className} : MonoBehaviour");
            sb.AppendLine("\t{");
            //方法
            sb.AppendLine($"\t\tprivate void Start()");
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t\t//Code  Here:");
            sb.AppendLine("\t\t}");

            sb.AppendLine("\t}");
            sb.AppendLine("}");
            return sb.ToString();
        }
        /// <summary>
        /// 编辑脚本头信息
        /// </summary>
        /// <returns></returns>
        public static string EditScriptInfo(string className)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("/****************************************************");
            sb.AppendLine($"\t文件：{className}.cs");
            //sb.AppendLine($"\t作者：{Environment.UserName}");
            sb.AppendLine($"\t作者：HuskyT");
            sb.AppendLine("\t邮箱：1005240602@qq.com");
            sb.AppendLine($"\t日期：{string.Concat(DateTime.Now.Year, "/", DateTime.Now.Month, "/", DateTime.Now.Day, " ", DateTime.Now.Hour, ":", DateTime.Now.Minute, ":", DateTime.Now.Second)}");
            sb.AppendLine("\t功能：");
            sb.AppendLine("*****************************************************/");
            sb.AppendLine();
            return sb.ToString();
        }
        /// <summary>
        /// 获取类名
        /// </summary>
        /// <param 脚本内容="content"></param>
        /// <returns></returns>
        public static string GetClassName(string content)
        {
            string[] strArray = content.Split(' ');
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i] == "class")
                {
                    return strArray[i + 1];
                }
            }
            return null;
        }
    }
}