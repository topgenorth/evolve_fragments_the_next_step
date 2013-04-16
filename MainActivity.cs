namespace PlayingWithFragments
{
    using System;
    using System.Collections.Generic;

    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Views;
    using Android.Widget;

    [Activity(Label = "MainActivity", MainLauncher = true)]
    public class MainActivity : ListActivity
    {
        private List<SampleActivity> _activities;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set up the list of sample activity for this menu....
            _activities = new List<SampleActivity>
                              {
                                  new SampleActivity("State Is Painful", typeof(StateIsPainfulActivity )),
                                  new SampleActivity("Retain Instance", typeof(RetainInstanceStateActivity)),
                                  new SampleActivity("Dialog Fragment", typeof(DialogFragmentsActivity)),
                                  new SampleActivity("Preference Fragment", typeof(PreferenceFragmentActivity))
                              };

            // Bind the sample activities to the ListAdapter....
            ListAdapter = new ArrayAdapter<SampleActivity>(this,
                                                           Android.Resource.Layout.SimpleListItem1,
                                                           Android.Resource.Id.Text1,
                                                           _activities);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            // Startup the activity that the user selected from the menu.
            var activityToStart = _activities[position];
            activityToStart.Start(this);
        }

        public static readonly string TAG = "Frags";
    }

    /// <summary>
    ///   This class will hold some metadata about the Activities this application will run.
    /// </summary>
    public class SampleActivity
    {
        /// <summary>
        /// </summary>
        /// <param name="title">The title of the Activity</param>
        /// <param name="activityToLaunch">The type of the activity to launch</param>
        public SampleActivity(string title, Type activityToLaunch)
        {
            // TODO [TO201304142350] use reflection to get the Label from the ActivityAttribute?
            Title = title;
            ActivityToLaunch = activityToLaunch;
        }

        private Type ActivityToLaunch { get; set; }

        private string Title { get; set; }

        public void Start(Activity context)
        {
            var i = new Intent(context, ActivityToLaunch);
            context.StartActivity(i);
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
