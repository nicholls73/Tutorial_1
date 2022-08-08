using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLib {
    internal class DatabaseEntryGenerator {

        private Random random = new Random();

        public void GetNextAccount(out uint pin, out uint acctNo, out string firstName, out string lastName, out int balance) {
            pin = GetPIN();
            acctNo = GetAcctNo();
            firstName = GetFirstName();
            lastName = GetLastName();
            balance = GetBalance();
        }

        private string GetFirstName() {
            int randNo = random.Next(5);
            string firstName = "";

            switch (randNo) {
                case 0: firstName = "John"; break;
                case 1: firstName = "Mary"; break;
                case 2: firstName = "Jessica"; break;
                case 3: firstName = "Nathan"; break;
                case 4: firstName = "Tim"; break;
            }
            return firstName;
        }

        private string GetLastName() {
            int randNo = random.Next(5);
            string lastName = "";

            switch (randNo) {
                case 0: lastName = "Nguyen"; break;
                case 1: lastName = "Smith"; break;
                case 2: lastName = "van der Merwe"; break;
                case 3: lastName = "Hulley"; break;
                case 4: lastName = "Nicholls"; break;
            }
            return lastName;
        }

        private uint GetPIN() {
            int randNo = random.Next(5);
            uint PIN = 0;

            switch (randNo) {
                case 0: PIN = 0123; break;
                case 1: PIN = 4567; break;
                case 2: PIN = 8910; break;
                case 3: PIN = 1112; break;
                case 4: PIN = 1314; break;
            }
            return PIN;
        }

        private uint GetAcctNo() {
            int randNo = random.Next(5);
            uint Acctno = 0;

            switch (randNo) {
                case 0: Acctno = 12345678; break;
                case 1: Acctno = 12345679; break;
                case 2: Acctno = 12345680; break;
                case 3: Acctno = 12345681; break;
                case 4: Acctno = 12345682; break;
            }
            return Acctno;
        }

        private int GetBalance() {
            int randNo = random.Next(5);
            int balance = 0;

            switch (randNo) {
                case 0: balance = -10; break;
                case 1: balance = 10; break;
                case 2: balance = 20; break;
                case 3: balance = 30; break;
                case 4: balance = 40; break;
            }
            return balance;
        }
    }
}