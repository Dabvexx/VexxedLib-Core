using System.Timers;

namespace VexxLib.Utils.Timers
{
    public enum TimerState
    {
        Seconds = 0,
        Minutes = 1,
        Hours = 2
    }

    public class Timer //: Timer, ITimer
    {
        private float Duration;

        public float duration
        {
            private get
            {
                return this.Duration;
            }
            set
            {
                this.Duration = value;
            }
        }

        private System.Timers.Timer timer;

        // Need a delegate and event

        protected Timer(float duration, TimerState state = 0)
        {
            if (state == TimerState.Seconds)
            {
                this.duration = duration * 1000;
            }
        }

        /// <summary>
        /// Starts the timer countdown.
        /// </summary>
        public void StartTimer()
        {
            timer = new System.Timers.Timer(duration);
            timer.Enabled = true;
            timer.Start();
        }

        public void StartResettingTimer()
        {
            timer = new System.Timers.Timer(duration);
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
        }

        /// <summary>
        /// Ends timer without calling end method.
        /// </summary>
        public void Cancel()
        {
            timer.Stop();
            timer.Enabled = false;
            
        }

        /// <summary>
        /// Ends the timer while calling end method.
        /// </summary>
        public void End()
        {
            timer.Stop();
            timer.Enabled = false;
        }

        private void InvokeTimer()
        {

        }
    }
}