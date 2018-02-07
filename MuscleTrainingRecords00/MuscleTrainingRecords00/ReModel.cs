using System;
using System.Collections.ObjectModel;
using SQLite;
namespace MuscleTrainingRecords00
{
    class ReModel
    {
        //public static string name;
        static DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        string date = now.ToString("yyyy/MM/dd");


        public ObservableCollection<Record> Records
        {
            get;
            private set;
        }
        
        public ReModel()
        {
            if (RecordsModel.SelectRecords() != null)
            {
                var query = RecordsModel.SelectRecords();
                Records = new ObservableCollection<Record>();

                foreach (var record in query)//拡張forループ
                {
                    Record r = new Record
                    {
                        M_no = record.M_no,
                        M_name = record.M_name,
                        M_weight = record.M_weight,
                        M_leg = record.M_leg,
                        M_set = record.M_set,
                        M_date = record.M_date
                    };
                    //一行ずつ追加
                    Records.Add(r);
                }
            }

            else
            {
                Records = new ObservableCollection<Record>
           {
               new Record
               {
                   M_no=0,
                   M_name="データなし",
                   M_weight=0.0,
                   M_leg=0,
                   M_set=0,
                   M_date= new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day).ToString("yyyy/MM/dd"),
               }
           };
            }
        }

    }
}