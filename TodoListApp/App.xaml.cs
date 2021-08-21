using FreshMvvm;

using System;
using System.ComponentModel;

using TodoListApp.PageModels;
using TodoListApp.Pages;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoListApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitContainer();
            var page = FreshPageModelResolver.ResolvePageModel<TodoListPageModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;
        }

        private void InitContainer()
        {
            //
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
