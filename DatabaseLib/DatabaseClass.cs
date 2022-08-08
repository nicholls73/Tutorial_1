using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLib {
    public class DatabaseClass {
        List<DataStruct> dataStruct;

        public DatabaseClass() {
            dataStruct = new List<DataStruct>();

            uint pin = 0, acctNo;
            int balance;
            string firstName, lastName;
            DataStruct currDataStruct;
            DatabaseEntryGenerator entryGenerator = new DatabaseEntryGenerator();

            for (int i = 0; i < 50; i++) {
                entryGenerator.GetNextAccount(out pin, out acctNo, out firstName, out lastName, out balance);
                currDataStruct = new DataStruct(acctNo, pin, balance, firstName, lastName);

                dataStruct.Add(currDataStruct);
            }
        }

        public uint GetAcctNoByIndex(int index) {
            return dataStruct.ElementAt(index).acctNo;
        }

        public uint GetPINByIndex(int index) {
            return dataStruct.ElementAt(index).pin;
        }

        public string GetFirstNameByIndex(int index) {
            return dataStruct.ElementAt(index).firstName;
        }

        public string GetLastNameByIndex(int index) {
            return dataStruct.ElementAt(index).lastName;
        }

        public int GetBalanceByIndex(int index) {
            return dataStruct.ElementAt(index).balance;
        }

        public int GetNumRecords() {
            return dataStruct.Count;
        }
    }
}