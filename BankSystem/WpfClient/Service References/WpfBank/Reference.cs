﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfClient.WpfBank {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WpfBank.IBank")]
    public interface IBank {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBank/GetBalance", ReplyAction="http://tempuri.org/IBank/GetBalanceResponse")]
        double GetBalance(string numAc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBank/GetBalance", ReplyAction="http://tempuri.org/IBank/GetBalanceResponse")]
        System.Threading.Tasks.Task<double> GetBalanceAsync(string numAc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBank/GetAllAccount", ReplyAction="http://tempuri.org/IBank/GetAllAccountResponse")]
        string[] GetAllAccount(string myAcc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBank/GetAllAccount", ReplyAction="http://tempuri.org/IBank/GetAllAccountResponse")]
        System.Threading.Tasks.Task<string[]> GetAllAccountAsync(string myAcc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBank/SendMoney", ReplyAction="http://tempuri.org/IBank/SendMoneyResponse")]
        bool SendMoney(string from, string to, double ammount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBank/SendMoney", ReplyAction="http://tempuri.org/IBank/SendMoneyResponse")]
        System.Threading.Tasks.Task<bool> SendMoneyAsync(string from, string to, double ammount);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBankChannel : WpfClient.WpfBank.IBank, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BankClient : System.ServiceModel.ClientBase<WpfClient.WpfBank.IBank>, WpfClient.WpfBank.IBank {
        
        public BankClient() {
        }
        
        public BankClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BankClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BankClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BankClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double GetBalance(string numAc) {
            return base.Channel.GetBalance(numAc);
        }
        
        public System.Threading.Tasks.Task<double> GetBalanceAsync(string numAc) {
            return base.Channel.GetBalanceAsync(numAc);
        }
        
        public string[] GetAllAccount(string myAcc) {
            return base.Channel.GetAllAccount(myAcc);
        }
        
        public System.Threading.Tasks.Task<string[]> GetAllAccountAsync(string myAcc) {
            return base.Channel.GetAllAccountAsync(myAcc);
        }
        
        public bool SendMoney(string from, string to, double ammount) {
            return base.Channel.SendMoney(from, to, ammount);
        }
        
        public System.Threading.Tasks.Task<bool> SendMoneyAsync(string from, string to, double ammount) {
            return base.Channel.SendMoneyAsync(from, to, ammount);
        }
    }
}
