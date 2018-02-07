using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleTrainingRecords00
{

    public class Record
    {
        public int M_no { get; set; } //筋トレNo 主キー

        public string M_name { get; set; } //筋トレ名前

        public double M_weight { get; set; } //重量

        public int M_leg { get; set; } //回数

        public int M_set { get; set; } //セット数

        public string M_date { get; set; } //日付

    }
}
