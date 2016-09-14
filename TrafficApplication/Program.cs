using System.Windows.Forms;

namespace TrafficApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new TrafficForm());
            }
            catch (System.Exception e)
            {

            }
        }
    }
}
