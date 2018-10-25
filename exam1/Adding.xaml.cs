using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace exam1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Adding : Page
    {
        public Adding()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            try
            {
                StorageFile readfFile = await folder.GetFileAsync(title.Text);
                await FileIO.AppendTextAsync(readfFile, content.Text);

            }
            catch (Exception)
            {
                StorageFile file = await folder.CreateFileAsync(title.Text, CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(file, content.Text);
            }
            
            
        }
    }
}
