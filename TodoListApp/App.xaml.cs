using FreshMvvm;

using System;
using System.ComponentModel;

using TodoListApp.PageModels;
using TodoListApp.Pages;
using TodoListApp.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XF.Material.Forms.Resources;

namespace TodoListApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);
            InitContainer();
            var page = FreshPageModelResolver.ResolvePageModel<TodoListPageModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;
        }

        private void InitContainer()
        {
            FreshIOC.Container.Register<ITodoService, TodoService>();
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
