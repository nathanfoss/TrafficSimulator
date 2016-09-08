using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Vehicle tempVehicle;
            TrafficBuilder builder = new TrafficBuilder(2, 65, 50);
            List<Vehicle> vehicles = builder.GetVehicles();
            List<Point> points = new List<Point>();
            Vehicle[] traffic = vehicles.ToArray();

            for (int i = 0; i < traffic.Length; i++)
            {
                tempVehicle = traffic[i];
                int x = tempVehicle.GetLane();
                int y = Convert.ToInt32(tempVehicle.GetPosition() * 5280);
                Point point = new Point(x, y);
                points.Add(point);
            }

            Point[] pointsArray = points.ToArray();

            for (int i = 0; i < pointsArray.Length; i++)
            {
                CreateGraphics().FillRectangle(new SolidBrush(Color.Black), pointsArray[i].X, pointsArray[i].Y, 1, 1);
            }
        }
    }

}
