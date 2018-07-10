using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Блокнот
{
    static class Data
    {
        public static EventHandler Value_changed_for_search; // Обьявляю события для обработки изменения значений переменных поиска и замены;
        public static EventHandler Value_changed_for_replace ;
        private static string _value; 
        private static string _value_for_change;
        public static string Value 
        {
            get { return _value; }
            set
            {
                _value = value;
                Value_changed_for_search(null, EventArgs.Empty); //когда задается новое значение переменной, вызывается метод, который мы должны подписать на сооветствующее событие;
            }
        }
        public static string Value_for_change 
        {
            get { return _value_for_change; }
            set
            {
                _value_for_change = value;
                Value_changed_for_replace(null, EventArgs.Empty);
            }
        }


    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
