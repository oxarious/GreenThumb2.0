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
            InstructionModel instructionModel = new();
            instructionModel.Instructions = txtInstructions.Text;
            ListViewItem lvItem = new();
            lvItem.Tag = instructionModel;
            lvItem.Content = instructionModel.Instructions;
            lvInstructions.Items.Add(lvItem);
        }

        private void btnSavePlant_Click(object sender, RoutedEventArgs e)
        {
            using (AppDbContext context = new AppDbContext())
            {
                PlantRepository<PlantModel> plantRepository = new(context);
                InstructionRepository<InstructionModel> instructionRepository = new(context);



                //InstructionModel instruction = new();
                PlantModel plant = new();
                plant.Name = txtName.Text;


                if (plantRepository.Find(p => p.Name.ToLower() == txtName.Text.ToLower()).FirstOrDefault() != null)
                {
                    MessageBox.Show("Plant name already exists");
                }
                else
                {
                    plant.Instructions = lvInstructions.Items
                    .Cast<ListViewItem>()
                    .Select(item => item.Tag as InstructionModel).ToList();
                    //.Where(model => model);
                    plantRepository.Add(plant);

                    plantRepository.Complete();
                    MessageBox.Show("Saved Successfully");
                    lvInstructions.Items.Clear();
                }

                //instruction.Instructions = txtInstructions.Text;

                //foreach (var instruction in plant.Instructions)
                //{
                //    instruction.PlantId = plant.PlantId;
                //    instructionRepository.Add(instruction); 
                //}


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
