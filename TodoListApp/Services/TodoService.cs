using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using TodoListApp.Models;

namespace TodoListApp.Services
{
    public interface ITodoService
    {
        List<TodoModel> TodoItems { get; set; }

        bool AddTodoItem(TodoModel newTodoItem);
        bool DeleteTodoItem(TodoModel removedTodoItem);
        TodoModel GetTodoItem(Guid id);
        IList<TodoModel> GetTodoItems();
        bool UpdateTodoItem(TodoModel updatedTodoItem);
    }

    public class TodoService : ITodoService
    {
        private List<TodoModel> _todoItems;

        public List<TodoModel> TodoItems
        {
            get => _todoItems;
            set => _todoItems = value;
        }
        public TodoService()
        {
            TodoItems = new List<TodoModel>();
            TodoItems.Add(new TodoModel() { Id = Guid.NewGuid(), Title = "First task", Description = "first task is to look at the second task", DateAdded = DateTime.Now });
            TodoItems.Add(new TodoModel() { Id = Guid.NewGuid(), Title = "Second task", Description = "second task is to look at the third task", DateAdded = DateTime.Now });
            TodoItems.Add(new TodoModel() { Id = Guid.NewGuid(), Title = "Third task", Description = "third task is to look at the fourth task", DateAdded = DateTime.Now });
            TodoItems.Add(new TodoModel() { Id = Guid.NewGuid(), Title = "Fourth task", Description = "fourth task is to look at the fifth task", DateAdded = DateTime.Now });
            TodoItems.Add(new TodoModel() { Id = Guid.NewGuid(), Title = "Five task", Description = "fifth task is to look at the sixth task", DateAdded = DateTime.Now });
            TodoItems.Add(new TodoModel() { Id = Guid.NewGuid(), Title = "Sixth task", Description = "sixth task is to look at the seventh task", DateAdded = DateTime.Now });
            TodoItems.Add(new TodoModel() { Id = Guid.NewGuid(), Title = "Seventh task", Description = "seventh task is to look at the first task", DateAdded = DateTime.Now });
        }
        public TodoModel GetTodoItem(Guid id)
        {
            return _todoItems.FirstOrDefault(todo => todo.Id.Equals(id));
        }
        public IList<TodoModel> GetTodoItems()
        {
            return _todoItems.ToList();
        }
        public bool AddTodoItem(TodoModel newTodoItem)
        {
            _todoItems.Add(newTodoItem);
            return true;
        }
        public bool UpdateTodoItem(TodoModel updatedTodoItem)
        {
            var eTodoItem = GetTodoItem(updatedTodoItem.Id);
            int index = _todoItems.IndexOf(eTodoItem);
            _todoItems.RemoveAt(index);
            _todoItems.Insert(index, updatedTodoItem);
            return true;
        }
        public bool DeleteTodoItem(TodoModel removedTodoItem)
        {
            var eTodoItem = GetTodoItem(removedTodoItem.Id);
            int index = _todoItems.IndexOf(eTodoItem);
            _todoItems.RemoveAt(index);
            return true;
        }
    }
}
