using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfPracticeApp.BusinessLogic
{
    public class Car : Notifier
    {
        // public double Speed { get; set; } 아래와 같음
        private double speed; // 부가적인 처리가 필요할 때
        public double Speed { 
            get { return speed; }
            set 
            {
                if (value > 350)
                {
                    speed = 350;
                }
                else
                {
                    speed = value;
                }
                OnPropertyChanged("Speed"); // 속성값 변경된 것을 알려줌(프로그램에)
            }
        }
        private Color mainColor;
        public Color MainColor { 
            get { return mainColor; } 
            set 
            {
                mainColor = value;
                OnPropertyChanged("mainColor");
            }
        }
        public Human Driver { get; set; }
    }

    public class Human
    {
        public string Name { get; set; }
        public bool HasDriveLicense { get; set; }
    }
}
