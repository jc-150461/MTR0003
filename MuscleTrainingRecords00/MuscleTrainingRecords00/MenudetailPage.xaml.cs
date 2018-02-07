using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MuscleTrainingRecords00
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenudetaliPage : ContentPage
    {
        string t;

        //今日の日付
        static  DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        string date = now.ToString("yyyy/MM/dd");
        public MenudetaliPage(string m, string d, string i)//String m
        {
            InitializeComponent();

            Transition.Text = m.Trim();

            Description.Text = d;

            image.Source = ImageSource.FromStream(() => GetType().GetTypeInfo().Assembly.GetManifestResourceStream(i));

            t = m;

        }


        private void addItemButton_Clicked(object sender, EventArgs e)
        {
            List<RecordsModel> list = RecordsModel.SelectName(t);
            if ((list != null) && (list.Count != 0))
            {
                DisplayAlert("", "そのメニューはもう既に存在しています", "OK");
                //RecordsModel.UpdateRe(t, date);
                Navigation.PushAsync(new RecordListPage());
            }
            else
            {
                RecordsModel.InsertRe(1, t, 0.0, 0, 0, date);
                Navigation.PushAsync(new RecordListPage());
            }


        }
    }
}