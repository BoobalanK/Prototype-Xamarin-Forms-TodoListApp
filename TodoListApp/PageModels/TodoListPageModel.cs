using FreshMvvm;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using TodoListApp.Models;
using TodoListApp.Services;

namespace TodoListApp.PageModels
{
    public class TodoListPageModel : FreshBasePageModel
    {
        private ObservableCollection<TodoModel> _todoList;
        private readonly ITodoService _todoService;

        public ObservableCollection<TodoModel> TodoList
        {
            get => _todoList;
            set
            {
                if (_todoList != value)
                {
                    _todoList = value;
                    RaisePropertyChanged(nameof(TodoList));
                }
            }
        }
        public TodoListPageModel(ITodoService todoService)
        {
            _todoService = todoService;
        }
        public override void Init(object initData)
        {
            base.Init(initData);
        }
        public override void ReverseInit(object returnedData)
        {
            base.ReverseInit(returnedData);
        }
        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            TodoList = new ObservableCollection<TodoModel>(_todoService.TodoItems);
            base.ViewIsAppearing(sender, e);
        }
        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
        }
    }
}
