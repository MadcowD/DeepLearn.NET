using CancerDiagnostics.Common;
using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CancerDiagnostics
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class DFNA : Page
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


        public DFNA()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

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

        private void runDFNA(object sender, TextChangedEventArgs e)
        {
            TextBox[] ins = {
                m0, m1, m2, m3, m4, m5, m6, m7, m8, m9,
                se0, se1, se2, se3, se4, se5, se6, se7, se8, se9,
                l0, l1, l2, l3, l4, l5, l6, l7, l8, l9
            };


            double tryparse = 0;
            double[] inp = ins.Select((x => (double.TryParse(x.Text, out tryparse) ? tryparse : 0))).ToArray();
            Rectangle[] boxes = new Rectangle[]{
                    b1,b2,b3,b4,b5,b6,b7,b8,b9,b10
                };
            TextBlock[] textBlock = new TextBlock[]{
                    n1, n2,n3,n4,n5,n6,n7,n8,n9,n10
                };


            int benign = 0;
            int malignant = 0;

            for (int i = 0; i < App.Details.Length; i++)
            {
                App.Details[i].FeedForward(inp);
                if (App.Details[i].Output[0] < 0.3)
                {
                    boxes[i].Fill = new SolidColorBrush(Color.FromArgb(255, 16, 145, 16));
                    textBlock[i].Text = "benign";
                    benign++;
                }
                else
                {
                    malignant++;
                    textBlock[i].Text = "malignant";
                    boxes[i].Fill = new SolidColorBrush(Color.FromArgb(255, 186, 21, 21));
                }
            }

            //Check for conclusivity
            if (benign >= 9)
            {
                diagnosis.Text = "benign";
                resultBox.Fill = new SolidColorBrush(Color.FromArgb(255, 16, 145, 16));
            }
            else if (malignant >= 9)
            {
                diagnosis.Text = "malignant";
                resultBox.Fill = new SolidColorBrush(Color.FromArgb(255, 186, 21, 21));
            }
            else
            {
                diagnosis.Text = "inconclusive";
                resultBox.Fill = new SolidColorBrush(Color.FromArgb(255, 84, 84, 84));
            }
        }
    }
}