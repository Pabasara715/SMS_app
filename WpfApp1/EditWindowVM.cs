using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Xml.Serialization;

namespace WpfApp1
{
    public partial class EditWindowVM:ObservableObject
    {


        [ObservableProperty]
        string firstName;
        [ObservableProperty]
        string lastName;      
        [ObservableProperty]
        double gpa;
        [ObservableProperty]
        BitmapImage img;
        [ObservableProperty]
        int age;

        [ObservableProperty]
        string windowTitle;


        public Student Selected_Student { get; private set; }
        public Action CloseAction { get; internal set; }


        [RelayCommand]
        public void Save()
        {
            if (gpa < 0 || gpa > 4)
            {

                MessageBox.Show("Invalid GPA", "Error !");

            }
            else
            {
                if (WindowTitle == "Modify Student ")
                {
                    if (FirstName != "" && FirstName != null && LastName !="" && LastName !=null)
                    {
                        Selected_Student.FirstName = FirstName;
                        Selected_Student.LastName = LastName;
                        Selected_Student.Age = age;
                        Selected_Student.GPA = Gpa;
                        Selected_Student.Image = img;
                        

                        CloseAction();
                    }
                    else
                    {

                        MessageBox.Show("First Name and Last name shouldn't be empty", "Error ");
                    }
                }
                else
                {
                    if (FirstName != "" && FirstName != null)
                    {


                        Selected_Student.FirstName = FirstName;
                        Selected_Student.LastName = LastName;
                        Selected_Student.Age = age;                       
                        Selected_Student.GPA = Gpa;
                        Selected_Student.Image = img;

                        CloseAction();
                    }
                    else
                    {
                        MessageBox.Show("First Name and Last name shouldn't be empty", "Error ");
                    }
                }

            }
        }


        [RelayCommand]
        public void closethis()
        {
            CloseAction();
        }

        [RelayCommand]
        public void UploadImage()
        {
            OpenFileDialog img = new OpenFileDialog();
            img.Filter = "Image files | *.bmp; *.png; *.jpg";
            img.FilterIndex = 1;
            if (img.ShowDialog() == true)
            {
                Img = new BitmapImage(new Uri(img.FileName));
                return;
            }


        }


        public EditWindowVM(Student stu)
        {
            Selected_Student = stu;

            firstName = stu.FirstName;
            lastName = stu.LastName;            
            gpa = stu.GPA;
            age = stu.Age;
            img = stu.Image;
            


        }

        public EditWindowVM()
        {
            Selected_Student = new Student();

        }
    }
}
