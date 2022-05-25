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



namespace dealOrNoDeal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        List<int> arr = new List<int>()
        {
            1,
            5,
            10,
            20,
            50,
            100,
            200,
            500,
            1000,
            2000,
            5000,
            10000,
            20000,
            50000,
            100000,
            200000,
            300000,
            500000,
            750000,
            1000000
        };



        const int arrTotal = 2938886;

        bool[] CheckBoxOpened = new bool[20];

        int openedBoxes = 0;

        int moneyLost = 0;

        public MainWindow()
        {
            shuffleList(arr);
            InitializeComponent();
        }

        public static void shuffleList(List<int> list)

        {
            int s = list.Count;
            Random rng = new Random();



            while (s > 1)
            {
                s--;
                int k = rng.Next(s + 1);
                int value = list[k];
                list[k] = list[s];
                list[s] = value;
            }
        }
        public static void isOfferAvailable(int openedBoxes, int moneyLost)
        {
            if (openedBoxes % 3 == 0 && openedBoxes != 0)
            {
                int moneyLeftInBoxes = arrTotal - moneyLost;
                double avgPerBoxLeft = moneyLeftInBoxes / (20 - openedBoxes);
                double bankersOffer = Math.Round(avgPerBoxLeft * openedBoxes / 20);



                string OfferBoxText = "Offer: £" + bankersOffer;

                string caption = "An offer";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Information;

                MessageBoxResult result;



                result = MessageBox.Show(OfferBoxText, caption, button, icon, MessageBoxResult.Yes);
                if (result == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Congratulations! You just won £" + bankersOffer + "!", "Your prize:");
                }

            }

        }

        private void moneyBox_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string btnName = btn.Name;
            string btnNoString = btnName.Remove(0, 3);
            int btnNo = Int32.Parse(btnNoString);
            int btnIndex = btnNo - 1;


            if (openedBoxes == 0)
            {


            }


            if (CheckBoxOpened[btnIndex]) return;
            CheckBoxOpened[btnIndex] = true;
            openedBoxes++;
            btn.Content = "£" + arr[0];
            moneyLost += arr[0];







            if (arr[0] >= 10000)
            {
                btn.Background = Brushes.MediumPurple;
            }
            else
            {
                btn.Background = Brushes.CornflowerBlue;
            }

            isOfferAvailable(openedBoxes, moneyLost);



            arr.RemoveAt(0);
        }
    }
}
