
using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;

namespace TestPocApp.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "Create Account")]
    public class CreateAccountView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CreateAccountView);
        }
    }
}