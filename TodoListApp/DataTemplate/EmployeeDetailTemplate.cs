using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TodoListApp.PageModels;

using Xamarin.Forms;

namespace TodoListApp.DataTemplate
{
   public class EmployeeDetailTemplate : DataTemplateSelector
   {
      public Xamarin.Forms.DataTemplate LabelTemplate { get; set; }
      public Xamarin.Forms.DataTemplate PickerTemplate { get; set; }
      public Xamarin.Forms.DataTemplate SwitchTemplate { get; set; }

      protected override Xamarin.Forms.DataTemplate OnSelectTemplate(object item, BindableObject container)
      {
         if (item is KeyValuePair<string, Notifier<EmployeeDetailResponse>> employeeDetailNotifier)
         {
            switch (employeeDetailNotifier.Value.Val.DataType)
            {
               case DataType.Switch:
                  return SwitchTemplate;
               case DataType.Picker:
                  return PickerTemplate;
               default:
                  return LabelTemplate;
            }
         }
         return null;
      }
   }
}
