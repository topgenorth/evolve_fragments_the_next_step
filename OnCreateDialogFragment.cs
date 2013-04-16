namespace PlayingWithFragments
{
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Util;
    using Android.Views;
    using Android.Widget;

    public class OnCreateDialogFragment : DialogFragment
    {
        private View _view;

        public override void OnCancel(IDialogInterface dialog)
        {
            base.OnCancel(dialog);
            Log.Debug(MainActivity.TAG, "Back was pressed.");
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            _view = Activity.LayoutInflater.Inflate(Resource.Layout.fragment_mydialog, null);
            var builder = new AlertDialog.Builder(Activity);
            Dialog dialog = builder.SetTitle("OnCreateDialog Fragment")
                                   .SetPositiveButton("Ok", ClickedOkay)
                                   .SetView(_view).Create();
            return dialog;
        }

        public override void OnDismiss(IDialogInterface dialog)
        {
            base.OnDismiss(dialog);
            Log.Debug(MainActivity.TAG, "Bye bye!");
        }

        private void ClickedOkay(object sender, DialogClickEventArgs e)
        {
            var name = _view.FindViewById<EditText>(Resource.Id.dialogTitle);
            var value = _view.FindViewById<EditText>(Resource.Id.dialogValue);
            var msg = string.Format("{0} = {1}", name.Text, value.Text);

            Toast.MakeText(Activity, msg, ToastLength.Long).Show();
        }
    }
}
