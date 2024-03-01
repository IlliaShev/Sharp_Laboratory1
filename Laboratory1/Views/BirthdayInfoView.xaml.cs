using KMA.CSharp2024.Laboratory1.ModelViews;
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

namespace KMA.CSharp2024.Laboratory1.Views
{
    /// <summary>
    /// Interaction logic for BirthdayInfoView.xaml
    /// </summary>
    public partial class BirthdayInfoView : UserControl
    {
        private BirthdayModelView _birthdateModelView;
        public BirthdayInfoView()
        {
            InitializeComponent();
            DataContext = _birthdateModelView = new BirthdayModelView();
        }
    }
}
