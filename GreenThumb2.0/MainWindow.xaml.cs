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
        //Initializes two observables collections. One ment to hold all Items and for holding queried items.
        //They are used as sources for the ListView
        public ObservableCollection<ListViewItem> AllPlants { get; set; } = new ObservableCollection<ListViewItem>();
        public ObservableCollection<ListViewItem> QueriedPlants { get; set; } = new ObservableCollection<ListViewItem>();
        public MainWindow()
        {
            InitializeComponent();

            //Sets source of Items in the ListView.  
            lvPlants.ItemsSource = AllPlants;





            using (AppDbContext context = new())
            {

                //Using my get all Method to get all plants including instructions. 
                PlantRepository<PlantModel> plantRepository = new(context);
                var plants = plantRepository.GetAll("Instructions");

                //Loops over them and adds them to the Itemsource(Observable Collection) of the ListView. 
                foreach (var plant in plants)
                {
                    ListViewItem item = new();
                    item.Tag = plant;
                    item.Content = plant.Name;
                    AllPlants.Add(item);

                }




            }
        }



        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {

            using (AppDbContext context = new())
            {

                PlantRepository<PlantModel> plantRepository = new(context);
                //Checking if selected item is of type ListViewItem and creates a varible named "plantModel" that contains selected item. 
                if (lvPlants.SelectedItem is ListViewItem plantModel)
                {
                    //Casts it to a PlantModel
                    var model = (PlantModel)plantModel.Tag;
                    //Prepares deletion of the item from the database
                    plantRepository.Delete(model.PlantId);

                    //Removes the item from the observable collection. 
                    var item = AllPlants.FirstOrDefault(m => ((PlantModel)m.Tag).PlantId == model.PlantId);
                    if (item != null)
                    {
                        AllPlants.Remove(item);
                    }
                    //Saves changes to the database
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

            //Nullcheck
            if (lvPlants.SelectedItem == null)
            {
                MessageBox.Show("Please select a Plant");
                return;
            }
            //Creates ListViewItem from lvPlants.SelectedItem.

            ListViewItem selectedItem = lvPlants.SelectedItem as ListViewItem;

            //Casts it to a PlantModel
            PlantModel plant = selectedItem.Tag as PlantModel;

            if (plant == null)
            {
                MessageBox.Show("Please select a Plant");
                return;

            }
            //Initializes a new window with the plant as argument. 
            PlantDetailsWindow detailsWindow = new PlantDetailsWindow(plant);
            detailsWindow.Show();
            Close();

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //Clears my Observable collection "QueriedPlants" 
            QueriedPlants.Clear();

            //Casts the Tag of the LVItem to a PlantModel. Get the name from Plantmodel and checks if it contains what the user searches for. Also makes it case insensitive
            var queriedPlants = AllPlants.Where(m => ((PlantModel)m.Tag)
                .Name.ToLower().Contains(tbxSearch.Text.ToLower())).ToList();

            //Adds queried items to the "Queried Plants" 
            foreach (var item in queriedPlants)
            {
                QueriedPlants.Add(item);
            }
            //Changes the itemsource of the ListView to our search result collection.  
            lvPlants.ItemsSource = QueriedPlants;
        }

        //Sets the itemsource to our AllPlants collection.
        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            lvPlants.ItemsSource = AllPlants;
        }
    }
}