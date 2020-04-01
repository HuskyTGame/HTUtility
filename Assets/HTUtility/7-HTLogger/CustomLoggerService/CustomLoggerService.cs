/****************************************************
	文件：CustomLoggerService.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/4/1 16:38:6
	功能：自定义的 日志输出 服务
*****************************************************/

using UnityEngine;

namespace HTUtility
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
    public class CustomLoggerService : HTSingleton<CustomLoggerService>
    {
        public void Init()
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
            HTLogger.Info("CustomLoggerService init done.");
        }
    }
}
