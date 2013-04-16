namespace PlayingWithFragments
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Android.App;
    using Android.Graphics;
    using Android.OS;
    using Android.Util;
    using Android.Widget;

    using JavaObject = Java.Lang.Object;

    public class MyConfigStateObject : JavaObject
    {
        public Task SomeBackgroundTask { get; set; }
        public Bitmap SomeBitmap { get; set; }
    }

    [Activity(Label = "State is Painful")]
    public class StateIsPainfulActivity : Activity
    {
        private Button _button;
        private Task _monkeyCounterTask;

        public override JavaObject OnRetainNonConfigurationInstance()
        {
            var stateObject = new MyConfigStateObject();
            stateObject.SomeBackgroundTask = _monkeyCounterTask;
            return stateObject;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_retaininstance);
            _button = FindViewById<Button>(Resource.Id.startThread);
            _button.Click += ButtonOnClick;

            if (LastNonConfigurationInstance != null)
            {
                LoadImportStuffForFormFrom((MyConfigStateObject)LastNonConfigurationInstance);
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Log.Debug(MainActivity.TAG, "State is Painful is Destroying.");
        }

        protected override void OnPause()
        {
            base.OnPause();
            Log.Debug(MainActivity.TAG, "State is Painful is pausing.");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Log.Debug(MainActivity.TAG, "State is Painful is Resuming.");
        }

        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            _monkeyCounterTask = new Task(() =>{
                Log.Debug(MainActivity.TAG, "Start counting in the PainfulActivity");
                for (var i = 0; i < 25; i++)
                {
                    Thread.Sleep(1000);
                    Log.Debug(MainActivity.TAG, String.Format("{0} monkey", i));
                }
			});
			_monkeyCounterTask.ContinueWith(task => { Log.Debug(MainActivity.TAG, "Long running process  is Done!"); });

			_monkeyCounterTask.Start();
        }

        private void LoadImportStuffForFormFrom(MyConfigStateObject data)
        {
            Log.Debug(MainActivity.TAG, "Loading important stuff.");
            _monkeyCounterTask = data.SomeBackgroundTask;
        }
    }
}
