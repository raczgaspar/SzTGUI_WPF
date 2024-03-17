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

namespace HX1584_SZTGUI_2023242.WpfClient.ItemWpf
{
    public class ItemWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Item> Items { get; set; }

        private Item selectedItem;

        public Item SelectedItem
        {
            get { return selectedItem; }
            set 
            {
                if (value != null)
                {
                    selectedItem = new Item()
                    {
                        item_id = value.item_id,
                        productName=value.productName,
                        price=value.price,
                        fabr_country=value.fabr_country,
                        year_of_man=value.year_of_man
                    };
                    OnPropertyChanged();
                    (DeleteItemCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateItemCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }
        public ICommand UpdateItemCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public ItemWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Items = new RestCollection<Item>("http://localhost:64867/", "item", "hub");

                CreateItemCommand = new RelayCommand(() =>
                {
                    Items.Add(new Item()
                    {
                        item_id=selectedItem.item_id,
                        productName=selectedItem.productName,
                        price=selectedItem.price,
                        fabr_country=selectedItem.fabr_country,
                        year_of_man=selectedItem.year_of_man
                    });
                });

                UpdateItemCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Items.Update(selectedItem);
                    }
                    catch (ArgumentException msg)
                    {
                        ErrorMessage = msg.Message;
                    }
                });

                DeleteItemCommand = new RelayCommand(() =>
                {
                    Items.Delete(selectedItem.item_id);
                },
                () =>
                {
                    return selectedItem != null;
                });

                selectedItem = new Item();
            }
        }


    }
}
