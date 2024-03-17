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
using System.Windows.Controls;

namespace HX1584_SZTGUI_2023242.WpfClient.CartWpf
{
    public class CartWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Cart> Carts { get; set; }

        private Cart selectedCart;

        public Cart SelectedCart
        {
            get { return selectedCart; }
            set 
            {
                if (value != null)
                {
                    selectedCart = new Cart()
                    {
                        cart_ID=value.cart_ID,
                        comment=value.comment,
                        delivered=value.delivered,
                        priority=value.priority,

                    };
                    OnPropertyChanged();
                    (DeleteCartCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateCartCommand { get; set; }
        public ICommand DeleteCartCommand { get; set; }
        public ICommand UpdateCartCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public CartWindowViewModel()
        {
            Carts = new RestCollection<Cart>("http://localhost:64867/", "cart", "hub");

            CreateCartCommand = new RelayCommand(() =>
            {
                Carts.Add(new Cart()
                {
                    cart_ID=selectedCart.cart_ID,
                    comment=selectedCart.comment,
                    delivered=selectedCart.delivered,
                    priority=selectedCart.priority,
                });
            });

            UpdateCartCommand = new RelayCommand(() =>
            {
                try
                {
                    Carts.Update(selectedCart);
                }
                catch (ArgumentException msg)
                {
                    ErrorMessage = msg.Message;
                }
            });

            DeleteCartCommand = new RelayCommand(() =>
            {
                Carts.Delete(selectedCart.cart_ID);
            },
            () =>
            {
                return selectedCart != null;
            });

            selectedCart = new Cart();
        }

    }
}
