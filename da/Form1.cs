using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace da
{
    public partial class Form1 : Form
    {
        private ApplicationInstance m_Application = null;
        private Session m_Session = null;
        private Subscription m_Subscription = null;

        List<MonitoredItem> monitoredItems = new List<MonitoredItem>();


        public Form1(ApplicationInstance applicationInstance)
        {
            InitializeComponent();

            m_Application = applicationInstance;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //�������� ������
            m_Session = new Session(m_Application);

            m_Session.UseDnsNameAndPortFromDiscoveryUrl = true;
            m_Session.DefaultRequestSettings.OperationTimeout = 30000;

            // ����������� ����������� �������
            m_Session.ConnectionStatusUpdate += new ServerConnectionStatusUpdateEventHandler(Session_ServerConnectionStatusUpdate);

            //���������� � ��������
            m_Session.Connect(comboBox1.Text, SecuritySelection.None);


        }

        private void Session_ServerConnectionStatusUpdate(Session sender, ServerConnectionStatusUpdateEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ServerConnectionStatusUpdateEventHandler(Session_ServerConnectionStatusUpdate), sender, e);
                return;
            }

            if (!Object.ReferenceEquals(m_Session, sender))
                return;

            lock (this)
            {
                switch (e.Status)
                {
                    case ServerConnectionStatus.Disconnected:
                        button1.Text = "Connect";
                        break;

                    case ServerConnectionStatus.Connected:
                        button1.Text = "Disconnect";

                        // �������� ������ � �������� browseControl
                        browseControl1.Session = m_Session;
                        browseControl1.Browse(null);


                        // ����������� ������ ����� OPC UA

                        break;

                    case ServerConnectionStatus.LicenseExpired:
                        MessageBox.Show("�������� �������.");
                        button1.Enabled = false;
                        break;
                }
            }
        }



        private void �������_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DataValue val1 = new DataValue();
            List<WriteValue> nodesToWrite = new List<WriteValue>();
            if (checkBox1.Checked)
            {
                val1.Value = TypeUtils.Cast("true", BuiltInType.Boolean);
                nodesToWrite.Add(new WriteValue()
                {
                    NodeId = new NodeId("\"start\"", 3),
                    AttributeId = Attributes.Value,
                    Value = val1
                });
            }
            else {
                val1.Value = TypeUtils.Cast("false", BuiltInType.Boolean);
                nodesToWrite.Add(new WriteValue()
                {
                    NodeId = new NodeId("\"start\"", 3),
                    AttributeId = Attributes.Value,
                    Value = val1
                });
            }
            // ������ �������� �����
            List<StatusCode> results = m_Session.Write(nodesToWrite);
            if (StatusCode.IsGood(results[0]))
            {
                MessageBox.Show("������� �������!");
            }
            else
            {
                MessageBox.Show("������� ����������!");
            }

        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // �������� ��������
            m_Subscription = new Subscription(m_Session);
            m_Subscription.PublishingEnabled = true;
            m_Subscription.PublishingInterval = 250;

            // ����������� ����������� ������� DataChanged
            m_Subscription.DataChanged += new
                                          DataChangedEventHandler(Subscription_DataChanged);
            // �������� ��������
            m_Subscription.Create();

            // ���������� ����� �� ��������
            List<StatusCode> results = m_Subscription.CreateMonitoredItems(monitoredItems);

        }
        private void Subscription_DataChanged(Subscription subscription,
                                      DataChangedEventArgs e)
        {
            // ��������, ��� ���� ����� ������ �� ������ ����������������� ����������
            // ��� ��� �� �������� ������� ��������� ����������
            if (InvokeRequired)
            {
                BeginInvoke(new DataChangedEventHandler(Subscription_DataChanged),
                            subscription, e);
                return;
            }

            try
            {
                // ��������, �������� �� ��������
                if (!Object.ReferenceEquals(m_Subscription, subscription))
                {
                    return;
                }

                foreach (DataChange change in e.DataChanges)
                {
                    // ��������� TextBox ��  user data ��� ����������� �������� ���� 
                    TextBox textBox = change.MonitoredItem.UserData as TextBox;

                    if (textBox != null)
                    {
                        // ����� �������� ����������
                        if (StatusCode.IsGood(change.Value.StatusCode))
                        {
                            // ���� ���� ������� ��������� � �� ����� �������� ��� ������
                            textBox.Text = change.Value.WrappedValue.ToString();
                            textBox.BackColor = Color.White;
                        }
                        else
                        {
                            // ���� ������ ���� �� ������� � �� ����� ������
                            textBox.Text = change.Value.StatusCode.ToString();
                            textBox.BackColor = Color.Red;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show("Error in DataChanged callback", exception);
            }
        }



        // ���������� ��� � Form1.cs
        private void textBox1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            string sNodeId = (string)e.Data.GetData(typeof(string));
            NodeId nodeId = NodeId.Parse(sNodeId);

            label1.Text = nodeId.Identifier.ToString();  // ������ NodeId � �����, ���� ������
            textBox1.Text = nodeId.Identifier.ToString(); // ������ � ��������� ����

            // ������� ���� � ������ ��������
            monitoredItems.Add(new DataMonitoredItem(nodeId) { UserData = textBox1 });
        }

        private void textBox2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void textBox2_DragDrop(object sender, DragEventArgs e)
        {
            string sNodeId = (string)e.Data.GetData(typeof(string));
            NodeId nodeId = NodeId.Parse(sNodeId);

            label2.Text = nodeId.Identifier.ToString();  // ������ NodeId � �����, ���� ������
            textBox2.Text = nodeId.Identifier.ToString(); // ������ � ��������� ����

            // ������� ���� � ������ ��������
            monitoredItems.Add(new DataMonitoredItem(nodeId) { UserData = textBox2 });
        }


        private void textBox3_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void textBox3_DragDrop(object sender, DragEventArgs e)
        {
            string sNodeId = (string)e.Data.GetData(typeof(string));
            NodeId nodeId = NodeId.Parse(sNodeId);

            label3.Text = nodeId.Identifier.ToString();  // ������ NodeId � �����, ���� ������
            textBox3.Text = nodeId.Identifier.ToString(); // ������ � ��������� ����

            // ������� ���� � ������ ��������
            monitoredItems.Add(new DataMonitoredItem(nodeId) { UserData = textBox3});
        }


        private void textBox4_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void textBox4_DragDrop(object sender, DragEventArgs e)
        {
            string sNodeId = (string)e.Data.GetData(typeof(string));
            NodeId nodeId = NodeId.Parse(sNodeId);

            label4.Text = nodeId.Identifier.ToString();  // ������ NodeId � �����, ���� ������
            textBox4.Text = nodeId.Identifier.ToString(); // ������ � ��������� ����

            // ������� ���� � ������ ��������
            monitoredItems.Add(new DataMonitoredItem(nodeId) { UserData = textBox4 });
        }

        private void textBox5_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void textBox5_DragDrop(object sender, DragEventArgs e)
        {
            string sNodeId = (string)e.Data.GetData(typeof(string));
            NodeId nodeId = NodeId.Parse(sNodeId);

            label5.Text = nodeId.Identifier.ToString();  // ������ NodeId � �����, ���� ������
            textBox5.Text = nodeId.Identifier.ToString(); // ������ � ��������� ����

            // ������� ���� � ������ ��������
            monitoredItems.Add(new DataMonitoredItem(nodeId) { UserData = textBox5});
        }
        private void textBox6_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void textBox6_DragDrop(object sender, DragEventArgs e)
        {
            string sNodeId = (string)e.Data.GetData(typeof(string));
            NodeId nodeId = NodeId.Parse(sNodeId);

            label6.Text = nodeId.Identifier.ToString();  // ������ NodeId � �����, ���� ������
            textBox6.Text = nodeId.Identifier.ToString(); // ������ � ��������� ����

            // ������� ���� � ������ ��������
            monitoredItems.Add(new DataMonitoredItem(nodeId) { UserData = textBox6 });
        }
    }
}
