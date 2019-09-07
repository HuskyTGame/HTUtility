/****************************************************
	文件：OpenMarkDown.cs
	作者：HuskyT
	邮箱:  1005240602@qq.com
	日期：2019/09/07 23:17   	
	功能：打开MarkDown文件
*****************************************************/

using System.IO;
using UnityEngine;
using UnityEditor;

namespace HTUtility
{
    public class OpenMarkDown
    {
        /// <summary>
        /// MarkDown文件名
        /// </summary>
        private static string mMarkDownFileName = "版本记录.md";

        [MenuItem("HTUtility/2.OpenMarkDown %m", false, 2)]
        private static void MenuClick()
        {
            EditorUtil.OpenFile(Path.Combine(Application.dataPath, mMarkDownFileName));
        }
    }
}