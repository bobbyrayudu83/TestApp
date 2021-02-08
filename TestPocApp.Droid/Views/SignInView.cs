
using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;

namespace TestPocApp.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "Sign In")]
    public class SignInView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SignInView);
        }
    }
}