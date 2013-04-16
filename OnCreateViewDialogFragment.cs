namespace PlayingWithFragments
{
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Views;
    using Android.Views.InputMethods;
    using Android.Widget;

    public class OnCreateViewDialogFragment : DialogFragment
    {
        private EditText _valueTitle;
        private EditText _valueValue;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_mydialog, container, false);
            _valueTitle = view.FindViewById<EditText>(Resource.Id.dialogTitle);

            _valueValue = view.FindViewById<EditText>(Resource.Id.dialogValue);
            _valueValue.EditorAction += ValueValueOnEditorAction;
            return view;
        }

        public override void OnDismiss(IDialogInterface dialog)
        {
            base.OnDismiss(dialog);
            _valueValue.EditorAction -= ValueValueOnEditorAction;
        }

        private void ValueValueOnEditorAction(object sender, TextView.EditorActionEventArgs editorActionEventArgs)
        {
            editorActionEventArgs.Handled = false;

            if (editorActionEventArgs.ActionId == ImeAction.Done)
            {
                var parentActivity = Activity as DialogFragmentsActivity;
                if (parentActivity != null)
                {
                    parentActivity.UpdateValue(_valueTitle.Text, _valueValue.Text);
                    editorActionEventArgs.Handled = true;

                    // Make the keyboard go away.
                    var imm = (InputMethodManager)Activity.GetSystemService(Context.InputMethodService);
                    imm.HideSoftInputFromWindow(_valueValue.WindowToken, HideSoftInputFlags.None);

                    // 
                    Dismiss();
                }
            }
        }
    }
}
