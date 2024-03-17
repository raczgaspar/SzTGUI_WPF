using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using HX1584_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HX1584_SZTGUI_2023242.WpfClient.CustomerWpf
{

    public class CustomerWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Customer> Customers { get; set; }

        private Customer selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set {
                if (value != null)
                {
                    selectedCustomer = new Customer()
                    {
                        name = value.name,
                        customer_id = value.customer_id,
                        phone= value.phone,
                        city= value.city,
                        year= value.year,
                        cart_id= value.cart_id,

                    };
                    OnPropertyChanged();
                    (DeleteCustomerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }
        public ICommand UpdateCustomerCommand { get; set; }



        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public CustomerWindowViewModel()
        {
            if(!IsInDesignMode)
            {
                Customers = new RestCollection<Customer>("http://localhost:64867/", "customer", "hub");

                CreateCustomerCommand = new RelayCommand(() =>
                {
                    Customers.Add(new Customer()
                    {
                        name = selectedCustomer.name,
                        phone = selectedCustomer.phone,
                        city = selectedCustomer.city,
                        year = selectedCustomer.year
                    });
                });

                UpdateCustomerCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Customers.Update(selectedCustomer);
                    }
                    catch (ArgumentException msg)
                    {
                        ErrorMessage = msg.Message;
                    }
                });

                DeleteCustomerCommand = new RelayCommand(() =>
                {
                    Customers.Delete(selectedCustomer.customer_id);
                },
                () =>
                {
                    return selectedCustomer != null;
                });



                SelectedCustomer=new Customer();
            }
        }
    }
}
