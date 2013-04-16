namespace PlayingWithFragments
{
    using System;

    using Android.App;
    using Android.OS;
    using Android.Widget;

    [Activity(Label = "Preference Fragment")]
    public class PreferenceFragmentActivity : Activity
    {
        private Button _preferenceButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_preference1);


            _preferenceButton = FindViewById<Button>(Resource.Id.showPreferenceFragmentButton);
            _preferenceButton.Click += PreferenceButtonOnClick;
        }

        private void PreferenceButtonOnClick(object sender, EventArgs eventArgs)
        {
            var frag = new SimplePreferenceFragment();
            var ft = FragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.prefencelayout1, frag, "simplepreferencefrag1");
            ft.Commit();
        }
    }
}
