using System;
using System.Windows.Forms;

namespace WinFormsApp
{
    static class Program
    {
        /// <summary>
        /// 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FirstForm());
        }
    }

    static class Login_e
    {
        public static string Value { get; set; }
    }

    static class db_puth
    {
        public static string Value { get; set; }
    }

    static class usersCount
    {
        public static long Value { get; set; }
    }

    static class url
    {
        public static string Value { get; set; }
    }
}
