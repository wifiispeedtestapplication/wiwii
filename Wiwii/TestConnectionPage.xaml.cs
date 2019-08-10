using System;
using System.Collections.Generic;
using System.IO;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;

namespace Wiwii
{
    public partial class TestConnectionPage : ContentPage
    {
        public TestConnectionPage()
        {
            InitializeComponent();


            var entries = new[]
{
    new Microcharts.Entry(200)
    {
        Label = "Upload",
        ValueLabel = "200",
    Color = SKColor.Parse("#266489")
    },
    new Microcharts.Entry(400)
    {
    Label = "Download",
    ValueLabel = "400",
    Color = SKColor.Parse("#68B9C0")
    },
    new Microcharts.Entry(-100)
    {
    Label = "Time",
    ValueLabel = "-100",
    Color = SKColor.Parse("#90D585")
    }
};

            var chart = new RadialGaugeChart { Entries = entries, BackgroundColor = SKColor.Parse("#0D0E21")};

            
            this.chartView.Chart =  chart;
            




        }

        public double convertbpstombps(long speed) {

            return(speed / 1024f) / 1024f;

        }

        public void SpeedTest(object sender, EventArgs args) {


            string tempfile = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "tempfile.tmp";
            System.Net.WebClient webClient = new System.Net.WebClient();
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            webClient.DownloadFile("http://dl.google.com/googletalk/googletalk-setup.exe", tempfile);
            sw.Stop();
            FileInfo fileInfo = new FileInfo(tempfile);
            long speed = fileInfo.Length / (sw.Elapsed.Milliseconds);
            value.Text = (String.Format("{0:0.00}", convertbpstombps(speed) * 1000).ToString()) + " Mbps";
            value2.Text = (String.Format("{0:0.00}", convertbpstombps(speed) * 1000 - 2.18).ToString()) + " Mbps";


            
            var entries = new[]
{
    new Microcharts.Entry((int)(float)convertbpstombps(speed) * 1000)
    {
        Label = "Upload",
        ValueLabel = ((float)convertbpstombps(speed) * 1000).ToString(),
    Color = SKColor.Parse("#266489")
    },
    new Microcharts.Entry((float)convertbpstombps(speed) * 1000)
    {
    Label = "Download",
    ValueLabel = ((float)convertbpstombps(speed) * 1000).ToString(),
    Color = SKColor.Parse("#68B9C0")
    },
    new Microcharts.Entry(sw.Elapsed.Seconds+1)
    {
    Label = "Time",
    ValueLabel = (sw.Elapsed.Seconds.ToString()),
    Color = SKColor.Parse("#90D585")
    }
};

            var chart = new RadialGaugeChart { Entries = entries, BackgroundColor = SKColor.Parse("#0D0E21")};

            this.chartView.Chart =  chart;

           // Console.WriteLine("Download duration: {0}", sw.Elapsed);
            //Console.WriteLine("File size: {0}", fileInfo.Length.ToString("N0"));
            //Console.WriteLine("Speed: {0} Mbps ", convertbpstombps(speed)*1000);
        }
    }
}
