using System;
using System.Collections.Generic;
using System.Threading;
using DevExpress.XtraSplashScreen;
using System.Windows.Forms;

namespace TLShoes.Common
{
    public class ThreadHelper
    {
        private const int INTERVAL_RELOAD = 1 * 1000; // 1 seconds

        private static Queue<Action> _actions = new Queue<Action>();

        public static void LoadForm(Action action, System.Windows.Forms.Form form = null)
        {
            if (form == null)
            {
                form = FormFactory<Main>.Get();
            }

            try
            {
                SplashScreenManager.ShowDefaultWaitForm(form, true, true, true, 250, "Đợi xíu nhé");
                action();
            }
            catch (Exception e)
            {
                SplashScreenManager.CloseDefaultWaitForm();
                throw e;
            }
            finally
            {
                SplashScreenManager.CloseDefaultWaitForm();
            }
        }

        public static void RunBackground(Action task, Action callback = null, Action<Exception> errorAction = null)
        {
            ThreadPool.QueueUserWorkItem((a) =>
            {
                try
                {
                    task();
                }
                catch (Exception e)
                {
                    if (errorAction != null)
                    {
                        errorAction(e);
                    }
                    else
                    {
                        throw e;
                    }
                }
                finally
                {
                    if (callback != null)
                    {
                        callback();
                    }
                }
            });
        }

        public static void ForceRunMainThread(Action task)
        {
            _actions.Enqueue(task);
        }

        public static void MainThreadCheck()
        {
            var timer = new System.Windows.Forms.Timer() { Interval = INTERVAL_RELOAD };
            timer.Start();
            timer.Tick += timer_Tick;
        }

        static void timer_Tick(object sender, EventArgs e)
        {
            while (_actions.Count > 0)
            {
                var action = _actions.Dequeue();
                action();
            }
        }
    }
}
