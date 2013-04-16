namespace PlayingWithFragments
{
    using Android.App;
    using Android.OS;
    using Android.Preferences;

    public class SimplePreferenceFragment : PreferenceFragment 
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AddPreferencesFromResource(Resource.Xml.preferences);            
        }
    }
}
