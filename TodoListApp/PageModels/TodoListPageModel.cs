﻿using FreshMvvm;

using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListApp.PageModels
{
    public class TodoListPageModel : FreshBasePageModel
    {
        public TodoListPageModel()
        {

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
            base.ViewIsAppearing(sender, e);
        }
        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
        }
    }
}
