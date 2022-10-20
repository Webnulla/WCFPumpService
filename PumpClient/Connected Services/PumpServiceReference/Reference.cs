﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PumpClient.PumpServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StatisticsService", Namespace="http://schemas.datacontract.org/2004/07/WCFPumpService")]
    [System.SerializableAttribute()]
    public partial class StatisticsService : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AllTactsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ErrorTactsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SuccessTactsField;
        
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
        public int AllTacts {
            get {
                return this.AllTactsField;
            }
            set {
                if ((this.AllTactsField.Equals(value) != true)) {
                    this.AllTactsField = value;
                    this.RaisePropertyChanged("AllTacts");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ErrorTacts {
            get {
                return this.ErrorTactsField;
            }
            set {
                if ((this.ErrorTactsField.Equals(value) != true)) {
                    this.ErrorTactsField = value;
                    this.RaisePropertyChanged("ErrorTacts");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SuccessTacts {
            get {
                return this.SuccessTactsField;
            }
            set {
                if ((this.SuccessTactsField.Equals(value) != true)) {
                    this.SuccessTactsField = value;
                    this.RaisePropertyChanged("SuccessTacts");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Microsoft.ServiceModel.Samples", ConfigurationName="PumpServiceReference.IPumpService", CallbackContract=typeof(PumpClient.PumpServiceReference.IPumpServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IPumpService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IPumpService/RunScript", ReplyAction="http://Microsoft.ServiceModel.Samples/IPumpService/RunScriptResponse")]
        void RunScript();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IPumpService/RunScript", ReplyAction="http://Microsoft.ServiceModel.Samples/IPumpService/RunScriptResponse")]
        System.Threading.Tasks.Task RunScriptAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IPumpService/UpdateAndCompileScript", ReplyAction="http://Microsoft.ServiceModel.Samples/IPumpService/UpdateAndCompileScriptResponse" +
            "")]
        void UpdateAndCompileScript(string fileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IPumpService/UpdateAndCompileScript", ReplyAction="http://Microsoft.ServiceModel.Samples/IPumpService/UpdateAndCompileScriptResponse" +
            "")]
        System.Threading.Tasks.Task UpdateAndCompileScriptAsync(string fileName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPumpServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IPumpService/UpdateStatistic", ReplyAction="http://Microsoft.ServiceModel.Samples/IPumpService/UpdateStatisticResponse")]
        void UpdateStatistic(PumpClient.PumpServiceReference.StatisticsService statistics);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPumpServiceChannel : PumpClient.PumpServiceReference.IPumpService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PumpServiceClient : System.ServiceModel.DuplexClientBase<PumpClient.PumpServiceReference.IPumpService>, PumpClient.PumpServiceReference.IPumpService {
        
        public PumpServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public PumpServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public PumpServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public PumpServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public PumpServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void RunScript() {
            base.Channel.RunScript();
        }
        
        public System.Threading.Tasks.Task RunScriptAsync() {
            return base.Channel.RunScriptAsync();
        }
        
        public void UpdateAndCompileScript(string fileName) {
            base.Channel.UpdateAndCompileScript(fileName);
        }
        
        public System.Threading.Tasks.Task UpdateAndCompileScriptAsync(string fileName) {
            return base.Channel.UpdateAndCompileScriptAsync(fileName);
        }
    }
}
