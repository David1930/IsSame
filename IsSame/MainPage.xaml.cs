using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IsSame
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //BindingContext = new CrossCheckViewModel(); // 유투브 동영상에서 이렇게 했는데 왜 하는지 모르겠음(Xamarin.Forms 101: Data Binding | The Xamarin Show)

            // EntryFirst에서 입력하고 엔터키를 치는 순간에 실행되는 메서드
            EntryFirst.Completed += (object sender, EventArgs e) =>
            {
                EntrySecond.Focus();
            };

            // EntrySecond에서 입력하고 엔터키를 치는 순간에 실행되는 메서드
            EntrySecond.Completed += async (object sender, EventArgs e) =>
            {
                MediaPlayer.Play();
                //EntryInitialize.Focus();
                //btnInitialize.Focus();
                await Task.Delay(3000);
                EntryFirst.Text = "";
                EntrySecond.Text = "";
                EntryFirst.Focus();
            };

            // EntryMediaPlay에서 엔터키를 치는 순간에 Entry의 Text를 초기화
            //EntryInitialize.Completed += async (object sender, EventArgs e) =>
            //{
            //    // Delay 를 좀 줘서 직전의 사운드가 마무리되게 할것
            //    await Task.Delay(1000);
            //    EntryFirst.Text = "";
            //    EntrySecond.Text = "";
            //    EntryFirst.Focus();
            //};
        }

        void btnInitialize_Clicked(System.Object sender, System.EventArgs e)
        {
            EntryFirst.Text = "";
            EntrySecond.Text = "";
            EntryFirst.Focus();
        }

        // 페이지가 열릴때 최초 커서 포인터 이동시키기
        protected override void OnAppearing()
        {
            base.OnAppearing();
            EntryFirst.Focus();
        }
    }
}
