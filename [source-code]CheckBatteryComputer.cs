using System;
using System.Windows.Forms;
using Windows.Devices.Power;

namespace BatteryStatus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Battery.AggregateBattery.ReportUpdated += UpdateBatteryLevel;
        }

        private void UpdateBatteryLevel(Battery sender, object args)
        {
            var report = sender.GetReport();
            var percentage = report.RemainingCapacityInMilliwattHours / (double)report.FullChargeCapacityInMilliwattHours * 100.0;
            lblBatteryLevel.Invoke(new Action(() => { lblBatteryLevel.Text = percentage.ToString("0.00") + "%"; }));
        }
    }
}
