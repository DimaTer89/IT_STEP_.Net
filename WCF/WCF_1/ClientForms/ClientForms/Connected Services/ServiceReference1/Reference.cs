﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientForms.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Person", Namespace="http://schemas.datacontract.org/2004/07/Calculate")]
    [System.SerializableAttribute()]
    public partial class Person : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double WeightField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Weight {
            get {
                return this.WeightField;
            }
            set {
                if ((this.WeightField.Equals(value) != true)) {
                    this.WeightField = value;
                    this.RaisePropertyChanged("Weight");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ICalculateContract")]
    public interface ICalculateContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculateContract/Plus", ReplyAction="http://tempuri.org/ICalculateContract/PlusResponse")]
        double Plus(double x, double y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculateContract/Plus", ReplyAction="http://tempuri.org/ICalculateContract/PlusResponse")]
        System.Threading.Tasks.Task<double> PlusAsync(double x, double y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculateContract/Sqr", ReplyAction="http://tempuri.org/ICalculateContract/SqrResponse")]
        double Sqr(double x);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculateContract/Sqr", ReplyAction="http://tempuri.org/ICalculateContract/SqrResponse")]
        System.Threading.Tasks.Task<double> SqrAsync(double x);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICalculateContractChannel : ClientForms.ServiceReference1.ICalculateContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalculateContractClient : System.ServiceModel.ClientBase<ClientForms.ServiceReference1.ICalculateContract>, ClientForms.ServiceReference1.ICalculateContract {
        
        public CalculateContractClient() {
        }
        
        public CalculateContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CalculateContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculateContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculateContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double Plus(double x, double y) {
            return base.Channel.Plus(x, y);
        }
        
        public System.Threading.Tasks.Task<double> PlusAsync(double x, double y) {
            return base.Channel.PlusAsync(x, y);
        }
        
        public double Sqr(double x) {
            return base.Channel.Sqr(x);
        }
        
        public System.Threading.Tasks.Task<double> SqrAsync(double x) {
            return base.Channel.SqrAsync(x);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IDopContract")]
    public interface IDopContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDopContract/SinXCosY", ReplyAction="http://tempuri.org/IDopContract/SinXCosYResponse")]
        double SinXCosY(double x, double y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDopContract/SinXCosY", ReplyAction="http://tempuri.org/IDopContract/SinXCosYResponse")]
        System.Threading.Tasks.Task<double> SinXCosYAsync(double x, double y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDopContract/TexX", ReplyAction="http://tempuri.org/IDopContract/TexXResponse")]
        double TexX(double x);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDopContract/TexX", ReplyAction="http://tempuri.org/IDopContract/TexXResponse")]
        System.Threading.Tasks.Task<double> TexXAsync(double x);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDopContractChannel : ClientForms.ServiceReference1.IDopContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DopContractClient : System.ServiceModel.ClientBase<ClientForms.ServiceReference1.IDopContract>, ClientForms.ServiceReference1.IDopContract {
        
        public DopContractClient() {
        }
        
        public DopContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DopContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DopContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DopContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double SinXCosY(double x, double y) {
            return base.Channel.SinXCosY(x, y);
        }
        
        public System.Threading.Tasks.Task<double> SinXCosYAsync(double x, double y) {
            return base.Channel.SinXCosYAsync(x, y);
        }
        
        public double TexX(double x) {
            return base.Channel.TexX(x);
        }
        
        public System.Threading.Tasks.Task<double> TexXAsync(double x) {
            return base.Channel.TexXAsync(x);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IPersonContract")]
    public interface IPersonContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonContract/WeightPlus", ReplyAction="http://tempuri.org/IPersonContract/WeightPlusResponse")]
        ClientForms.ServiceReference1.WeightPlusResponse WeightPlus(ClientForms.ServiceReference1.WeightPlusRequest request);
        
        // CODEGEN: Идет формирование контракта на сообщение, так как операция может иметь много возвращаемых значений.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonContract/WeightPlus", ReplyAction="http://tempuri.org/IPersonContract/WeightPlusResponse")]
        System.Threading.Tasks.Task<ClientForms.ServiceReference1.WeightPlusResponse> WeightPlusAsync(ClientForms.ServiceReference1.WeightPlusRequest request);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IPersonContract/HelloPerson")]
        void HelloPerson(ClientForms.ServiceReference1.Person person, string hello);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IPersonContract/HelloPerson")]
        System.Threading.Tasks.Task HelloPersonAsync(ClientForms.ServiceReference1.Person person, string hello);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WeightPlus", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class WeightPlusRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public ClientForms.ServiceReference1.Person person;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public double x;
        
        public WeightPlusRequest() {
        }
        
        public WeightPlusRequest(ClientForms.ServiceReference1.Person person, double x) {
            this.person = person;
            this.x = x;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WeightPlusResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class WeightPlusResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public double WeightPlusResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public ClientForms.ServiceReference1.Person person;
        
        public WeightPlusResponse() {
        }
        
        public WeightPlusResponse(double WeightPlusResult, ClientForms.ServiceReference1.Person person) {
            this.WeightPlusResult = WeightPlusResult;
            this.person = person;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPersonContractChannel : ClientForms.ServiceReference1.IPersonContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PersonContractClient : System.ServiceModel.ClientBase<ClientForms.ServiceReference1.IPersonContract>, ClientForms.ServiceReference1.IPersonContract {
        
        public PersonContractClient() {
        }
        
        public PersonContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PersonContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PersonContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PersonContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClientForms.ServiceReference1.WeightPlusResponse ClientForms.ServiceReference1.IPersonContract.WeightPlus(ClientForms.ServiceReference1.WeightPlusRequest request) {
            return base.Channel.WeightPlus(request);
        }
        
        public double WeightPlus(ref ClientForms.ServiceReference1.Person person, double x) {
            ClientForms.ServiceReference1.WeightPlusRequest inValue = new ClientForms.ServiceReference1.WeightPlusRequest();
            inValue.person = person;
            inValue.x = x;
            ClientForms.ServiceReference1.WeightPlusResponse retVal = ((ClientForms.ServiceReference1.IPersonContract)(this)).WeightPlus(inValue);
            person = retVal.person;
            return retVal.WeightPlusResult;
        }
        
        public System.Threading.Tasks.Task<ClientForms.ServiceReference1.WeightPlusResponse> WeightPlusAsync(ClientForms.ServiceReference1.WeightPlusRequest request) {
            return base.Channel.WeightPlusAsync(request);
        }
        
        public void HelloPerson(ClientForms.ServiceReference1.Person person, string hello) {
            base.Channel.HelloPerson(person, hello);
        }
        
        public System.Threading.Tasks.Task HelloPersonAsync(ClientForms.ServiceReference1.Person person, string hello) {
            return base.Channel.HelloPersonAsync(person, hello);
        }
    }
}
