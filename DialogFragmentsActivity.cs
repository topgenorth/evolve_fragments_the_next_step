namespace PlayingWithFragments
{
    using Android.App;
    using Android.OS;
    using Android.Widget;

    [Activity(Label = "Dialog Fragments")]
    public class DialogFragmentsActivity : Activity
    {
        private OnCreateViewDialogFragment _onCreateViewFragment;
        private Button _showOnCreateDialogFragmentButton;
        private Button _showOnCreateViewDialogFragmentButton;

        public void UpdateValue(string name, string value)
        {
            Toast.MakeText(this, string.Format("{0}={1}", name, value), ToastLength.Long).Show();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dialogfragments);
            _showOnCreateDialogFragmentButton = FindViewById<Button>(Resource.Id.showOnCreateDialogFragment);
            _showOnCreateViewDialogFragmentButton = FindViewById<Button>(Resource.Id.showOnCreateViewDialogFragment);

            #region OnCreateDialog
            _showOnCreateDialogFragmentButton.Click += (sender, args) =>{
                new OnCreateDialogFragment().Show(FragmentManager, "OnCreateDialogFragment");
            };
            #endregion

            #region OnCreateView
            _showOnCreateViewDialogFragmentButton.Click += (sender, args) =>{
                _onCreateViewFragment = new OnCreateViewDialogFragment();

                var ft = FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.frameLayout1, _onCreateViewFragment, "OnCreateDialogViewFragment");
                ft.SetTransition(FragmentTransit.FragmentFade);
                ft.Commit();
            };
            #endregion

        }
    }
}
