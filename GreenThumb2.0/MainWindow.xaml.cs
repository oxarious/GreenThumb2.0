using GreenThumb2._0.Data;
using GreenThumb2._0.Models;
using GreenThumb2._0.Repositories;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<ListViewItem> Items { get; set; } = new ObservableCollection<ListViewItem>();
        public ObservableCollection<ListViewItem> SearchedItems { get; set; } = new ObservableCollection<ListViewItem>();
        public MainWindow()
        {
            InitializeComponent();
            lvPlants.ItemsSource = Items;
            //lvSearchedPlants.ItemsSource = SearchedItems;


            //PlantModel plant = new();
            //List<PlantModel> plants = new();

            using (AppDbContext context = new())
            {
                InstructionRepository<InstructionModel> instructionsRepository = new(context);
                PlantRepository<PlantModel> plantRepository = new(context);
                var plants = plantRepository.GetAll("Instructions");

                foreach (var plant in plants)
                {
                    ListViewItem item = new();
                    item.Tag = plant;
                    item.Content = plant.Name;
                    Items.Add(item);

                }




            }
        }

        //private void btnDelete_Click(object sender, RoutedEventArgs e, PlantRepository<PlantModel> plantRepository)
        //{
        //    using (AppDbContext context = new())
        //    {
        //        if (lvPlants.SelectedItem is PlantModel plantModel)
        //        {
        //            plantRepository.Delete(plantModel.PlantId);
        //            plantRepository.Complete();

        //        }
        //    }

        //}

        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {

            using (AppDbContext context = new())
            {
                PlantRepository<PlantModel> plantRepository = new(context);
                if (lvPlants.SelectedItem is ListViewItem plantModel)
                {
                    var model = (PlantModel)plantModel.Tag;
                    plantRepository.Delete(model.PlantId);
                    //plantRepository.Delete(plantModel.Tag);

                    var item = Items.FirstOrDefault(m => ((PlantModel)m.Tag).PlantId == model.PlantId);
                    if (item != null)
                    {
                        Items.Remove(item);

                    }
                    plantRepository.Complete();

                }
            }
        }

        private void btnAddPlantWindow_Click(object sender, RoutedEventArgs e)
        {
            AddPlantWindow addPlantWindow = new AddPlantWindow();
            addPlantWindow.Show();
            Close();
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            //var selectedItem = lvPlants.SelectedItem as ListViewItem;  

            if (lvPlants.SelectedItem == null)
            {
                MessageBox.Show("Please select a Plant");
                return;
            }
            ListViewItem selectedItem = lvPlants.SelectedItem as ListViewItem;
            PlantModel plant = selectedItem.Tag as PlantModel;

            if (plant == null)
            {
                MessageBox.Show("Please select a Plant");
                return;

            }
            PlantDetailsWindow detailsWindow = new PlantDetailsWindow(plant);
            detailsWindow.Show();
            Close();

            //PlantDetailsWindow detailsWindow = new PlantDetailsWindow(plant);
            //detailsWindow.Show();
            //Close();




        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            SearchedItems.Clear();
            var searchedItems = Items.Where(m => ((PlantModel)m.Tag).Name.ToLower().Contains(tbxSearch.Text.ToLower())).ToList();
            foreach (var item in searchedItems)
            {
                //var plantModel = (PlantModel)item.Tag; 
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Tag = item.Content;
                listViewItem.Content = item.Content;
                SearchedItems.Add(listViewItem);
            }
            lvPlants.ItemsSource = SearchedItems;
        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            lvPlants.ItemsSource = Items;
        }
    }
}