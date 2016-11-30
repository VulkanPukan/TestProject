using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace chat
{
    public partial class Form1 : Form
    {
        UdpClient udpSend = null;
        UdpClient udpReceive = null;

        int udpSendPort = 4422;
        int udpReceivePort = 4425;

        public Form1()
        {
            InitializeComponent();

            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (udpSend != null)
            {
                SendMessage("CL_DISC<<" + nickname.Text);
            }
        }

        private void ConnectToChat()
        {
            IPEndPoint udpSendPoint = new IPEndPoint(
                Dns.Resolve(SystemInformation.ComputerName).AddressList[0],
                udpSendPort
            );

            IPEndPoint udpReceivePoint = new IPEndPoint(
                Dns.Resolve(SystemInformation.ComputerName).AddressList[0],
                udpReceivePort
            );

            udpSend = new UdpClient(udpSendPoint);
            udpReceive = new UdpClient(udpReceivePoint);

            Thread receiveMsg = new Thread(ReceiveMessages);
            receiveMsg.IsBackground = true;

            Thread sendMsg = new Thread(UpdateUsers);
            sendMsg.IsBackground = true;

            receiveMsg.Start();
            sendMsg.Start();

        }

        private void UpdateUsers()
        {
            while(true)
            {
                SendMessage("CL_UPD<<" + nickname.Text);
                Thread.Sleep(1000);
            }
        }

        private void ReceiveMessages()
        {
            while (true)
            {
                string message = ReadMessage();

                if (message.Contains("<<"))
                {
                    ParseCommand(message);
                }
                else
                {
                    richTextBox1.Invoke(new Action(() =>
                    {
                        richTextBox1.Text += Environment.NewLine + message;
                    }));
                }

                Thread.Sleep(10);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ParseCommand(string message)
        {
            string[] command = message.Split(new string[] { "<<" }, StringSplitOptions.None);

            string commandDesc = command[0];
            string commandText = command[1];

            switch (commandDesc)
            {
                case "CL_UPD":
                    {
                        listBox1.Invoke(
                            new Action(() =>
                            {
                                if (!listBox1.Items.Contains(commandText))
                                {
                                    listBox1.Items.Add(commandText);
                                }
                            }
                        ));
                    };
                break;

                case "CL_DISC":
                    {
                        listBox1.Invoke(
                            new Action(() =>
                            {
                                listBox1.Items.Remove(commandText);
                            }
                        ));
                    }
                break;
            }
        }

        private void SendMessage(string message)
        {
            byte[] commandText = Encoding.ASCII.GetBytes(message);

            udpSend.Connect(IPAddress.Broadcast, udpReceivePort);
            udpSend.Send(commandText, commandText.Length);
        }

        private string ReadMessage()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, udpReceivePort);
            byte[] command = udpReceive.Receive(ref endPoint);

            return Encoding.ASCII.GetString(command, 0, command.Length);
        }

        private void applyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectToChat();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMessage(nickname.Text + ":" + textBox1.Text);
        }
    }
}
