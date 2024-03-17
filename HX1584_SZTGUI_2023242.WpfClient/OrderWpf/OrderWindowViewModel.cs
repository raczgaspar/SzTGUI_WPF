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

namespace HX1584_SZTGUI_2023242.WpfClient.OrderWpf
{
    public class OrderWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Order> Orders { get; set; }

        private Order selectedOrder;

        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set 
            {
                if (value != null)
                {
                    selectedOrder = new Order()
                    {
                        order_id = value.order_id,
                        item_id= value.item_id,
                        cart_id= value.cart_id,
                        amount= value.amount

                    };
                    OnPropertyChanged();
                    (DeleteOrderCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateOrderCommand { get; set; }
        public ICommand DeleteOrderCommand { get; set; }
        public ICommand UpdateOrderCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public OrderWindowViewModel()
        {
           if(!IsInDesignMode)
            {
                Orders = new RestCollection<Order>("http://localhost:64867/", "order", "hub");

                CreateOrderCommand = new RelayCommand(() =>
                {
                    Orders.Add(new Order()
                    {
                        order_id=selectedOrder.order_id,
                        item_id= selectedOrder.item_id,
                        cart_id= selectedOrder.cart_id,
                        amount= selectedOrder.amount
                    });
                });

                UpdateOrderCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Orders.Update(selectedOrder);
                    }
                    catch (ArgumentException msg)
                    {
                        ErrorMessage = msg.Message;
                    }
                });

                DeleteOrderCommand = new RelayCommand(() =>
                {
                    Orders.Delete(selectedOrder.order_id);
                },
                () =>
                {
                    return selectedOrder != null;
                });

                selectedOrder = new Order();
            }
        }

    }
}
