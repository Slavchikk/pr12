using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WebApiDemoekz.Pages
{
    /// <summary>
    /// Логика взаимодействия для TourPage.xaml
    /// </summary>
    public partial class TourPage : Page
    {
        List<Tour> tour;
    

        public TourPage()
        {
            InitializeComponent();
            SortOrFilt();
        }
        private void tbAct_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;  // получаем доступ к TextBlock из шаблона
            bool index = Convert.ToBoolean(tb.Uid);  // получаем числовой Uid элемента списка (в разметке предварительно нужно связать номер ячейки с номером кота в базе данных)

            // ищем в таблице, где хранятится информация о кормах для кота, которые соответсвуют определенному коту
           if(index == true)
            {
                tb.Text = "Актуален";
            }
            else
            {
                tb.Text = "Не актуален";
            }
           
            
        }
        private void SortOrFilt()
        {
           tour = BaseClass.tBD.Tour.ToList();
            




            if (TBTypeTour.SelectedIndex != 0 && TBTypeTour.SelectedIndex != -1)
            {
                List<int> type = BaseClass.tBD.TypeOfTour.Where(x => x.Type.Id == TBTypeTour.SelectedIndex).Select(x => x.id_tour).ToList();
              
                tour = tour.Where(x=> type.Contains(x.Id)).ToList();
            }



            if (!string.IsNullOrWhiteSpace(TbFind.Text))
            {
                tour = tour.Where(x => x.Name.ToLower().Contains(TbFind.Text.ToLower())).ToList();
            }

            if ((CBSort.SelectedIndex != -1))
            {
                
                        if (CBSort.SelectedIndex == 0)
                        {
                        tour = tour.OrderBy(x => x.Price).ToList();
                        }
                        else
                        {
                     tour = tour.OrderByDescending(x => x.Price).ToList();
                        }
                     
                
            }
            listTour.ItemsSource= tour;
         
        }
        private void Btn_back_menu(object sender, RoutedEventArgs e)
        {

            FrameClass.MainFrame.Navigate(new Pages.HotelsPage());
        }

        private void cbFiltr_Chang(object sender, SelectionChangedEventArgs e)
        {
            SortOrFilt();
        }

        private void cbSort_Chang(object sender, SelectionChangedEventArgs e)
        {
            SortOrFilt();
        }

        private void tx_chang(object sender, TextChangedEventArgs e)
        {

            SortOrFilt();
        }
    }
}
