using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ReactiveUI;
using UwpActivationTests.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwpActivationTests
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, IViewFor<MainViewModel>
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.WhenActivated(d =>
            {
                // Upon being activated, we should be able to trigger navigation to another page if we want.
                // However, because ActivationForViewFetcher uses the Loading event,
                // the Frame is not able to navigate to the page and gets stuck between states.
                //
                // I would expect this to display OtherPage,
                // but instead an empty screen is displayed.
                Frame.Navigate(typeof(OtherPage));
            });
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (MainViewModel) value; }
        }

        public MainViewModel ViewModel { get; set; } = new MainViewModel();
    }
}
