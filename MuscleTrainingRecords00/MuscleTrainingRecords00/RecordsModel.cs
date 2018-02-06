using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MuscleTrainingRecords00
{
    [Table("Records")]//テーブル名を指定
    class RecordsModel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int M_no { get; set; } //筋トレNo 主キー

        public string M_name { get; set; } //筋トレ名前

        public int M_weight { get; set; } //重量

        public int M_leg { get; set; } //回数

        public int M_set { get; set; } //セット数

        public string M_date { get; set; } //日付




        //[ForeignKey(typeof(SettingModel))]
        // public int Set_no { get; set; } //Setting表の外部キー

        /********************インサートメソッド**********************/
        public static void InsertRecords(int m_weight, int m_leg, int m_set, string m_date)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにテーブルを作成する
                    db.CreateTable<RecordsModel>();

                    db.Insert(new RecordsModel() { M_weight = m_weight, M_leg = m_leg, M_set = m_set, M_date = m_date });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /********************インサートメソッド RecordListPage　追加**********************/
        public static void InsertRe(int m_no, string m_name, int m_weight, int m_leg, int m_set, string m_date)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにFoodテーブルを作成する
                    db.CreateTable<RecordsModel>();

                    db.Insert(new RecordsModel() { M_no = m_no, M_name = m_name, M_weight = m_weight, M_leg = m_leg, M_set = m_set, M_date = m_date });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /*******************セレクトメソッド**************************************/
        public static List<RecordsModel> SelectRecords()
        {

            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {

                    //データベースに指定したSQLを発行
                    return db.Query<RecordsModel>("SELECT * FROM [Records]");
                    // ORDER BY[M_date]
                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        /*******************セレクトメソッド RecordListPage　 追加*************************************/
        public static List<RecordsModel> SelectName(string m_name)
        {
            string name = m_name;

            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {

                    //データベースに指定したSQLを発行
                    return db.Query<RecordsModel>("SELECT [M_name] FROM [Records] WHERE [M_name] = '" + name + "'");
                    // ORDER BY[M_date]
                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        /********************デリートメソッド*************************************/
        public static void DeleteRecords(int m_no)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにテーブルを作成する
                    db.CreateTable<RecordsModel>();

                    db.Delete<RecordsModel>(m_no);//デリートで渡す値は主キーじゃないといけない説
                    db.Commit();

                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /********************オールデリートメソッド*************************************/
        public static void DeleteAllRecordsd()
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにテーブルを作成する
                    db.CreateTable<RecordsModel>();

                    db.DeleteAll<RecordsModel>();//デリートで渡す値は主キーじゃないといけない説
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /********************アップデートメソッド RecordPageに使用**************************************/
        public static void UpdateRecord(int m_no, int m_weight, int m_leg, int m_set, string m_date)
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                /*int no=  m_no;
                int weight = m_weight;
                int leg = m_leg;
                int set = m_set;
                TimeSpan span = m_date;
                int date = span.Days;*/

                try
                {
                    //データベースに指定したSQLを発行
                    //return db.Query<RecordsModel>("UPDATE [Records] SET [M_weight] = "+ weight +", [M_leg] = "+ leg +",[M_set] = "+ set + "WHERE [M_no] = "+ m_no);
                    db.CreateTable<RecordsModel>();

                    db.Update(new RecordsModel() { M_no = m_no, M_weight = m_weight, M_leg = m_leg, M_set = m_set, M_date = m_date });

                    db.Commit();
                }
                catch (Exception e)
                {

                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }


        /********************アップデートメソッド RecordPageに使用**************************************/
        public static List<RecordsModel> UpdateRe(string m_name, string m_date)
        {
            string name = m_name;
            string date = m_date;

            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    return db.Query<RecordsModel>("UPDATE [Records] SET [M_date] = '" + date + "' WHERE [M_name] = '" + name + "'");

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

    }

}
