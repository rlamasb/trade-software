﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Imports.clientSSI {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ssi.com.vn/", ConfigurationName="clientSSI.AjaxWebServiceSoap")]
    public interface AjaxWebServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetStatusBasePrice", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetStatusBasePrice(int tradingFloor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHoseIndex", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHoseIndex();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetDataHoseStockList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetDataHoseStockList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHoseStockQuoteInit", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHoseStockQuoteInit();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHoseStockQuote", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHoseStockQuote(long VersionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHoseIndexChart", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHoseIndexChart();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHosePTInit", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHosePTInit();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHosePTMatch", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHosePTMatch(long VersionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHosePTBid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHosePTBid(long VersionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHosePTOffer", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHosePTOffer(long VersionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHose30Index", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHose30Index();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetDataHose30StockList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetDataHose30StockList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHose30StockQuoteInit", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHose30StockQuoteInit();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHose30StockQuote", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHose30StockQuote(long VersionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHnxIndex", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHnxIndex();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetDataHnxStockList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetDataHnxStockList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHnxStockQuoteInit", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHnxStockQuoteInit();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHnxStockQuote", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHnxStockQuote(long VersionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHnxTop3Price", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHnxTop3Price(long VersionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHnxIndexChart", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHnxIndexChart();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHnxPTInit", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHnxPTInit();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHnxPTMatch", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHnxPTMatch(long VersionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHnxPTBid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHnxPTBid(long VersionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHnxPTOffer", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHnxPTOffer(long VersionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHnx30Index", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHnx30Index();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHnx30StockList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHnx30StockList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHnx30StockQuoteInit", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHnx30StockQuoteInit();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHnx30StockQuote", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHnx30StockQuote(long VersionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetHnx30Top3Price", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetHnx30Top3Price(long VersionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetMarketAllIndex", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetMarketAllIndex(long VersionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetUpcomIndex", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetUpcomIndex();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetUpcomStockList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetUpcomStockList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetUpcomStockQuoteInit", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetUpcomStockQuoteInit();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetUpcomStockQuote", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetUpcomStockQuote(long VersionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetUpcomTop3Price", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetUpcomTop3Price(long VersionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ssi.com.vn/GetUpcomIndexChart", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetUpcomIndexChart();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AjaxWebServiceSoapChannel : Imports.clientSSI.AjaxWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AjaxWebServiceSoapClient : System.ServiceModel.ClientBase<Imports.clientSSI.AjaxWebServiceSoap>, Imports.clientSSI.AjaxWebServiceSoap {
        
        public AjaxWebServiceSoapClient() {
        }
        
        public AjaxWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AjaxWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AjaxWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AjaxWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetStatusBasePrice(int tradingFloor) {
            return base.Channel.GetStatusBasePrice(tradingFloor);
        }
        
        public string GetHoseIndex() {
            return base.Channel.GetHoseIndex();
        }
        
        public string GetDataHoseStockList() {
            return base.Channel.GetDataHoseStockList();
        }
        
        public string GetHoseStockQuoteInit() {
            return base.Channel.GetHoseStockQuoteInit();
        }
        
        public string GetHoseStockQuote(long VersionId) {
            return base.Channel.GetHoseStockQuote(VersionId);
        }
        
        public string GetHoseIndexChart() {
            return base.Channel.GetHoseIndexChart();
        }
        
        public string GetHosePTInit() {
            return base.Channel.GetHosePTInit();
        }
        
        public string GetHosePTMatch(long VersionId) {
            return base.Channel.GetHosePTMatch(VersionId);
        }
        
        public string GetHosePTBid(long VersionId) {
            return base.Channel.GetHosePTBid(VersionId);
        }
        
        public string GetHosePTOffer(long VersionId) {
            return base.Channel.GetHosePTOffer(VersionId);
        }
        
        public string GetHose30Index() {
            return base.Channel.GetHose30Index();
        }
        
        public string GetDataHose30StockList() {
            return base.Channel.GetDataHose30StockList();
        }
        
        public string GetHose30StockQuoteInit() {
            return base.Channel.GetHose30StockQuoteInit();
        }
        
        public string GetHose30StockQuote(long VersionId) {
            return base.Channel.GetHose30StockQuote(VersionId);
        }
        
        public string GetHnxIndex() {
            return base.Channel.GetHnxIndex();
        }
        
        public string GetDataHnxStockList() {
            return base.Channel.GetDataHnxStockList();
        }
        
        public string GetHnxStockQuoteInit() {
            return base.Channel.GetHnxStockQuoteInit();
        }
        
        public string GetHnxStockQuote(long VersionId) {
            return base.Channel.GetHnxStockQuote(VersionId);
        }
        
        public string GetHnxTop3Price(long VersionId) {
            return base.Channel.GetHnxTop3Price(VersionId);
        }
        
        public string GetHnxIndexChart() {
            return base.Channel.GetHnxIndexChart();
        }
        
        public string GetHnxPTInit() {
            return base.Channel.GetHnxPTInit();
        }
        
        public string GetHnxPTMatch(long VersionId) {
            return base.Channel.GetHnxPTMatch(VersionId);
        }
        
        public string GetHnxPTBid(long VersionId) {
            return base.Channel.GetHnxPTBid(VersionId);
        }
        
        public string GetHnxPTOffer(long VersionId) {
            return base.Channel.GetHnxPTOffer(VersionId);
        }
        
        public string GetHnx30Index() {
            return base.Channel.GetHnx30Index();
        }
        
        public string GetHnx30StockList() {
            return base.Channel.GetHnx30StockList();
        }
        
        public string GetHnx30StockQuoteInit() {
            return base.Channel.GetHnx30StockQuoteInit();
        }
        
        public string GetHnx30StockQuote(long VersionId) {
            return base.Channel.GetHnx30StockQuote(VersionId);
        }
        
        public string GetHnx30Top3Price(long VersionId) {
            return base.Channel.GetHnx30Top3Price(VersionId);
        }
        
        public string GetMarketAllIndex(long VersionId) {
            return base.Channel.GetMarketAllIndex(VersionId);
        }
        
        public string GetUpcomIndex() {
            return base.Channel.GetUpcomIndex();
        }
        
        public string GetUpcomStockList() {
            return base.Channel.GetUpcomStockList();
        }
        
        public string GetUpcomStockQuoteInit() {
            return base.Channel.GetUpcomStockQuoteInit();
        }
        
        public string GetUpcomStockQuote(long VersionId) {
            return base.Channel.GetUpcomStockQuote(VersionId);
        }
        
        public string GetUpcomTop3Price(long VersionId) {
            return base.Channel.GetUpcomTop3Price(VersionId);
        }
        
        public string GetUpcomIndexChart() {
            return base.Channel.GetUpcomIndexChart();
        }
    }
}
