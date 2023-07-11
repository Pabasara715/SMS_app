using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindowVM: ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;

        [ObservableProperty]
        public Student selectedStudent = null;


        [RelayCommand]
        public void AddStudent()
        {
            var add = new EditWindowVM();
            var addWindow = new EditWindow(add) { DataContext = add };
            add.WindowTitle = "Add Student";
            addWindow.ShowDialog();
            Students.Insert(Students.Count, add.Selected_Student);


        }

        [RelayCommand]
        public void EditStudent()
        {
            if (SelectedStudent != null)
            {

                var edit = new EditWindowVM(SelectedStudent);
                var editWindow = new EditWindow(edit) { DataContext = edit };
                edit.WindowTitle = "Modify Student ";
                editWindow.ShowDialog();

                int update = Students.IndexOf(SelectedStudent);
                Students.Remove(SelectedStudent);
                Students.Insert(update, edit.Selected_Student);

            }
            else
            {
                MessageBox.Show("Select the Student First", "Error  ");
            }

        }

        [RelayCommand]
        public void DeleteStudent(Student student)
        {
            if (student != null)
            {
                Students.Remove(student);
                return;
            }
            MessageBox.Show("Select the Student First", "Error ");
        }


        [RelayCommand]
        public void Close()
        {
            Application.Current.Shutdown();
        }

       
        


        public MainWindowVM()
        {

            students = new ObservableCollection<Student>();
            students.Add(new Student("Satisha", "Mani", 55, 2.77, new BitmapImage(new Uri($"/Icons/1.png", UriKind.Relative))));
            students.Add(new Student("Amal", "Perera",40, 3.21, new BitmapImage(new Uri($"/Icons/2.png", UriKind.Relative))));
            students.Add(new Student("Gihan", "Jayawardhana", 21, 3.45, new BitmapImage(new Uri($"/Icons/3.png", UriKind.Relative))));
            students.Add(new Student("Pathum", "Nissanka", 33, 3.78, new BitmapImage(new Uri($"/Icons/4.png", UriKind.Relative))));
            students.Add(new Student("Levi", "Akrmen", 39, 4.0, new BitmapImage(new Uri($"/Icons/5.png", UriKind.Relative))));
            students.Add(new Student("Uzumaki", "Naruto", 46, 2.11, new BitmapImage(new Uri($"/Icons/6.png", UriKind.Relative))));
            students.Add(new Student("Light", "Yagami",44, 2.68, new BitmapImage(new Uri($"/Icons/7.png", UriKind.Relative))));

            
        }

    }
}
