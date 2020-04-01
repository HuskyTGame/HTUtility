/****************************************************
	文件：TimerServiceForTest.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/4/1 15:52:7
	功能：测试脚本时用的计时器服务
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace HTUtility
{
    public class TimerServiceForTest : HTSingleton<TimerServiceForTest>
    {
        public class TimerItem
        {
            private bool mIsOpen;
            private bool mIsActive;
            private TimeSpan mStartTime;
            private TimeSpan mEndTime;
            private float mSumTime;

            /// <summary>
            /// 总时间（毫秒）
            /// </summary>
            public float SumTime
            {
                get
                {
                    if (mIsActive == false)
                        return 0.0f;
                    return mSumTime;
                }
            }

            public TimerItem(TimerServiceForTest timerSvc)
            {
                mIsOpen = true;
                mIsActive = timerSvc.mIsActive;
            }

            public void SetOpen(bool openTimer)
            {
                if (mIsActive == false) return;
                if (openTimer)
                {
                    mStartTime = DateTime.Now.TimeOfDay;
                }
                else
                {
                    mEndTime = DateTime.Now.TimeOfDay;
                    if (mEndTime > mStartTime)
                    {
                        mSumTime = (mEndTime - mStartTime).Milliseconds;
                    }
                }
                mIsOpen = openTimer;
            }
            public void SetActive(bool active)
            {
                mIsActive = active;
            }
        }

        private Dictionary<string, TimerItem> mTimerDict;
        private bool mIsActive;

        public void Init()
        {
            mTimerDict = new Dictionary<string, TimerItem>();
            mIsActive = true;
            Debug.Log("TimerServiceForTest init done.");
        }
        /// <summary>
        /// 设定计时功能开关
        /// </summary>
        public void SetActive(bool active)
        {
            if (mIsActive == active) return;
            mIsActive = active;
            foreach (var pair in mTimerDict)
            {
                pair.Value.SetActive(active);
            }
        }
        /// <summary>
        /// 订阅指定计时器
        /// </summary>
        public TimerItem Subscribe(string key)
        {
            TimerItem timer;
            if (mTimerDict.TryGetValue(key, out timer))
            {
                if (timer == null)
                    timer = new TimerItem(this);
                else
                    HTLogger.Error("重复订阅Timer：" + key);
            }
            timer = new TimerItem(this);
            mTimerDict.Add(key, timer);
            return timer;
        }
        /// <summary>
        /// 取消计时器订阅
        /// </summary>
        public bool Unsubscribe(string key)
        {
            return mTimerDict.Remove(key);
        }
        /// <summary>
        /// 设定计时器开始计时开关
        /// </summary>
        /// <param 计时器标识="key"></param>
        /// <param 是否开始/结束  计时="openTimer"></param>
        public void SetOpen(string key, bool openTimer)
        {
            TimerItem timer = GetTimer(key);
            if (timer != null)
                timer.SetOpen(openTimer);
            else
                HTLogger.Error("无法使用计时器功能，Timer：" + key + "尚未注册！");
        }
        /// <summary>
        /// 获取指定计时器
        /// </summary>
        public TimerItem GetTimer(string key)
        {
            TimerItem item;
            if (mTimerDict.TryGetValue(key, out item))
            {
                if (item != null)
                {
                    return item;
                }
            }
            return null;
        }
        /// <summary>
        /// 获取计时器计时总时间
        /// </summary>
        public float GetSumTime(string key)
        {
            TimerItem timer = GetTimer(key);
            if (timer != null)
                return timer.SumTime;
            else
            {
                HTLogger.Error("无法使用计时器功能，Timer：" + key + "尚未注册！");
                return 0.0f;
            }
        }
    }
}