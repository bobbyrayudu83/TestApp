
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Views.Fragments;
using System;

namespace TestPocApp.Droid.Fragment
{
    public class EnterDateFragment : MvxFragment, DatePickerDialog.IOnDateSetListener
    {
        //private EditText datePickerText;

        public EnterDateFragment()
        {
            this.RetainInstance = true;
        }

        public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            //this.HasOptionsMenu = true;

            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.CreateAccountView, container, false);

            //datePickerText = view.FindViewById<EditText>(Resource.Id.editServiceDate);
            //datePickerText.Focusable = false;
            //datePickerText.Click += delegate
            //{
            //    var dialog = new DatePickerDialogFragment(Activity, Convert.ToDateTime(datePickerText.Text), this);
            //    //dialog.Show(Android.App.FragmentManager, "date");
            //};

            //var set = this.CreateBindingSet<EnterTimeView, CreateAccountViewModel>();
            //set.Bind(datePickerText).To(vm => vm.Date);
            //set.Apply();

            return view;
        }

        public void OnDateSet(Android.Widget.DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            //datePickerText.Text = new DateTime(year, monthOfYear + 1, dayOfMonth).ToString();
        }

        //private class DatePickerDialogFragment : DialogFragment
        //{
        //    private readonly Context _context;
        //    private DateTime _date;
        //    private readonly DatePickerDialog.IOnDateSetListener _listener;

        //    public DatePickerDialogFragment(Context context, DateTime date, DatePickerDialog.IOnDateSetListener listener)
        //    {
        //        _context = context;
        //        _date = date;
        //        _listener = listener;
        //    }

        //    public override Dialog OnCreateDialog(Bundle savedState)
        //    {
        //        var dialog = new DatePickerDialog(_context, _listener, _date.Year, _date.Month - 1, _date.Day);
        //        return dialog;
        //    }
        //}

    }
}