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
            XF.Material.Forms.Material.Init(this);
            InitializeComponent();            
            InitContainer();
            //var page = FreshPageModelResolver.ResolvePageModel<TodoListPageModel>();
            var page = FreshPageModelResolver.ResolvePageModel<DynamicListViewPageModel>();
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
