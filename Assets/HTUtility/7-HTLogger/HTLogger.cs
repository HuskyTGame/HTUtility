/****************************************************
	文件：HTLogger.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/25 14:4:3
	功能：打印消息接口
*****************************************************/
//#define LOGGER_OPEN
using System;

namespace HTUtility
{
    /*
     * 使用方法：
     * 1.新建 Class 实现 ILoggerListener 接口，实现 Log 方法
     * 2.初始化 HTLogger
     * 3.向 HTLogger 中不同的 Channel 分别添加 LoggerListener 监听
     * 4.在菜单栏“HTUtility/6.LoggerSwitch”中开启（切换）Logger 开关
     */
    public interface ILoggerListener
    {
        void Log(string msg);
    }
    public class HTLogger : HTSingleton<HTLogger>
    {
        public enum Channel
        {
            Default = 0,
            //打印信息（程序正常运行的信息）
            Info,
            //待完成的信息
            Todo,
            //debug时输出的信息
            Debug,
            //警告信息
            Warning,
            //错误信息
            Error,
        }
        private static bool mHasInit = false;
        //是否需要包装 消息 （给消息加上 日期 和 Channel）
        private static bool mNeedPackageMsg = false;
        private static bool[] mChannelEnableArray;
        private static ILoggerListener[] mChannelListenerArray;

        /// <summary>
        /// 初始化，默认开启所有频道
        /// </summary>
        public void Init(bool needPackageMsg = true)
        {
            mChannelEnableArray = new bool[Enum.GetValues(typeof(Channel)).Length];
            mChannelListenerArray = new ILoggerListener[Enum.GetValues(typeof(Channel)).Length];
            //默认初始开启所有信息打印通道
            for (int i = 0; i < mChannelEnableArray.Length; i++)
            {
                mChannelEnableArray[i] = true;
            }
            mNeedPackageMsg = needPackageMsg;
            mHasInit = true;
        }
        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            if (mHasInit == false) return;
            for (int i = 0; i < mChannelListenerArray.Length; i++)
            {
                RemoveListener((Channel)i);
            }
            mChannelListenerArray = null;
            mChannelEnableArray = null;
            mNeedPackageMsg = false;
            mHasInit = false;
        }
        /// <summary>
        /// 设置频道开关状态
        /// </summary>
        /// <param 频道="channel"></param>
        /// <param 开关状态="state"></param>
        public void SetChannelState(Channel channel, bool state)
        {
            if (mHasInit == false) return;
            mChannelEnableArray[(int)channel] = state;
        }
        public void AddListener(Channel channel, ILoggerListener listener)
        {
            if (mHasInit == false) return;
            if (mChannelEnableArray[(int)channel] == false) return;
            mChannelListenerArray[(int)channel] = listener;
        }
        public void RemoveListener(Channel channel)
        {
            if (mHasInit == false) return;
            mChannelListenerArray[(int)channel] = null;
        }

        #region 打印消息
        public static void Info(string msg)
        {
#if LOGGER_OPEN
            LogMsg(msg, Channel.Info, mNeedPackageMsg);
#endif
        }
        public static void Todo(string msg)
        {
#if LOGGER_OPEN
            LogMsg(msg, Channel.Todo, mNeedPackageMsg);
#endif
        }
        public static void Debug(string msg)
        {
#if LOGGER_OPEN
            LogMsg(msg, Channel.Debug, mNeedPackageMsg);
#endif
        }
        public static void Warning(string msg)
        {
#if LOGGER_OPEN
            LogMsg(msg, Channel.Warning, mNeedPackageMsg);
#endif
        }
        public static void Error(string msg)
        {
#if LOGGER_OPEN
            LogMsg(msg, Channel.Error, mNeedPackageMsg);
#endif
        }
        public static void LogMsg(string msg, Channel channel, bool needPackageMsg)
        {
            if (mHasInit == false) return;
            if (mChannelEnableArray[(int)channel] == false) return;
            ILoggerListener logger = mChannelListenerArray[(int)channel];
            if (logger == null) return;
            string message = msg;
            if (needPackageMsg)
                message = PackageMsg(msg, channel);
            logger.Log(message);
            Console.WriteLine(message);
        }
        #endregion

        /// <summary>
        /// 包装信息
        /// </summary>
        /// <param 信息="msg"></param>
        /// <param 频道="channel"></param>
        /// <returns></returns>
        private static string PackageMsg(string msg, Channel channel)
        {
            return string.Format("({0})[{1}]：{2}", DateTime.Now.ToString(), channel, msg);
        }
    }
}
