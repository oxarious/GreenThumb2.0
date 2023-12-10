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
        //Constructor that requires a PlantModel as a paramenter. 
        public PlantDetailsWindow(PlantModel plant)
        {
            InitializeComponent();
            //Sets the lbName Label to the PlantName. 
            lbName.Content = plant.Name;


            //Loops over the Plants instructions and and creates a LV-item for each and then adds it to the List View. 
            foreach (InstructionModel model in plant.Instructions)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Tag = model;
                listViewItem.Content = model.Instructions;
                lvInstructions.Items.Add(listViewItem);
            }
        }
        //Goes back 
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
