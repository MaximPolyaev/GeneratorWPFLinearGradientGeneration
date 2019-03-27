using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GradientEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    
   

    public partial class MainWindow : Window
    {
        private LinearGradientBrush staticBrush = new LinearGradientBrush();

        double oldStartPointFirst;
        double oldStartPointSecond;
        double oldEndPointFirst;
        double oldEndPointSecond;

        byte colorOneR = 255;
        byte colorOneG = 0;
        byte colorOneB = 0;
        byte colorTwoR = 0;
        byte colorTwoG = 0;
        byte colorTwoB = 255;

        public MainWindow()
        {
            LinearGradientBrush myBrush = FindResource("mainBrush") as LinearGradientBrush;
            myBrush = myBrush.Clone();
            staticBrush = myBrush;
            

            InitializeComponent();
            staticBrush.GradientStops[0].Color = Color.FromRgb(colorOneR, colorOneG, colorOneB);
            staticBrush.GradientStops[1].Color = Color.FromRgb(colorTwoR, colorTwoG, colorTwoB);
            codeBox.Text = "<LinearGradientBrush x:Key=\"mainBrush\" StartPoint=\"0,0\" EndPoint=\"1,1\"\n" +
                                "\t<GradientStopCollection>\n" +
                                    "\t\t<GradientStop Color = \"Red\" Offset = \"0\" />\n" +
                                    "\t\t<GradientStop Color = \"Blue\" Offset = \"1\" />\n" +
                                "\t</GradientStopCollection>\n" +
                            "</LinearGradientBrush>";
        }

        private void Slider_StartPointFirst(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = Math.Round(e.NewValue, 2);
            ShowStartPointFirst.Text = Math.Round(e.NewValue, 2).ToString();
            staticBrush.StartPoint = new Point(oldStartPointFirst = Math.Round(e.NewValue, 2), oldStartPointSecond != 0 ? oldStartPointSecond : 0);
            MainGradient.Background = staticBrush;
        }

        private void Slider_StartPointSecond(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = Math.Round(e.NewValue, 2);
            ShowStartPointSecond.Text = Math.Round(e.NewValue, 2).ToString();
            staticBrush.StartPoint = new Point(oldStartPointFirst != 0 ? oldStartPointFirst : 0, oldStartPointSecond = Math.Round(e.NewValue, 2));
            MainGradient.Background = staticBrush;
        }
        
        private void Slider_EndPointStart(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = Math.Round(e.NewValue, 2);
            ShowEndPointFirst.Text = Math.Round(e.NewValue, 2).ToString();
            staticBrush.EndPoint = new Point(oldEndPointFirst = Math.Round(e.NewValue, 2), oldEndPointSecond != 0 ? oldEndPointSecond : 0);
            MainGradient.Background = staticBrush;
        }

        private void Slider_EndPointSecond(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = Math.Round(e.NewValue, 2);
            ShowEndPointSecond.Text = Math.Round(e.NewValue, 2).ToString();
            staticBrush.EndPoint = new Point(oldEndPointFirst != 0 ? oldEndPointFirst : 0, oldEndPointSecond = Math.Round(e.NewValue, 2));
            MainGradient.Background = staticBrush;
        }

        private void Slider_OffsetFirst(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = Math.Round(e.NewValue, 2);
            ShowOffsetFirst.Text = Math.Round(e.NewValue, 2).ToString();
            staticBrush.GradientStops[0].Offset = Math.Round(e.NewValue, 2);
            MainGradient.Background = staticBrush;
        }

        private void Slider_OffsetSecond(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = Math.Round(e.NewValue, 2);
            ShowOffsetSecond.Text = Math.Round(e.NewValue, 2).ToString();
            staticBrush.GradientStops[1].Offset = Math.Round(e.NewValue, 2);
            MainGradient.Background = staticBrush;
        }

        private void ShowColor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int val;
            if(!Int32.TryParse(e.Text, out val) || textBox.Text.Length > 2 || 
                int.Parse(textBox.Text.ToString() + e.Text.ToString()) > 255 || 
                (textBox.Text.ToString() == "" ? false : int.Parse(textBox.Text.ToString()) == 0))
            {
                e.Handled = true;
            }
        }
        private void ShowColor_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void MinusColorOneR_Click(object sender, RoutedEventArgs e)
        {
            if(ShowColorOneR.Text.ToString() == "") ShowColorOneR.Text = "0";
            else ShowColorOneR.Text = (int.Parse(ShowColorOneR.Text.ToString())) == 0 ? "0" : (int.Parse(ShowColorOneR.Text.ToString()) - 1).ToString();
        }

        private void PlusColorOneR_Click(object sender, RoutedEventArgs e)
        {
            if (ShowColorOneR.Text.ToString() == "") ShowColorOneR.Text = "0";
            else ShowColorOneR.Text = (int.Parse(ShowColorOneR.Text.ToString())) == 255 ? "255" : (int.Parse(ShowColorOneR.Text.ToString()) + 1).ToString();
        }

        private void MinusColorOneG_Click(object sender, RoutedEventArgs e)
        {
            if (ShowColorOneG.Text.ToString() == "") ShowColorOneG.Text = "0";
            else ShowColorOneG.Text = (int.Parse(ShowColorOneG.Text.ToString())) == 0 ? "0" : (int.Parse(ShowColorOneG.Text.ToString()) - 1).ToString();
        }

        private void PlusColorOneG_Click(object sender, RoutedEventArgs e)
        {
            if (ShowColorOneG.Text.ToString() == "") ShowColorOneG.Text = "0";
            else ShowColorOneG.Text = (int.Parse(ShowColorOneG.Text.ToString())) == 255 ? "255" : (int.Parse(ShowColorOneG.Text.ToString()) + 1).ToString();
        }

        private void MinusColorOneB_Click(object sender, RoutedEventArgs e)
        {
            if (ShowColorOneB.Text.ToString() == "") ShowColorOneB.Text = "0";
            else ShowColorOneB.Text = (int.Parse(ShowColorOneB.Text.ToString())) == 0 ? "0" : (int.Parse(ShowColorOneB.Text.ToString()) - 1).ToString();
        }

        private void PlusColorOneB_Click(object sender, RoutedEventArgs e)
        {
            if (ShowColorOneB.Text.ToString() == "") ShowColorOneB.Text = "0";
            else ShowColorOneB.Text = (int.Parse(ShowColorOneB.Text.ToString())) == 255 ? "255" : (int.Parse(ShowColorOneB.Text.ToString()) + 1).ToString();
        }

        private void MinusColorTwoR_Click(object sender, RoutedEventArgs e)
        {
            if (ShowColorTwoR.Text.ToString() == "") ShowColorTwoR.Text = "0";
            else ShowColorTwoR.Text = (int.Parse(ShowColorTwoR.Text.ToString())) == 0 ? "0" : (int.Parse(ShowColorTwoR.Text.ToString()) - 1).ToString();
        }

        private void PlusColorTwoR_Click(object sender, RoutedEventArgs e)
        {
            if (ShowColorTwoR.Text.ToString() == "") ShowColorTwoR.Text = "0";
            else ShowColorTwoR.Text = (int.Parse(ShowColorTwoR.Text.ToString())) == 255 ? "255" : (int.Parse(ShowColorTwoR.Text.ToString()) + 1).ToString();
        }

        private void MinusColorTwoG_Click(object sender, RoutedEventArgs e)
        {
            if (ShowColorTwoG.Text.ToString() == "") ShowColorTwoG.Text = "0";
            else ShowColorTwoG.Text = (int.Parse(ShowColorTwoG.Text.ToString())) == 0 ? "0" : (int.Parse(ShowColorTwoG.Text.ToString()) - 1).ToString();
        }

        private void PlusColorTwoG_Click(object sender, RoutedEventArgs e)
        {
            if (ShowColorTwoG.Text.ToString() == "") ShowColorTwoG.Text = "0";
            else ShowColorTwoG.Text = (int.Parse(ShowColorTwoG.Text.ToString())) == 255 ? "255" : (int.Parse(ShowColorTwoG.Text.ToString()) + 1).ToString();
        }

        private void MinusColorTwoB_Click(object sender, RoutedEventArgs e)
        {
            if (ShowColorTwoB.Text.ToString() == "") ShowColorTwoB.Text = "0";
            else ShowColorTwoB.Text = (int.Parse(ShowColorTwoB.Text.ToString())) == 0 ? "0" : (int.Parse(ShowColorTwoB.Text.ToString()) - 1).ToString();
        }

        private void PlusColorTwoB_Click(object sender, RoutedEventArgs e)
        {
            if (ShowColorTwoB.Text.ToString() == "") ShowColorTwoB.Text = "0";
            else ShowColorTwoB.Text = (int.Parse(ShowColorTwoB.Text.ToString())) == 255 ? "255" : (int.Parse(ShowColorTwoB.Text.ToString()) + 1).ToString();
        }

        private void ShowColor_Changed(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            switch(textBox.Name.ToString())
            {
                case "ShowColorOneR":
                    colorOneR = textBox.Text.ToString() == "" ? (byte)0 : byte.Parse(textBox.Text.ToString());
                    break;
                case "ShowColorOneG":
                    colorOneG = textBox.Text.ToString() == "" ? (byte)0 : byte.Parse(textBox.Text.ToString());
                    break;
                case "ShowColorOneB":
                    colorOneB = textBox.Text.ToString() == "" ? (byte)0 : byte.Parse(textBox.Text.ToString());
                    break;
                case "ShowColorTwoR":
                    colorTwoR = textBox.Text.ToString() == "" ? (byte)0 : byte.Parse(textBox.Text.ToString());
                    break;
                case "ShowColorTwoG":
                    colorTwoG = textBox.Text.ToString() == "" ? (byte)0 : byte.Parse(textBox.Text.ToString());
                    break;
                case "ShowColorTwoB":
                    colorTwoB = textBox.Text.ToString() == "" ? (byte)0 : byte.Parse(textBox.Text.ToString());
                    break;
                default:
                    MessageBox.Show("Error!");
                    break;
            }
            
            if(textBox.Name.ToString() == "ShowColorOneR" || textBox.Name.ToString() == "ShowColorOneG" || textBox.Name.ToString() == "ShowColorOneB")
            {
                staticBrush.GradientStops[0].Color = Color.FromRgb(colorOneR, colorOneG, colorOneB);
            }
            else if(textBox.Name.ToString() == "ShowColorTwoR" || textBox.Name.ToString() == "ShowColorTwoG" || textBox.Name.ToString() == "ShowColorTwoB")
            {
                staticBrush.GradientStops[1].Color = Color.FromRgb(colorTwoR, colorTwoG, colorTwoB);
                
            } 
            else
            {
                MessageBox.Show("Set color error in " + textBox.Name.ToString());
            }


            MainGradient.Background = staticBrush;
        }
    }
}
