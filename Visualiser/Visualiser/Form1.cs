using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace Visualiser
{
    public partial class cursor : Form
    {
        SerialPort choosenPort;
        String[] portsAvailable;
        bool isConnected = false;
        Thread Hilo;
        int posX, posY;
        int x;
        int y;
        string i;
        int sumX, sumY;

        public cursor()
        {
            InitializeComponent();
            setPorts();
            posX = cursorek.Location.X;
            posY = cursorek.Location.Y;
        }

        private void cursor_Load(object sender, EventArgs e)
        {
            //A Thread to listen forever the serial port
            Hilo = new Thread(ListenSerial);
            Hilo.Start();
        }

        private void ListenSerial()
        {
            while (true)
            {
                try
                {
                    //read to data from arduino
                    string lastRead = choosenPort.ReadLine();
                    if (lastRead.StartsWith("X"))
                    {
                        int s1 = lastRead.IndexOf("X:");
                        int s2 = lastRead.IndexOf("/Z:");
                        int s3 = lastRead.IndexOf("/I:");
                        int s4 = lastRead.IndexOf("//");
                        //x = lastRead.Substring(s1+2, s2 - s1 - 2);
                        y = System.Convert.ToInt32(lastRead.Substring(s2+3, s3 - s2 - 3));
                        i = lastRead.Substring(s3+3, s4 - s3 - 3);
                        x = System.Convert.ToInt32(lastRead.Substring(s1 + 2, s2 - s1 - 2));
                        if (sumX+x > -400 || sumX+x <400)
                            sumX += x;
                        if (sumY+y > -300 || sumY +y < 300)
                            sumY += y;
                    }
                    //write the data in something textbox
                    outputTextBox.Invoke(new MethodInvoker(
                        delegate
                        {
                            outputTextBox.Text = lastRead;
                        }
                        ));
                    cursorek.Invoke(new MethodInvoker(
                        delegate
                        {
                            cursorek.Location = new Point(posX+x, posY+y);
                        }
                        ));

                }
                catch { }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //when the form will be closed this line close the serial port
            if (isConnected)
                choosenPort.Close();
            Hilo.Abort();
        }

        private void setPorts()
        {
            portsAvailable = SerialPort.GetPortNames();
            foreach (string port in portsAvailable)
            {
                selectPortBox.Items.Add(port);
            }
        }
        private void setStatus(string newStatus)
        {
            outputTextBox.Text = newStatus;
        }
        private void setControlls(bool isOn)
        {            
            selectPortBox.Enabled = !isOn;
            connectButton.Enabled = !isOn;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            string selectedPort = selectPortBox.GetItemText(selectPortBox.SelectedItem);
            if (!string.IsNullOrEmpty(selectPortBox.Text))
            {
                setStatus("Port selected");
                choosenPort = new SerialPort(selectedPort, 115200, Parity.None, 8, StopBits.One);
                if (!isConnected)
                {
                    try
                    {
                        choosenPort.Open();
                        setStatus("Enabling");
                    }
                    catch
                    {
                        setStatus("Port busy");
                    }
                }

                if (choosenPort.IsOpen)
                {
                    choosenPort.ReadTimeout = 10000;
                    try
                    {
                        isConnected = true;
                        setControlls(isConnected);
                    }
                    catch (TimeoutException)
                    {
                        setStatus("No connection");
                        choosenPort.Close();
                    }
                }
            }
        }

        private void eButton_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                choosenPort.WriteLine("e");
            }
        }

        private void dButton_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                choosenPort.WriteLine("d");
            }
        }

    }
}
