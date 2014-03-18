using CancerDiagnostics.Common;
using Imaging;
using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CancerDiagnostics
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MID : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public MID()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
            diagnosis.Text = "normal";
            resultBox.Fill = new SolidColorBrush(Color.FromArgb(255, 16, 145, 16));
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private async void openImage_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fop = new FileOpenPicker();
            fop.FileTypeFilter.Clear();
            fop.FileTypeFilter.Add(".bmp");
            fop.FileTypeFilter.Add(".jpeg");
            fop.FileTypeFilter.Add(".jpg");
            fop.FileTypeFilter.Add(".png");


            StorageFile file = await fop.PickSingleFileAsync();


            if (file == null)
                return;

            IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);

            
            WriteableBitmap bp = new WriteableBitmap(512, 512);
            bp.SetSource(fileStream);

            orig.Source = bp;
            byte[] bitez = bp.ToByteArray();
            int[,] imageC = new int[bp.PixelWidth, bp.PixelHeight];
            int[,] imageProcess = new int[bp.PixelWidth, bp.PixelHeight];
            for (int x = 0; x < bp.PixelWidth; x++)
                for (int y = 0; y < bp.PixelHeight; y++)
                {
                    int baseIndex = (y * bp.PixelWidth + x) * 4;
                    int a = bitez[baseIndex];
                    int r = bitez[baseIndex + 1];
                    int g = bitez[baseIndex + 2];
                    int b = bitez[baseIndex + 3];

                    double bright =
                    (0.2126 * r) + (0.7152 * g) + (0.0722 * b);
                    imageC[x, y] = (int)(bright);
                }

            DWT2D d = new DWT2D(imageC);
            imageProcess = d.Transform(imageC);


            WriteableBitmap sbp = new WriteableBitmap(8, 8);

            double[] numout = new double[8 * 8];
            for (int x = 7; x < 15; x++)
            {
                for (int y = 8; y < 16; y++)
                {
                    sbp.SetPixel(x - 7, y - 8, Color.FromArgb(255, (byte)imageProcess[x, y], (byte)imageProcess[x, y], (byte)imageProcess[x, y]));
                    numout[8 * (x - 7) + y - 8] = imageProcess[x, y];
                }
            }
            WriteableBitmap s = sbp.Resize(200, 200, Windows.UI.Xaml.Media.Imaging.WriteableBitmapExtensions.Interpolation.NearestNeighbor);
           
            dwt.Source = s;
             StorageFolder root = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
           
            StorageFile imgfile = await root.GetFileAsync("0.nn");
            IList<string> fileLines = await FileIO.ReadLinesAsync(imgfile);
            Network images = Network.Load(fileLines.ToArray());

            //Now run through neural networks
            {
                images.FeedForward(numout);
                if (Gaussian.Step(images.Output[0], 0.58) == 0)
                {
                    diagnosis.Text = "tumorous";
                    resultBox.Fill = new SolidColorBrush(Color.FromArgb(255, 186, 21, 21));
                }
                else
                {
                    diagnosis.Text = "normal";
                    resultBox.Fill = new SolidColorBrush(Color.FromArgb(255, 16, 145, 16));
                }
            }


        }
    }
}
