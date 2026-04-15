using System.Net.Sockets;

namespace MyHMI_ver1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Link the following functions
        private void button1_Click(object sender, EventArgs e)
        {
            Thread connection = new Thread(Connect2Server);
            connection.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sendMessage();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UIavilable = false;
            disconnectClient();
        }

        // UI handler functions
        bool UIavilable = true;
        private void clearTextboxFromSubprocess(RichTextBox textBox)
        {
            if (UIavilable)
            {
                Invoke(new MethodInvoker(() =>
                {
                    textBox.Text = "";
                }));
            }
        }
        private void write2TextboxFromSubprocess(RichTextBox textBox, string text)
        {
            if (UIavilable)
            {
                Invoke(new MethodInvoker(() =>
                {
                    if (UIavilable) textBox.Text += "\n" + text;
                }));
            }
        }
        private void write2TextboxFromSubprocessV2(RichTextBox textBox, string text)
        {
            if (UIavilable)
            {
                Invoke(new MethodInvoker(() =>
                {
                    if (UIavilable) textBox.Text = text;
                }));
            }
        }

        private void enableButtonFromSubprocess(Button button)
        {
            if (UIavilable)
            {
                Invoke(new MethodInvoker(() =>
                {
                    button.Enabled = true;
                }));
            }
        }
        private void disableButtonFromSubprocess(Button button)
        {
            if (UIavilable)
            {
                Invoke(new MethodInvoker(() =>
                {
                    button.Enabled = false;
                }));
            }
        }
        //client functions
        TcpClient client = null;
        bool keepConnection = false;
        private void Connect2Server()
        {
            try
            {
                disableButtonFromSubprocess(button1);
                client = new TcpClient("10.48.185.48", 502);
                if (client.Connected)
                {
                    keepConnection = true;
                    NetworkStream stream = client.GetStream();
                    int bytesRead = 0;
                    byte[] buffer = new byte[1024];
                    while (keepConnection && client.Connected)
                    {
                        if (!stream.DataAvailable)
                        {
                            bytesRead = 0;
                        }
                        bytesRead = stream.Read(buffer, 0, buffer.Length);
                        if (bytesRead == 0)
                        {
                            break;
                        }
                        else
                        {
                            if (buffer[2] == 0 && buffer[3] == 0)
                            {//checking Protocol iddentifier

                                write2TextboxFromSubprocess(richTextBox1, "Protocol ID OK");
                                Int16 ExpectedBytes = (Int16)(3 + RegQty * 2);
                                if (buffer[4] == (byte)ExpectedBytes >> 8 && buffer[5] == (byte)ExpectedBytes)
                                {// Checking the TCP lenght
                                    write2TextboxFromSubprocess(richTextBox1, "TCP Length OK");
                                    if (buffer[6] == ModbusID)
                                    {
                                        write2TextboxFromSubprocess(richTextBox1, "ModbusID OK");
                                        if (buffer[7] == 0x04)//checking the function
                                        {
                                            write2TextboxFromSubprocess(richTextBox1, "Function OK");
                                            Int16 ExpectedDataBytes = (Int16)(RegQty * 2);
                                            if (buffer[8] == ExpectedDataBytes)//Expected data bytes
                                            {
                                                write2TextboxFromSubprocess(richTextBox1, "Data-bytes OK");
                                                //buffer[9] --reg 12 temp float little endian
                                                //buffer[10]
                                                //buffer[11]--reg 13
                                                //buffer[12]
                                                //buffer[13]--14-- pressure
                                                //buffer[14]
                                                //buffer[15]--15
                                                //buffer[16]
                                                //buffer[17]--16--flow
                                                //buffer[18]
                                                write2TextboxFromSubprocessV2(richTextBox2, $"The flow is {buffer[17] * 256 + buffer[18]}");

                                                float temperature = BitConverter.ToSingle(buffer, 9);
                                                write2TextboxFromSubprocessV2(richTextBox3, $"The temperature is {temperature}");

                                                byte[] presureBuffer = new byte[4];
                                                presureBuffer[0] = buffer[16];
                                                presureBuffer[1] = buffer[15];
                                                presureBuffer[2] = buffer[14];
                                                presureBuffer[3] = buffer[13];
                                                float pressure = BitConverter.ToSingle(presureBuffer, 0);
                                                write2TextboxFromSubprocessV2(richTextBox4, $"The pressure is {pressure}");
                                            }
                                        }
                                    }
                                }
                            }
                            write2TextboxFromSubprocess(richTextBox1, "New message");
                        }
                    }
                }
                else
                {
                    write2TextboxFromSubprocess(richTextBox1, "connection failed");
                }
            }
            catch (Exception ex)
            {
                write2TextboxFromSubprocess(richTextBox1, ex.ToString());
            }
            finally
            {
                if (client != null && client.Connected)
                {
                    NetworkStream stream = client.GetStream();
                    stream.Close();
                    client.Close();
                }
                enableButtonFromSubprocess(button1);
            }
        }
        Int16 TransactionID = 0;
        Int16 MessageLength = 6;
        byte ModbusID = 17;
        Int16 Address = 12;
        Int16 RegQty = 5;
        private void sendMessage()
        {
            if (UIavilable && client != null && client.Connected)
            {
                NetworkStream stream = client.GetStream();
                byte[] bytes2send = new byte[12];
                bytes2send[0] = (byte)(TransactionID >> 8);
                bytes2send[1] = (byte)(TransactionID);
                bytes2send[2] = 0X00;//Protocol ID
                bytes2send[3] = 0X00;//Protocol ID
                bytes2send[4] = (byte)(MessageLength >> 8);
                bytes2send[5] = (byte)(MessageLength);
                bytes2send[6] = ModbusID;
                bytes2send[7] = 0x04;//function 4
                bytes2send[8] = (byte)(Address >> 8);
                bytes2send[9] = (byte)(Address);
                bytes2send[10] = (byte)(RegQty >> 8);
                bytes2send[11] = (byte)(RegQty);
                stream.Write(bytes2send);
                TransactionID++;
            }
        }
        private void disconnectClient()
        {
            keepConnection = false;
            if (client != null)
                client.Close();
        }
    }
}
