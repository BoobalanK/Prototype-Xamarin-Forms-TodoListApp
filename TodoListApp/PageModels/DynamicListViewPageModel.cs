using FreshMvvm;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

using TodoListApp.Models;

using Xamarin.Forms;

namespace TodoListApp.PageModels
{
   public class DynamicListViewPageModel : FreshBasePageModel
   {
      private ObservableCollection<KeyValuePair<string, Notifier<EmployeeDetailResponse>>> _employees;

      public ObservableCollection<KeyValuePair<string, Notifier<EmployeeDetailResponse>>> EmployeeDetails
      {
         get => _employees;
         set
         {
            if (_employees != value)
            {
               _employees = value;
               RaisePropertyChanged(nameof(EmployeeDetails));
            }
         }
      }

      public ICommand OnClearCommand { get; }

      public DynamicListViewPageModel()
      {
         OnClearCommand = new Command((obj) => OnClear(obj));
      }
      public override void Init(object initData)
      {
         EmployeeDetails = new ObservableCollection<KeyValuePair<string, Notifier<EmployeeDetailResponse>>>();
         foreach (var item in EmployeeDetailResponse.Create())
         {
            EmployeeDetails.Add(new KeyValuePair<string, Notifier<EmployeeDetailResponse>>(item.Val.Id, item));
         }
         base.Init(initData);
      }
      public void OnClear(object obj)
      {
         var employeeDetail = (EmployeeDetailResponse)((KeyValuePair<string, Notifier<EmployeeDetailResponse>>)obj).Value.Val.Clone();
         employeeDetail.Value = string.Empty;
         for (int i = 0; i < EmployeeDetails.Count; i++)
         {
            var emplKeyValuePair = EmployeeDetails[i];
            if (emplKeyValuePair.Key == employeeDetail.Id)
            {
               emplKeyValuePair.Value.Val = employeeDetail;
               EmployeeDetails[i] = emplKeyValuePair;
            }
         }
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
   public class Notifier<TValue> : INotifyPropertyChanged
   {
      /// -----------------------------------------------------------------------------------------------
      #region Private Variables
      ///------------------------------------------------------------------------------------------------
      /// 
      private TValue _value;
      private bool _isChanged;
      /// 
      #endregion
      /// -----------------------------------------------------------------------------------------------
      #region Public Properties and Events
      ///------------------------------------------------------------------------------------------------
      /// 
      /// -----------------------------------------------------------------------------------------------
      /// Name        PropertyChanged
      /// 
      /// <summary>   Property changed event for support notifying the value change.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// -----------------------------------------------------------------------------------------------
      /// 
      public event PropertyChangedEventHandler PropertyChanged;
      /// 
      /// -----------------------------------------------------------------------------------------------
      /// Name        Val
      /// 
      /// <summary>   The property that will notify when the value change is happened.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// -----------------------------------------------------------------------------------------------
      /// 
      public TValue Val
      {
         get => _value;
         set
         {
            if (!_value.Equals(value))
            {
               _value = value;
               _isChanged = true;
            }
            //
            if (this.PropertyChanged != null)
            {
               this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(TValue)));
            }
         }
      }
      /// 
      /// -----------------------------------------------------------------------------------------------
      /// Name        IsChanged
      /// 
      /// <summary>   A property will set to true if the property <see cref="Val"/> value changes. Stays false if not.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// -----------------------------------------------------------------------------------------------
      /// 
      public bool IsChanged
      {
         get => _isChanged;
         set
         {
            if (!_isChanged.Equals(value))
            {
               _isChanged = value;
            }
            //
            if (this.PropertyChanged != null)
            {
               this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(TValue)));
            }
         }
      }
      /// 
      #endregion
      /// -----------------------------------------------------------------------------------------------
      #region Public Constructor
      /// -----------------------------------------------------------------------------------------------
      /// 
      /// -----------------------------------------------------------------------------------------------
      /// Name        Notifier
      /// 
      /// <summary>   Creates a new instance of the Notifier class.
      /// </summary>
      /// <param name="val">The value of the object.</param> 
      /// <remarks>
      /// </remarks>
      /// -----------------------------------------------------------------------------------------------
      ///
      public Notifier(TValue val)
      {
         _value = val;
         _isChanged = false;
      }
      /// 
      #endregion
      /// -----------------------------------------------------------------------------------------------
   }
   public class EmployeeDetailResponse : BindableObject
   {
      public string Id { get; set; }
      public DataType DataType { get; set; }
      public string Name { get; set; }
      public object Value { get; set; }
      public IList<string> Source { get; set; }

      public static List<Notifier<EmployeeDetailResponse>> Create()
      {
         var employeeDetailList = new List<Notifier<EmployeeDetailResponse>>();
         employeeDetailList.Add(new Notifier<EmployeeDetailResponse>(new EmployeeDetailResponse() { Id = Guid.NewGuid().ToString(), DataType = DataType.Label, Name = "Full name", Value = "Boobalan" }));
         employeeDetailList.Add(new Notifier<EmployeeDetailResponse>(new EmployeeDetailResponse() { Id = Guid.NewGuid().ToString(), DataType = DataType.Switch, Name = "Gender", Value = Gender.Male }));
         employeeDetailList.Add(new Notifier<EmployeeDetailResponse>(new EmployeeDetailResponse() { Id = Guid.NewGuid().ToString(), DataType = DataType.Picker, Name = "Department", Value = Department.DOTNET.ToString(), Source = new List<string> { "DOTNET", "Java" } }));
         return employeeDetailList;
      }
      public object Clone()
      {
         return this.MemberwiseClone();
      }
   }
   public class Employee
   {
      public string FullName { get; set; }
      public Gender Gender { get; set; }
      public Department Department { get; set; }
   }
   public enum Gender
   {
      Male,
      Female
   }
   public enum Department
   {
      DOTNET,
      Java
   }
   public enum DataType
   {
      Label,
      Switch,
      Picker
   }
}
