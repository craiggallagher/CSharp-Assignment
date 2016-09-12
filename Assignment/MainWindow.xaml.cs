using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Ward> listWard = new List<Ward>();// lsit of wards
       
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            listWard = new List<Ward>();// making a new list
            Patient s = new Patient { DOB = DateTime.Parse("12/01/1956"), Name = "Sean", Blood = BloodType.A };// filling the list with data
            Patient f = new Patient { DOB = DateTime.Parse("04/06/1965"), Name = "Bob", Blood = BloodType.O };
          
            Ward w = new Ward { Limit = 6, Name = "St Martin's Ward" };// adding data to the new ward
            w.listPatient = new List<Patient>(); // new list for patients
            w.listPatient.Add(s);// adding patient to ward
            w.listPatient.Add(f);
            listWard.Add(w);// add ward to the list


            w = new Ward { Limit = 8, Name = "St Peeter' Ward" };// making a new ward
            
            s = new Patient { DOB = DateTime.Parse("02/10/1972"), Name = "Job", Blood = BloodType.A };// making a new patient
            f = new Patient { DOB = DateTime.Parse("03/01/1957"), Name = "Gerry", Blood = BloodType.B };// making a new patient
            w.listPatient = new List<Patient>();// making a new patient list
            w.listPatient.Add(s);// adding patient to ward
            w.listPatient.Add(f);// adding patient to ward
            listWard.Add(w);// add ward
            

            int counter=0;
            foreach (Ward room in listWard)// for each room in ward add to the ward listbox
            {

                lstWard.Items.Add(room);// add room
                counter++;
                
            }
            txbWard.Text += "(" + counter + ")"; // get the number of wards
       
           

            //int max = Math.Min(6, lstPatient.Items.Count);
            //for (int i = 0; i < max; i++)
            //{
            //    var rssItem = lstPatient.Items[i];
            //    //...
            //}


            
        }
        private void lstPatient_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Patient p = (Patient)lstPatient.SelectedItem;// when patient is selected

            string currDir = Directory.GetCurrentDirectory();
            DirectoryInfo dic = Directory.GetParent(currDir);
            dic = Directory.GetParent(dic.FullName);
            var uriSource = new Uri(dic.FullName + "\\Image\\" + p.Blood + ".png");// get the image for the blood of each patient


            imgBlood.Source = new BitmapImage(uriSource);

            lblOutName.Text += lstPatient.SelectedItem;// add the name of the person selected

        }





        private void lstWard_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ListBox lbx = (ListBox)sender;
            Ward w = (Ward)lbx.SelectedItem;// the selected ward

            lstPatient.Items.Clear();// clears the patient in the ward
            
                lstPatient.Items.Add(w);// add a patient to the list box
            

        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Ward w=(new Ward { Name = txbWardName.Text, Limit = (int)sldLimit.Value });// on the button click get name and limit
            lstWard.Items.Add(w);// add them to the ward list
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {

     Patient p=(new Patient { Name = txbPName.Text,  DOB = (dpDOB as DatePicker).DisplayDate});// get patient name, DOB
     lstPatient.Items.Add(p); // add to patient list
            
        }

        private void rdbType_Checked_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void TestForEmpty()
        {
            if (!string.IsNullOrWhiteSpace(txbWard.Text))// if the textbox is not empty
                btnWAdd.IsEnabled = true; //button add is enabled
            else btnWAdd.IsEnabled = false;// button is not enabled
        }
        private void TestForEmpty1()
        {
            if (!string.IsNullOrWhiteSpace(txbWard.Text))//if the textbox is not empty
                btnPAdd.IsEnabled = true;//button add is enabled
            else btnPAdd.IsEnabled = false;// button is not enabled
        }

        private void rdbType2_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void rdbType3_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void rdbType4_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void txbWardName_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            TestForEmpty();// call method
        }

        private void txbPName_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            TestForEmpty1();// call method
        }

    




        
       
    }// end class
}// end namespace
