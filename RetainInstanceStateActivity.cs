namespace PlayingWithFragments
{
    using System;

    using Android.App;
    using Android.OS;
    using Android.Util;
    using Android.Widget;

    [Activity(Label = "Retain Instance State")]
    public class RetainInstanceStateActivity : Activity
    {
        public static readonly string FragmentTag = "state_fragment";
        private StateHolderFragment _fragment;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_retaininstance);

            EnsureStateFragmentExists();

            var button = FindViewById<Button>(Resource.Id.startThread );
            button.Click += HandleClick;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Log.Debug(MainActivity.TAG, "Activity is destroyed");
        }

        protected override void OnPause()
        {
            base.OnPause();
            Log.Debug(MainActivity.TAG, "Activity is pausing");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Log.Debug(MainActivity.TAG, "Activity is resuming");
        }

        protected override void OnStop()
        {
            base.OnStop();
            Log.Debug(MainActivity.TAG, "Activity is stopping");
        }

        private void EnsureStateFragmentExists()
        {
            _fragment = FragmentManager.FindFragmentByTag(FragmentTag) as StateHolderFragment;
            if (_fragment == null)
            {
                _fragment = new StateHolderFragment();
                var tx = FragmentManager.BeginTransaction();
                tx.Add(_fragment, FragmentTag);
                tx.Commit();
            }
            else
            {
                FindViewById<Button>(Resource.Id.startThread).Text = String.Format("Button has been clicked {0} times.", _fragment.Count);
            }
        }

        private void HandleClick(object sender, EventArgs e)
        {
            _fragment.Count++;
            FindViewById<Button>(Resource.Id.startThread).Text = String.Format("Button has been clicked {0} times.", _fragment.Count);
            _fragment.StartBackgroundStuff();
        }
    }
}
