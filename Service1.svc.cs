using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace Product_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString);


        // Insert data

        public string InsertProductDetails(ProductDetails ProductInfo)
        {
            string Message;
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SAVE_PRODUCT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ItemImagePath1", ProductInfo.ItemImagePath1);
            cmd.Parameters.AddWithValue("@ItemImagePath2", ProductInfo.ItemImagePath2);
            cmd.Parameters.AddWithValue("@ItemImagePath3", ProductInfo.ItemImagePath3);
            cmd.Parameters.AddWithValue("@ItemImagePath4", ProductInfo.ItemImagePath4);
            cmd.Parameters.AddWithValue("@ItemImagePath5", ProductInfo.ItemImagePath5);
            cmd.Parameters.AddWithValue("@ItemVideoPath", ProductInfo.ItemVideoPath);
            cmd.Parameters.AddWithValue("@ItemTitle", ProductInfo.ItemTitle);
            cmd.Parameters.AddWithValue("@ItemDescription", ProductInfo.ItemDescription);
            cmd.Parameters.AddWithValue("@ItemSpecification", ProductInfo.ItemSpecification);
            cmd.Parameters.AddWithValue("@ItemPrice", ProductInfo.ItemPrice);
            cmd.Parameters.AddWithValue("@ItemDiscount", ProductInfo.ItemDiscount);
            cmd.Parameters.AddWithValue("@ItemId", ProductInfo.ItemId);
            cmd.Parameters.AddWithValue("@ItemType", ProductInfo.ItemType);
            cmd.Parameters.AddWithValue("@ItemQuantity", ProductInfo.ItemQuantity);
            int result = cmd.ExecuteNonQuery();  
            if (result == 1)
            {


                Message = "Details inserted successfully";
            }
            else
            {
                Message = "Details are not inserted successfully";
            }
            con.Close();
            return Message;
        }



        // Update Data
        public string UpdateProductDetails(ProductDetails ProductInfo)
        {
            string Message;
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_UPDATE_PRODUCT", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ItemImagePath1", ProductInfo.ItemImagePath1);
            cmd.Parameters.AddWithValue("@ItemImagePath2", ProductInfo.ItemImagePath2);
            cmd.Parameters.AddWithValue("@ItemImagePath3", ProductInfo.ItemImagePath3);
            cmd.Parameters.AddWithValue("@ItemImagePath4", ProductInfo.ItemImagePath4);
            cmd.Parameters.AddWithValue("@ItemImagePath5", ProductInfo.ItemImagePath5);
            cmd.Parameters.AddWithValue("@ItemVideoPath", ProductInfo.ItemVideoPath);
            cmd.Parameters.AddWithValue("@ItemTitle", ProductInfo.ItemTitle);
            cmd.Parameters.AddWithValue("@ItemDescription", ProductInfo.ItemDescription);
            cmd.Parameters.AddWithValue("@ItemSpecification", ProductInfo.ItemSpecification);
            cmd.Parameters.AddWithValue("@ItemPrice", ProductInfo.ItemPrice);
            cmd.Parameters.AddWithValue("@ItemDiscount", ProductInfo.ItemDiscount);
            cmd.Parameters.AddWithValue("@ItemID", ProductInfo.ItemId);
            cmd.Parameters.AddWithValue("@ItemType", ProductInfo.ItemDiscount);
            cmd.Parameters.AddWithValue("@ItemQuantity", ProductInfo.ItemQuantity);
            try
            {
                int result = cmd.ExecuteNonQuery();

                if (result == 1)
                {
                    Message = "Details Updated successfully";
                    return Message;
                }

                else
                {
                    Message = "Details are not Updated successfully";
                }
            }
            catch (Exception ex)
            {
                con.Close();
                return "Message"
                    + ex.Message;
            }
            return Message;


        }

        // Delete Data

        public string DeleteProductDetails(string ItemId)
        {
            string Message2;
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_DELETE_PRODUCT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ItemId", ItemId);

            /* cmd.Parameters.AddWithValue("@ItemId", ProductInfo.ItemId);
            cmd.Parameters.AddWithValue("@ItemImagePath1", ProductInfo.ItemImagePath1);
            cmd.Parameters.AddWithValue("@ItemImagePath2", ProductInfo.ItemImagePath2);
            cmd.Parameters.AddWithValue("@ItemImagePath3", ProductInfo.ItemImagePath3);
            cmd.Parameters.AddWithValue("@ItemImagePath4", ProductInfo.ItemImagePath4);
            cmd.Parameters.AddWithValue("@ItemImagePath5", ProductInfo.ItemImagePath5);
            cmd.Parameters.AddWithValue("@ItemVideoPath", ProductInfo.ItemVideoPath);
            cmd.Parameters.AddWithValue("@ItemDiscount", ProductInfo.ItemDiscount);*/ 
            try
            {
                int res = cmd.ExecuteNonQuery();

                if (res == 1)
                {
                    Message2 = " Delete data successfully";
                    return Message2;

                }
                else
                {
                    Message2 = " Delete data are not Successfully";
                }
            }
            catch (Exception ex)
            {
                con.Close();
                return "Message"
                  + ex.Message;
            }
            return Message2;
        }

        // Get Data

        public ProductDetails GetProductDetails(string ItemId)
        {
            ProductDetails productInfo = new ProductDetails();
            SqlCommand cmd = new SqlCommand("SP_GET_PRODUCT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Itemid";
            parameter.Value = ItemId;
            cmd.Parameters.Add(parameter);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productInfo.ItemImagePath1 = reader["ItemImagePath1"].ToString();
                        productInfo.ItemImagePath2 = reader["ItemImagePath2"].ToString();
                        productInfo.ItemImagePath3 = reader["ItemImagePath3"].ToString();
                        productInfo.ItemImagePath4 = reader["ItemImagePath4"].ToString();
                        productInfo.ItemImagePath5 = reader["ItemImagePath5"].ToString();
                        productInfo.ItemVideoPath = reader["ItemVideoPath"].ToString();
                        productInfo.ItemTitle = reader["ItemTitle"].ToString();
                        productInfo.ItemDescription = reader["ItemDescription"].ToString();
                        productInfo.ItemSpecification = reader["ItemSpecification"].ToString();
                        productInfo.ItemPrice = Convert.ToDouble(reader["ItemPrice"]);
                        productInfo.ItemDiscount = Convert.ToDouble(reader["ItemDiscount"]);
                        productInfo.ItemId = Convert.ToInt32(reader["ItemId"]);
                        productInfo.ItemType = Convert.ToInt32(reader["ItemType"]);
                        productInfo.ItemQuantity = Convert.ToInt32(reader["ItemQuantity"]);

                    }
                    return productInfo;
                }

                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;

            }
            finally
            {

                con.Close();

            }


        }


    }
}