namespace PlayingWithFragments
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Android.App;
    using Android.OS;
    using Android.Util;

    public class StateHolderFragment : Fragment
    {
        public int Count { get; set; }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            RetainInstance = true;

            Log.Debug(MainActivity.TAG, "OnActivityCreated");
        }

        public override void OnAttach(Activity activity)
        {
            base.OnAttach(activity);
            Log.Debug(MainActivity.TAG, "Attached to the activity");
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            if (savedInstanceState != null)
            {
                Count = savedInstanceState.GetInt("count", 0);
            }
        }

        public override void OnDestroy()
        {
            Log.Debug(MainActivity.TAG, "Destroying the fragment");
            base.OnDestroy();
        }

        public override void OnDetach()
        {
            base.OnDetach();
            Log.Debug(MainActivity.TAG, "Detached from Activity");
        }

        public void StartBackgroundStuff()
        {
            Task.Factory.StartNew(LongRunningProcess)
                .ContinueWith(task => { Log.Debug(MainActivity.TAG, "Long running process  is Done!"); });
        }

        private void LongRunningProcess()
        {
            Log.Debug(MainActivity.TAG, "Start counting in the fragment");

            for (int i = 0; i < 15; i++)
            {
                Thread.Sleep(1000);
                Log.Debug(MainActivity.TAG, String.Format("{0} monkey", i));
            }
        }
    }
}
