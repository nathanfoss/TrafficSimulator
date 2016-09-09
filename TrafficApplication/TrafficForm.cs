using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrafficApplication
{
    public partial class TrafficForm : Form
    {
        public TrafficForm()
        {
            InitializeComponent();
        }

        private void TrafficForm_Load(object sender, EventArgs e)
        {

        }
        private void TrafficForm_Paint(object sender, PaintEventArgs e)
        {
            paintTraffic();
            Invalidate();
        }

        private void paintTraffic()
        {
            
            using (Graphics g = CreateGraphics())
            {
                Vehicle tempVehicle;
                TrafficBuilder builder = new TrafficBuilder(2, 65, 50);
                List<Vehicle> vehicles = builder.GetVehicles();
                Vehicle[] traffic = vehicles.ToArray();
                int x = 0;
                int y = 0;
                int length = 0;

                for (int i = 0; i < traffic.Length; i++)
                {
                    tempVehicle = traffic[i];
                    x = Convert.ToInt32(tempVehicle.GetPosition() * 5280);
                    y = tempVehicle.GetLane() * 100;
                    length = Convert.ToInt32(tempVehicle.GetSize() * 5280);
                    g.FillRectangle(new SolidBrush(Color.Black), x, y, length, 50);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            paintTraffic();
            button1.Hide();
        }
    }

}
