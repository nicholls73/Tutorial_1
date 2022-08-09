using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Server;

namespace WPFClient {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private DataServerInterface foob;
        public MainWindow() {
            //Set up the window
            InitializeComponent();

            //This is a factory that generates remote connections to our remote class. This is what hides the RPC stuff!
            ChannelFactory<DataServerInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();

            //Set the URL and create the connection!
            string URL = "net.tcp://localhost:8100/DataService";
            foobFactory = new ChannelFactory<DataServerInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();

            //Also, tell me how many entries are in the DB.
            TotalNum.Text = "Total Entries: " + foob.GetNumEntries().ToString();
        }

        private void GoButton_Click(object sender, RoutedEventArgs e) {
            int index = 0;
            string firstName = "", lastName = "";
            int balance = 0;
            uint acctNo = 0, pin = 0;

            //On click, Get the index....
            try {
                index = Int32.Parse(IndexInput.Text);
                if (index < 0 || index >= foob.GetNumEntries()) {
                    throw new FormatException();
                }
                else {
                    //Then, run our RPC function, using the out mode parameters...
                    foob.GetValuesForEntry(index, out acctNo, out pin, out balance, out firstName, out lastName);

                    //And now, set the values in the GUI!
                    FirstNameBox.Text = firstName;
                    LastNameBox.Text = lastName;
                    BalanceBox.Text = balance.ToString("C");
                    AcctNoBox.Text = acctNo.ToString();
                    PinBox.Text = pin.ToString("D4");
                }
            }
            catch (Exception ex) when (ex is FormatException || ex is FaultException) {
                FirstNameBox.Text = "ERROR";
                LastNameBox.Text = "ERROR";
                BalanceBox.Text = "ERROR";
                AcctNoBox.Text = "ERROR";
                PinBox.Text = "ERROR";
            }
        }
    }
}
