using GreenThumb2._0.Models;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb2._0
{
    /// <summary>
    /// Interaction logic for PlantDetailsWindow.xaml
    /// </summary>
    public partial class PlantDetailsWindow : Window
    {
        public PlantDetailsWindow(PlantModel plant)
        {
            InitializeComponent();
            lbName.Content = plant.Name;

            foreach (InstructionModel model in plant.Instructions)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Tag = model;
                listViewItem.Content = model.Instructions;
                lvInstructions.Items.Add(listViewItem);


            }


        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
