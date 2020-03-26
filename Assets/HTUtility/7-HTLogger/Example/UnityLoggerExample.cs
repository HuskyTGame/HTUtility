/****************************************************
	文件：UnityLoggerListener.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/25 15:19:55
	功能：例子：展示如何在 Unity 中使用 HTLogger
*****************************************************/

using UnityEngine;

namespace HTUtility.Example
{
    public class UnityLoggerExample : MonoBehaviour
    {
        public class UnityDebugListener : ILoggerListener
        {
            public void Log(string msg)
            {
                Debug.Log(msg);
            }
        }
        public class UnityWarningListener : ILoggerListener
        {
            public void Log(string msg)
            {
                Debug.LogWarning(msg);
            }
        }
        public class UnityErrorListener : ILoggerListener
        {
            public void Log(string msg)
            {
                Debug.LogError(msg);
            }
        }

        private void Start()
        {
            UnityDebugListener unityDebugListener = new UnityDebugListener();
            UnityWarningListener unityWarningListener = new UnityWarningListener();
            UnityErrorListener unityErrorListener = new UnityErrorListener();
            HTLogger.Instance.Init(true);
            HTLogger.Instance.AddListener(HTLogger.Channel.Info, unityDebugListener);
            HTLogger.Instance.AddListener(HTLogger.Channel.Todo, unityDebugListener);
            HTLogger.Instance.AddListener(HTLogger.Channel.Debug, unityDebugListener);
            HTLogger.Instance.AddListener(HTLogger.Channel.Warning, unityWarningListener);
            HTLogger.Instance.AddListener(HTLogger.Channel.Error, unityErrorListener);


            HTLogger.Info("测试 Logger 成功！");
            HTLogger.Todo("测试 Logger 成功！");
            HTLogger.Debug("测试 Logger 成功！");
            HTLogger.Warning("测试 Logger 成功！");
            HTLogger.Error("测试 Logger 成功！");
        }
    }

}