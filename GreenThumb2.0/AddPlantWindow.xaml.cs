using GreenThumb2._0.Data;
using GreenThumb2._0.Models;
using GreenThumb2._0.Repositories;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb2._0
{
    /// <summary>
    /// Interaction logic for AddPlantWindow.xaml
    /// </summary>
    public partial class AddPlantWindow : Window
    {
        public AddPlantWindow()
        {
            InitializeComponent();

        }



        private void btnInstruction_Click(object sender, RoutedEventArgs e)
        {
            //Initializes a new instruction model. 
            InstructionModel instructionModel = new();
            //Sets the Instructinomodels instruction to users input
            instructionModel.Instructions = txtInstructions.Text;
            //Creates a new LV-item 
            ListViewItem lvItem = new();
            lvItem.Tag = instructionModel;
            lvItem.Content = instructionModel.Instructions;
            //Adds the LV-Item to the ListView. 
            lvInstructions.Items.Add(lvItem);
        }

        private void btnSavePlant_Click(object sender, RoutedEventArgs e)
        {
            using (AppDbContext context = new AppDbContext())
            {
                PlantRepository<PlantModel> plantRepository = new(context);





                //Creates new instance of PlantModel
                PlantModel plant = new();
                plant.Name = txtName.Text;

                //Uses my FindMethod to check if the name already exists in the Database. 
                if (plantRepository.Find(p => p.Name.ToLower() == plant.Name.ToLower()).FirstOrDefault() != null)
                {
                    MessageBox.Show("Plant name already exists");
                }
                else
                {
                    //Casts all our Items to in our List View to a ListViewItem.
                    plant.Instructions = lvInstructions.Items.Cast<ListViewItem>()
                        //Loops over and for every ListViewItem and cast the Tag to a InstructionModel.
                        .Select(item => item.Tag as InstructionModel)
                        .ToList();
                    plantRepository.Add(plant);
                    plantRepository.Complete();
                    MessageBox.Show("Saved Successfully");
                    lvInstructions.Items.Clear();
                }




            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindom = new();
            mainWindom.Show();
            Close();
        }
    }
}
