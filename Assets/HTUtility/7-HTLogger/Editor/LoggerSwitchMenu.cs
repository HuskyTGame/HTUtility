/****************************************************
	文件：LoggerSwitchMenu.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/25 15:55:31
	功能：消息打印开关（决定 HTLogger 是否参与编译）
*****************************************************/

using UnityEngine;
using UnityEditor;
using System.IO;

namespace HTUtility
{
    public class LoggerSwitchMenu : MonoBehaviour
    {
        public enum LoggerModeEnum
        {
            //初始未设置时的默认值
            Default = 0,
            //关闭打印消息
            Close = 1,
            //开启打印消息
            Open = 2,
        }
        /// <summary>
        /// 使用 EditorPrefs 存储的 key 值
        /// </summary>
        private const string LOGGER_MODE_KEY = "Logger Mode";
        /// <summary>
        /// 菜单路径
        /// </summary>
        private const string LOGGER_SWITCH_MENU_PATH = "HTUtility/7.LoggerSwitch";
        /// <summary>
        /// HTLogger 脚本路径
        /// </summary>
        private static string mLoggerScriptPath = Application.dataPath + "/HTUtility/7-HTLogger/HTLogger.cs";
        /// <summary>
        /// LoggerMode 在未设置的时候默认值为 0
        /// </summary>
        private static LoggerModeEnum mLoggerMode = LoggerModeEnum.Default;

        /// <summary>
        /// 打印消息模式
        /// （此时可打印消息，若关闭打印消息功能，则不会编译，以优化性能）
        /// </summary>
        private static LoggerModeEnum LoggerMode
        {
            get
            {
                //第一次设置 LoggerMode
                if (mLoggerMode == LoggerModeEnum.Default)
                {
                    //获取存储的 LoggerMode 值，默认为 Close
                    mLoggerMode = (LoggerModeEnum)EditorPrefs.GetInt(LOGGER_MODE_KEY, (int)LoggerModeEnum.Close);
                }
                return mLoggerMode;
            }
            set
            {
                mLoggerMode = value;
                EditorPrefs.SetInt(LOGGER_MODE_KEY, (int)value);
            }
        }

        /// <summary>
        /// 切换 LoggerMode
        /// </summary>
        [MenuItem(LOGGER_SWITCH_MENU_PATH, false, 7)]
        private static void SwitchLoggerMode()
        {
            LoggerMode = LoggerMode == LoggerModeEnum.Open ? LoggerModeEnum.Close : LoggerModeEnum.Open;

            //若为打印消息模式：
            if (LoggerMode == LoggerModeEnum.Open)
            {
                //读取 HTLogger 脚本
                string[] contents = File.ReadAllLines(mLoggerScriptPath);
                for (int i = 0; i < contents.Length; i++)
                {
                    if (contents[i].StartsWith("//#define"))
                    {
                        if (contents[i].Contains("LOGGER_OPEN"))
                        {
                            contents[i] = "#define LOGGER_OPEN";
                            break;
                        }
                    }
                }
                File.WriteAllLines(mLoggerScriptPath, contents);
            }
            //若为关闭打印消息模式：
            else
            {
                //读取 HTLogger 脚本
                string[] contents = File.ReadAllLines(mLoggerScriptPath);
                for (int i = 0; i < contents.Length; i++)
                {
                    if (contents[i].StartsWith("#define"))
                    {
                        if (contents[i].Contains("LOGGER_OPEN"))
                        {
                            contents[i] = "//#define LOGGER_OPEN";
                            break;
                        }
                    }
                }
                File.WriteAllLines(mLoggerScriptPath, contents);
            }
            AssetDatabase.Refresh();
            Debug.Log("自定义消息打印功能：" + LoggerMode);
        }

        /// <summary>
        /// 切换 LoggerSwitch 的验证方法
        /// 每次编译都会执行此方法
        /// </summary>
        [MenuItem(LOGGER_SWITCH_MENU_PATH, true, 7)]
        private static bool SwitchLoggerModeValidate()
        {
            bool openLogger = LoggerMode == LoggerModeEnum.Open ? true : false;
            //将菜单设置成可切换状态
            //参数（菜单，依据什么切换）
            Menu.SetChecked(LOGGER_SWITCH_MENU_PATH, openLogger);
            return true;
        }
    }
}