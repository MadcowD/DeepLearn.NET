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
    public sealed partial class DiagnosisPage : Page
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


        public DiagnosisPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;

            ////Render network
            //Network n = App.Networks[8];
            //int VMARGIN = 5;
            //int HMARGIN = 5;

            //int LAYERHEIGHT = ((int)canvas.Height - VMARGIN*2 )/ n.Neurons.Count() ;
            //int LAYERWIDTH = ((int)canvas.Width - HMARGIN * 2);
            //int NODERADIUS = LAYERWIDTH /(16*2);



            //for(int i = 0; i < n.Neurons.Length; i++)
            //    for (int x = 0; x < n.Neurons[i].Length; x++)
            //    {
            //        int layerLength = n.Neurons[i].Length;
            //        //AddCircle()

            //    }
            //}
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

        private void AddNewLine(int x, int y, int xf, int yf, Color c, int width = 4)
        {
            //Render network
            Line a = new Line();
            a.X1 = x;
            a.Y1 = y;
            a.X2 = xf;
            a.Y2 = 100;
            a.StrokeThickness = width;
            a.Stroke = new SolidColorBrush(c);
            a.Fill = new SolidColorBrush(c);
        }

        private void AddNewNode(int x, int y, float radius, Color c)
        {
            Ellipse ab = new Ellipse();
            ab.Stroke = new SolidColorBrush(c);
            ab.Fill = new SolidColorBrush(c);
            ab.Height = radius * 2;
            ab.Width = radius*2;
            Canvas.SetLeft(ab, x);
            Canvas.SetTop(ab, y);
        }

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (c9 != null)
            {
                double[] inp = {
                (c1.Value == 0 ? 10 : c1.Value)/10,
                11 -(c2.Value == 0 ? 10 : c2.Value)/10,
                11 -(c3.Value == 0 ? 10 : c3.Value)/10,
                11 - (c4.Value == 0 ? 10 : c4.Value)/10,
                (c5.Value == 0 ? 10 : c5.Value)/10, 
                 (c6.Value == 0 ? 10 : c6.Value)/10,
                (c7.Value == 0 ? 10 : c7.Value)/10, 
                11 - (c8.Value == 0 ? 10 : c8.Value)/10,
                11 - (c9.Value == 0 ? 10 : c9.Value)/10 
            };

                Rectangle[] boxes = new Rectangle[]{
                    b1,b2,b3,b4,b5,b6,b7,b8,b9,b10
                };
                TextBlock[] textBlock = new TextBlock[]{
                    n1, n2,n3,n4,n5,n6,n7,n8,n9,n10
                };


                int benign = 0;
                int malignant = 0;

                for (int i = 0; i < App.Networks.Length; i++)
                {
                    App.Networks[i].FeedForward(inp);
                    if (App.Networks[i].Output[0] < 0.05)
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

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }
    }
}