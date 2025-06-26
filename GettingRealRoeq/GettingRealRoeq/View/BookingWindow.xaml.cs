using GettingRealRoeq.Model;
using GettingRealRoeq.ViewModel;
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
using System.Windows.Shapes;

namespace GettingRealRoeq.View
{
    /// <summary>
    /// Interaction logic for BookingWindow.xaml
    /// </summary>
    public partial class BookingWindow : Window 
    {
        BookingViewModel bvm = new BookingViewModel();

        public BookingWindow()
        {

            InitializeComponent();
            DataContext = bvm; 

        }

        
    }
}