using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace BankSystem
{
    [ServiceContract]
   public interface IBank
    {
       
        [OperationContract]
        double GetBalance(string numAc);

        [OperationContract]
        List<string> GetAllAccount(string myAcc);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool SendMoney(string from, string to, double ammount);
    }
}
