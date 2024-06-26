﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Server {
    [ServiceContract]
    public interface DataServerInterface {
        [OperationContract]
        int GetNumEntries();
        [OperationContract]
        [FaultContract(typeof(ArgumentOutOfRangeException))]
        void GetValuesForEntry(int index, out uint acctNo, out uint pin, out int bal, out string firstName, out string lastName);
    }
}