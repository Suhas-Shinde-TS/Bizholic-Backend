using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace Product_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/ProductDetails", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string InsertProductDetails(ProductDetails ProductInfo);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            UriTemplate = "/ProductDetails", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string UpdateProductDetails(ProductDetails ProductInfo);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            UriTemplate = "/ProductDetails/{ItemId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string DeleteProductDetails(string ItemId);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate ="/GetProduct/{ItemId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ProductDetails GetProductDetails(string ItemId);

    }

    public class ProductDetails

    {
        string itemimagepath1;
        string itemimagepath2;
        string itemimagepath3;
        string itemimagepath4;
        string itemimagepath5;
        string itemvideopath;
        string itemtitle;
        string itemdescription;
        string itemshecification;
        double itemprice;
        double itemdiscount;
        int itemid;
        int itemtype;
        int itemquantity;

        [DataMember]
        public string ItemImagePath1 { get; set; }
        [DataMember]
        public string ItemImagePath2 { get; set; }
        [DataMember]
        public string ItemImagePath3 { get; set; }
        [DataMember]
        public string ItemImagePath4 { get; set; }
        [DataMember]
        public string ItemImagePath5 { get; set; }
        [DataMember]
        public string ItemVideoPath { get; set; }
        [DataMember]
        public string ItemTitle { get; set; }
        [DataMember]
        public string ItemDescription { get; set; }
        [DataMember]
        public string ItemSpecification { get; set; }
        [DataMember]
        public double ItemPrice { get; set; }
        [DataMember]
        public double ItemDiscount { get; set; }
        [DataMember]
        public int ItemId { get; set; }
        [DataMember]
        public int ItemType { get; set; }
        [DataMember]
        public int ItemQuantity { get; set; }


    }
}