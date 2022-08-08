using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using DatabaseLib;

namespace Server {
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    internal class DataServer : DataServerInterface {
        private DatabaseClass database;

        public DataServer() {
            database = new DatabaseClass();
        }

        public int GetNumEntries() {
            return database.GetNumRecords();
        }

        public void GetValuesForEntry(int index, out uint acctNo, out uint pin, out int bal, out string firstName, out string lastName) {
            acctNo = database.GetAcctNoByIndex(index);
            pin = database.GetPINByIndex(index);
            bal = database.GetBalanceByIndex(index);
            firstName = database.GetFirstNameByIndex(index);
            lastName = database.GetLastNameByIndex(index);
        }
    }
}