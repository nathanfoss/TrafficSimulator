using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficApplication
{
    public partial class TrafficForm : Form
    {
        /// <summary>
        /// Constructor for the TrafficForm class. Initializes the GUI
        /// </summary>
        public TrafficForm()
        {
            InitializeComponent();
        }

        private void TrafficForm_Load(object sender, EventArgs e)
        {

        }
        private void TrafficForm_Paint(object sender, PaintEventArgs e)
        {
            
        }


        /// <summary>
        /// Creates graphics for each of the Vehicles created by the TrafficBuilder object
        /// </summary>
        private void paintTraffic(Road road, List<Vehicle> vehicles)
        {
            
            using (Graphics g = CreateGraphics())
            {
                Vehicle tempVehicle;
                int x = 0;
                int y = 0;
                int index = 0;
                int vehicleSize = 0;
                Type type;
                Color color;
                Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Lime, Color.Orange, Color.Fuchsia };

                Refresh();
                for (int i = 0; i < vehicles.Count; i++)
                {
                    tempVehicle = vehicles[i];
                    type = tempVehicle.GetVehicleType();
                    index = (int)type;
                    color = colors[index];
                    x = tempVehicle.GetPosition();
                    y = tempVehicle.GetLane() * 100;
                    vehicleSize = tempVehicle.GetSize();
                    g.FillRectangle(new SolidBrush(color), x, y, vehicleSize, 20);
                }
                
            }
        }

        private async void SimulateTraffic(Road road, List<Vehicle> vehicles)
        {
            Int32 startTime = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            Int32 currentTime;
            TrafficHandler handler = new TrafficHandler(road, vehicles);
            paintTraffic(road, vehicles);
            while (true)
            {
                await Task.Delay(15);
                vehicles = handler.IterateTraffic();
                currentTime = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                if ((currentTime - startTime) % 6 == 5 )
                { //Somehow get the system to reset every 6 seconds
                    vehicles = handler.ResetTraffic();
                }
                paintTraffic(road, vehicles);
            }
        }

        /// <summary>
        /// Event Handler for the Start Application button
        /// uses PaintTraffic method to generate the GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            Road road = new Road(2, 65);
            TrafficBuilder builder = new TrafficBuilder(road, 10);
            List<Vehicle> vehicles = builder.GetVehicles();
            SimulateTraffic(road, vehicles);

        }
    }

}
