/****************************************************
	文件：GenerateDirectoryStructure.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2019/9/11 22:24:5
	功能：创建文件夹目录结构
*****************************************************/

/*
 * 写在前面：
 * 会自动创建和项目同名的根文件夹，如果已经存在，则创建需自定义名的根文件夹。
 * 想要修改，需要自行配置，代码很简单，一看就能改。
 * 主要是学习Rendering配置的文件夹结构。
 */

using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

namespace HTUtility
{
    public class GenerateDirectoryStructure
    {
        [MenuItem("HTUtility/5.GenerateDirectoryStructure #&g", false, 5)]
        private static void MenuClick()
        {
            GenerateStructure();
            AssetDatabase.Refresh();
            Debug.Log("文件夹目录结构生成完毕");
        }

        public static void Generate(string title)
        {
            GenerateStructure(title, true);
        }

        private static void GenerateStructure()
        {
            GenerateStructure(Application.productName);
        }
        private static void GenerateStructure(string rootDirectoryName, bool generateScript = false)
        {
            string forwardPath = Application.dataPath;
            string rootDirectory = GetRootDirectoryName(rootDirectoryName);//根文件夹
            //1.创建根文件夹下的文件夹
            string[] sameLvDirNameArray = new string[]
            {
                "Resources",
                "Scenes",
                "Scripts",
            };
            GenerateDirectoryWithSameLevel(Path.Combine(forwardPath, rootDirectory), sameLvDirNameArray);

            //2.创建Resources文件夹下的文件夹
            string[] sameLvDirNameArray2 = new string[]
            {
                "Materials",
                "Prefabs",
                "Shaders",
                "Textures",
            };
            GenerateDirectoryWithSameLevel(Path.Combine(forwardPath, rootDirectory, "Resources"), sameLvDirNameArray2);
            CreateScene(rootDirectory, Path.Combine(Path.Combine(forwardPath, rootDirectory, "Scenes")));
            //生成脚本
            if (generateScript)
            {
                string className = rootDirectoryName;
                if (EditorUtil.IsNumeric(rootDirectoryName[0].ToString()))
                {
                    className = rootDirectoryName.Remove(0, rootDirectoryName.IndexOf(".") + 1);
                }
                GenerateScript(className, Path.Combine(forwardPath, rootDirectory, "Scripts"));
            }
        }


        #region Helper
        /// <summary>
        /// 创建脚本，受自定义命名空间
        /// </summary>
        /// <param name="name"></param>
        /// <param name="folderPath"></param>
        private static void GenerateScript(string name, string folderPath)
        {
            string fullPath = folderPath + "/" + name + ".cs";
            FileStream fs = new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            fs.Close();
            //写入作者名、日期时间、命名空间、类名
            string content = EditScriptTemplate.EditScriptInfo(name) + EditScriptTemplate.EditCodeTemplate(ScriptTemplateData.CustomNamespace, name);
            //写入文件
            File.WriteAllText(fullPath, content);
        }
        /// <summary>
        /// 创建同级文件夹
        /// </summary>
        /// <param 之前的路径="forwardPath"></param>
        /// <param 同级文件夹名数组="sameLvDirNameArray"></param>
        private static void GenerateDirectoryWithSameLevel(string forwardPath, string[] sameLvDirNameArray)
        {
            if (sameLvDirNameArray == null | sameLvDirNameArray.Length <= 0) return;
            for (int i = 0; i < sameLvDirNameArray.Length; i++)
            {
                GenerateDirectory(Path.Combine(forwardPath, sameLvDirNameArray[i]));
            }
        }
        /// <summary>
        /// 获取根文件夹名
        /// </summary>
        /// <returns></returns>
        private static string GetRootDirectoryName()
        {
            return GetRootDirectoryName(Application.productName);
        }
        private static string GetRootDirectoryName(string rootDirectoryName)
        {
            string rootDirectory = rootDirectoryName;//根文件夹
            if (Directory.Exists(Path.Combine(Application.dataPath, rootDirectory)))
            {
                rootDirectory = "Root(自行更改文件夹名)";
            }
            return rootDirectory;
        }
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="folderPath"></param>
        private static void GenerateDirectory(string folderPath)
        {
            EditorUtil.CheckFolder(folderPath);
        }
        /// <summary>
        /// 创建Scene
        /// </summary>
        /// <param 场景名称="sceneName"></param>
        /// <param 场景存储文件夹路径="path"></param>
        private static void CreateScene(string sceneName, string path)
        {
            EditorUtil.CheckFolder(path);
            Scene scene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
            EditorSceneManager.SaveScene(scene, Path.Combine(path, sceneName + ".unity"));
        }
        #endregion
    }
}
