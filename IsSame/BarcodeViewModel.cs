using System;
using System.ComponentModel;

namespace IsSame
{
    public class BarcodeViewModel:INotifyPropertyChanged
    {
        private string firstScan, secondScan, resultSound;

        public BarcodeViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstScan
        {
            get
            {
                return firstScan;
            }
            set
            {
                if (firstScan == value)
                {
                    return;
                }

                firstScan = value;
                OnPropertyChanged("FirstScan");
                //CalcSound();
            }
        }

        public string SecondScan
        {
            get
            {
                return secondScan;
            }
            set
            {
                if (secondScan == value)
                {
                    return;
                }

                secondScan = value;
                OnPropertyChanged("SecondScan");
                CalcSound();
            }
        }

        public string ResultSound
        {
            get
            {
                return resultSound;
            }
            set
            {
                if (resultSound == value)
                {
                    return;
                }
                resultSound = value;
                OnPropertyChanged("ResultSound");
            }
        }

        public void CalcSound()
        {
            if (firstScan.Length == 11 & secondScan.Length == 11) // RO 넘버 11자리 감안
            {
                if (firstScan.Substring(0, 9) == secondScan.Substring(0, 9))
                {
                    ResultSound = "YEAH.mp3";
                }
                else
                {
                    ResultSound = "NO.mp3";
                }
            }

            else if (firstScan == secondScan)
            {
                //ResultSound = "ms-appx:///YEAH.mp3";
                // 스캔이 모두 된후에 Entry에 남아 있는 기존 값을 초기화 시켰을때 둘다 Null 이 되어 같은 코드로 오인하여 Yeah 라고 못하게 한다.
                // 이렇게 하면 간단한데 Xaml 파일에서 멀티 트리거등의 별별 궁리를 다 해보다가 주님 은혜로 이렇게 해결하였다.
                if (firstScan == "" & secondScan == "")
                {
                    ResultSound = "";
                }
                else
                    ResultSound = "YEAH.mp3";
            }
            //else if (first.Substring(0, 9) == second.Substring(0, 9)) //이 루틴 때문에 테스트하면서 값을 넣으면 자꾸 다운되는 현상 때문에 엄청 고생했다.
            //{                                                         // 자리수 9개를 넣지 않고 자꾸 실행하니 없는 데이터를 처리하려고 하면서 죽어버림.
            //    ResultSound = "ms-appx:///YEAH.mp3";
            //}
            else
            {
                //ResultSound = "ms-appx:///YEAH.mp3";
                ResultSound = "NO.mp3";
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
