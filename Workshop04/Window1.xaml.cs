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
using Workshop04.ViewModels;

namespace Workshop04
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            var vm = new HeroEditorViewModel();
            vm.Setup(new Models.Hero());
            this.DataContext = vm;
        }
        private void NewHeroButton(object sender, RoutedEventArgs e)
        {
        }
    }
}
