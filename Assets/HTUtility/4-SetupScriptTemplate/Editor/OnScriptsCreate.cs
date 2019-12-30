/****************************************************
	文件：OnScriptsCreate.cs
	作者：HuskyT
	邮箱:  1005240602@qq.com
	日期：2019/09/08 1:53   	
	功能：在创建脚本的时候执行
*****************************************************/

using System.IO;

namespace HTUtility
{
    public class OnScriptsCreate : UnityEditor.AssetModificationProcessor //资源改变进程
    {
        /// <summary>
        /// 在创建资源的时候会调用此方法
        /// path为资源所在路径
        /// </summary>
        private static void OnWillCreateAsset(string path)
        {
            if (ScriptTemplateData.IsEditScriptTemplate == false) return;
            //1.获取新建的脚本的路径
            path = path.Replace(".meta", "");
            //2.安全检验脚本路径
            if (path.EndsWith(".cs"))
            {
                //3.读取所有内容为一个字符串
                string content = File.ReadAllText(path);
                //4.获取脚本类名
                string className = EditScriptTemplate.GetClassName(content);
                //5.更改  写入作者名、日期时间、命名空间、类名
                content = EditScriptTemplate.EditScriptInfo(className) + EditScriptTemplate.EditCodeTemplate(ScriptTemplateData.CustomNamespace, className);
                //6.写入文件
                File.WriteAllText(path, content);
                UnityEditor.AssetDatabase.Refresh();
            }
        }
    }
}
