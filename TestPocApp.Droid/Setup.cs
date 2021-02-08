using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Core;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using TestPocApp.Core;
using TestPocApp.Core.Infrastructure;

namespace TestPocApp.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }


        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
        }

    }
}