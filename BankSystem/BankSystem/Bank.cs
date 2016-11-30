using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;

namespace BankSystem
{
    public class Bank : IBank
    {
        Dictionary<string, double> list;
        string path;

        public Bank()
        {
            path = @"C:\Users\s24-rp\Desktop\BankSystem\BankSystem\bin\Debug\Balance.txt";
            list = new Dictionary<string, double>();
            LoadFromFile();
        }

        void LoadFromFile()
        {
            try
            {
                var file = File.ReadAllLines(path);
                foreach (var item in file)
                {
                    var str = item.Split('=');
                    list.Add(str[0], (Double.Parse(str[1])));
                }
            }catch (Exception ex) { }
        }

        void SaveToFile()
        {
            try
            {
                File.Delete(path);
                foreach (var item in list)
                {
                    File.AppendAllText(path, item.Key + "=" + item.Value + "\r\n");
                }
            }catch(Exception ex) { }
        }
        
        public double GetBalance(string numAc)
        {
            return list[numAc];
        }

       [OperationBehavior(TransactionScopeRequired = true)]
        public bool SendMoney(string from, string to, double ammount)
        {

            try
            {
                if ((list[from] - ammount) >= 0)
                {
                    list[from] -= ammount;
                    list[to] += ammount;
                    SaveToFile();
                    return true;
                }
                else return false;
            }catch(Exception ex) { return false; }
        }

        public List<string> GetAllAccount(string myAcc)
        {
            List<string> accounts = new List<string>();
            foreach (var item in list)
            {
                if (item.Key != myAcc)
                    accounts.Add(item.Key);
            }
            return accounts;
        }
    }
}
