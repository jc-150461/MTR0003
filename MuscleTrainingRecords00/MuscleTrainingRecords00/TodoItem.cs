using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MuscleTrainingRecords00
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime Created { get; set; }
        //public string Name { get; set; }
        //public string Notes { get; set; }
        public bool Done { get; set; }
        public double Bweight { get; set; }
        public double Bfat { get; set; }

        public static implicit operator Task<object>(TodoItem v)
        {
            throw new NotImplementedException();
        }
    }
}