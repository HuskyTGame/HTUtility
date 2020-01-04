/****************************************************
	文件：EditorUtil.cs
	作者：HuskyT
	邮箱:  1005240602@qq.com
	日期：2019/09/07 23:22   	
	功能：编辑器常用工具API
*****************************************************/

using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace HTUtility
{
    public class EditorUtil
    {
        /// <summary>
        /// 复用菜单方法
        /// </summary>
        /// <param 菜单方法路径="menuItemPath"></param>
        public static void ReuseMenuItem(string menuItemPath)
        {
            EditorApplication.ExecuteMenuItem(menuItemPath);
        }
        /// <summary>
        /// 打开文件夹
        /// </summary>
        /// <param 文件夹路径="folderPath"></param>
        public static void OpenFolder(string folderPath)
        {
            Application.OpenURL("file:///" + folderPath);
        }
        /// <summary>
        /// 将指定资源导出成UnityPackage
        /// </summary>
        /// <param 待导出资源路径="assetPathName"></param>
        /// <param 导出文件的文件名="fileName"></param>
        public static void ExportUnityPackage(string assetPathName, string fileName)
        {
            EditorUtility.DisplayProgressBar("导出当前项目", string.Format("{0}正导出为UnityPackage", Application.productName), 0.1f);
            //递归导出指定文件夹下所有文件
            AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);
            EditorUtility.DisplayProgressBar("导出当前项目", string.Format("{0}正导出为UnityPackage", Application.productName), 1f);
            EditorUtility.ClearProgressBar();
        }
        /// <summary>
        /// 生成UnityPackage名
        /// 默认：项目名_日期.unitypackage
        /// </summary>
        /// <returns></returns>
        public static string GenerateUnityPackageName(string packageName = null)
        {
            if (packageName == null)
            {
                string projectName = Application.productName;
                return projectName + "_" + DateTime.Now.ToString("yyyyMMdd_HH") + ".unitypackage";
            }
            else
            {
                return packageName + "_" + DateTime.Now.ToString("yyyyMMdd_HH") + ".unitypackage";
            }
        }
        /// <summary>
        /// 打开/运行指定文件
        /// </summary>
        /// <param 文件的完整路径，包括后缀="fileFullPath"></param>
        public static void OpenFile(string fileFullPath)
        {
            System.Diagnostics.Process.Start(fileFullPath);
        }
        /// <summary>
        /// 打开当前项目
        /// </summary>
        public static void OpenCurrentProject()
        {
            EditorApplication.OpenProject(Application.dataPath.Replace("Assets", string.Empty));
        }
        /// <summary>
        /// 检查指定文件夹是否存在，不存在则创建
        /// </summary>
        /// <param name="folderPath"></param>
        public static void CheckFolder(string folderPath)
        {
            if (Directory.Exists(folderPath) == false)
            {
                Directory.CreateDirectory(folderPath);
            }
        }
        /// <summary>
        /// 验证字符串为数字（使用正则表达式）
        /// </summary>
        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[-+]?\d+(\.\d+)?$");
        }
    }
}