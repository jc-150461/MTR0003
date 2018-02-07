using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MuscleTrainingRecords00;
using SQLite;

namespace MuscleTrainingRecords00
{
    [Table("Re")]//テーブル名を指定
    class RecordModelv2
    {
        //[PrimaryKey, AutoIncrement, Column("_id")]
        [PrimaryKey, AutoIncrement]
        public int M_no { get; set; } //筋トレNo 主キー

        public string M_name { get; set; } //筋トレ名前

        public double M_weight { get; set; } //重量

        public int M_leg { get; set; } //回数

        public int M_set { get; set; } //セット数

        public string M_date { get; set; } //日付





        /********************インサートメソッド RecordPage　追加**********************/
        public static void InsertRe(int m_no, string m_name, double m_weight, int m_leg, int m_set, string m_date)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにFoodテーブルを作成する
                    db.CreateTable<RecordModelv2>();

                    db.Insert(new RecordModelv2() { M_no = m_no, M_name = m_name, M_weight = m_weight, M_leg = m_leg, M_set = m_set, M_date = m_date });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }


        /*******************セレクトメソッド RecordPage　 追加*************************************/
        public static List<RecordModelv2> SelectRe(string m_name) //前回　int m_no 前々回  DateTime m_date
        {

            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                //前回　int no = m_no;
                string name = m_name;
                //DateTime date = m_date;

                try
                {

                    //データベースに指定したSQLを発行
                    // 前回　return db.Query<RecordModelv2>("SELECT * FROM [Re] WHERE [M_no] =" + no);
                    return db.Query<RecordModelv2>("SELECT * FROM [Re] WHERE [M_name] = '" +  name + "'" );
                    // ORDER BY[M_date]
                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        /*******************セレクトメソッド**************************************/
        public static List<RecordModelv2> SelectRecord()
        {

            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {

                    //データベースに指定したSQLを発行
                    return db.Query<RecordModelv2>("SELECT * FROM [Re]");
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
                    db.CreateTable<RecordModelv2>();

                    db.Delete<RecordModelv2>(m_no);//デリートで渡す値は主キーじゃないといけない説
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
                    db.CreateTable<RecordModelv2>();

                    db.DeleteAll<RecordModelv2>();//デリートで渡す値は主キーじゃないといけない説
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /********************アップデートメソッド RecordPage**************************************/
        public static void UpdateRecord(int m_no, double m_weight, int m_leg, int m_set, string m_date)
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {


                try
                {
                    //データベースに指定したSQLを発行
                    db.CreateTable<RecordModelv2>();

                    db.Update(new RecordModelv2() { M_no = m_no, M_weight = m_weight, M_leg = m_leg, M_set = m_set, M_date = m_date });

                    db.Commit();
                }
                catch (Exception e)
                {

                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }


    }
}