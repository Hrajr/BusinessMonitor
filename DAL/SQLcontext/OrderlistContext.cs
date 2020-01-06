using DAL.DBconnection;
using DAL.Interface;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.SQLcontext
{
    public class OrderlistContext : iOrderlist
    {
        private readonly DB data = new DB();

        public bool AddOrderlist(string ID, string ItemID, int Amount, decimal Price)
        {
            bool Success = false;
            using (SqlConnection conn = new SqlConnection(data.connection))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("CreateOrderlist", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", ID));
                    command.Parameters.Add(new SqlParameter("@ItemID", ItemID));
                    command.Parameters.Add(new SqlParameter("@Amount", Amount));
                    command.Parameters.Add(new SqlParameter("@Price", Price));

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Success = true;
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    Success = false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return Success;
        }

        public OrderlistDTO GetOrderByID(string ID)
        {
            OrderlistDTO Order = new OrderlistDTO();
            using (SqlConnection conn = new SqlConnection(data.connection))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("GetOrder", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", ID));

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var item = new ItemDTO
                        {
                            ItemID = reader["ItemID"].ToString(),
                            Price = Convert.ToDecimal(reader["Price"].ToString()),
                            Amount = (int)reader["Amount"]
                        };
                        Order.OrderItem.Add(item);
                        Order.OrderID = ID;
                    }
                    reader.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            return Order;
        }

        public bool RemoveOrder(string ID)
        {
            bool Success = false;
            using (SqlConnection conn = new SqlConnection(data.connection))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("DeleteOrder", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", ID));

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Success = true;
                    }
                    reader.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            return Success;
        }

        public bool RemoveItemFromOrder(string ID, string ItemID)
        {
            bool Success = false;
            using (SqlConnection conn = new SqlConnection(data.connection))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("RemoveItemFromOrder", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", ID));
                    command.Parameters.Add(new SqlParameter("@ItemID", ItemID));

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Success = true;
                    }
                    reader.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            return Success;
        }
    }
}
