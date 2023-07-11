using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double GPA { get; set; }
        public BitmapImage? Image { get; set; }
        public String ImagePath
        {
            get { return $"/Icons/{Image}"; }
        }

        public Student(string firstName, string lastName, int age, double gPA, BitmapImage img)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            Age = age;         
            GPA = gPA;
            Image = img;
            
        }

       

        public Student()
        {
            FirstName = "";
            LastName = "";
            Age = 0;
            GPA = 0;
            Image = null;

        }
    }
}
