/****************************************************
	文件：Exporter.cs
	作者：HuskyT
	邮箱:  1005240602@qq.com
	日期：2019/09/07 22:39   	
	功能：导出器
*****************************************************/

using System.IO;
using UnityEngine;
using UnityEditor;

namespace HTUtility
{
    public class Exporter
    {
        /// <summary>
        /// 待导出的文件夹
        /// </summary>
        private static string mAssetPathName = "Assets";

        [MenuItem("HTUtility/1.Exporter %e", false, 1)]
        private static void MenuClick()
        {
            EditorUtil.ExportUnityPackage(mAssetPathName, EditorUtil.GenerateUnityPackageName());
            EditorUtil.OpenFolder(Path.Combine(Application.dataPath, "../"));//打开Assets文件夹的上一级文件夹
        }
    }
}