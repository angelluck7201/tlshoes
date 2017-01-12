
using System.Windows.Forms;

namespace TLShoes.Common
{
    public class TimerControl
    {
        private const int INTERVAL_RELOAD = 60 * 1000; // 15 seconds

        private static Timer _timer;
        public static Timer Timer
        {
            get
            {
                if (_timer == null)
                {
                    _timer = new Timer { Interval = INTERVAL_RELOAD };
                    _timer.Start();
                }
                return _timer;
            }
        }

        public static void StopTimer()
        {
            if (_timer != null)
            {
                _timer.Dispose();
                _timer = null;
            }
        }
    }
}
