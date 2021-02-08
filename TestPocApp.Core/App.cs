using System;
using System.IO;
using System.Timers;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using TestPocApp.Core.Models;
using TestPocApp.Core.Services;
using TestPocApp.Core.ViewModels;
using TestPocApp.Data;

namespace TestPocApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            // Bulk Registration by Convention
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<SignInViewModel>();

            //ModelMapper.Init();

        }

        static iLocalDB localDatabase;
        public static iLocalDB LocalDB
        {
            get
            {
                if (localDatabase == null)
                {
                    localDatabase = new SQLiteDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "testPocDB.db3"));
                }
                return localDatabase;
            }
        }

    }
}
