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
    public class ItemContext : iItem
    {
        private readonly DB data = new DB();

        public bool AddItem(ItemDTO item)
        {
            bool Success = false;
            using (SqlConnection conn = new SqlConnection(data.connection))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("AddItem", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Name", item.ProductName));
                    command.Parameters.Add(new SqlParameter("@Description", item.Description));
                    command.Parameters.Add(new SqlParameter("@VAT", item.VAT));
                    command.Parameters.Add(new SqlParameter("@Price", item.Price));
                    command.Parameters.Add(new SqlParameter("@Amount", item.Amount));
                    command.Parameters.Add(new SqlParameter("@InStock", item.InStock));

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

        public List<ItemDTO> GetItem()
        {
            List<ItemDTO> CollectedItems = new List<ItemDTO>();
            using (SqlConnection conn = new SqlConnection(data.connection))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("GetAllItem", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var item = new ItemDTO
                        {
                            ItemID = reader["ID"].ToString(),
                            ProductName = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                            VAT = (int)reader["VAT"],
                            Price = Convert.ToDecimal(reader["Price"]),
                            Amount = (int)reader["Amount"],
                            InStock = (bool)reader["InStock"]
                        };
                        CollectedItems.Add(item);
                    }
                    reader.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            return CollectedItems;
        }

        public ItemDTO GetItemByID(string id)
        {
            var item = new ItemDTO()
            {
                ItemID = id
            };
            using (SqlConnection conn = new SqlConnection(data.connection))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("GetItemByID", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", item.ItemID));

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        item.ProductName = reader["Name"].ToString();
                        item.Description = reader["Description"].ToString();
                        item.VAT = (int)reader["VAT"];
                        item.Price = (decimal)reader["Price"];
                        item.Amount = (int)reader["Amount"];
                        item.InStock = (bool)reader["InStock"];
                    }
                    reader.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            return item;
        }

        public bool RemoveItem(string id)
        {
            bool Success = false;
            using (SqlConnection conn = new SqlConnection(data.connection))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("RemoveItem", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", id));
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    { Success = true; }
                    reader.Close();
                }
                catch (Exception)
                { Success = false; }
                finally
                { conn.Close(); }
            }
            return Success;
        }

        public bool EditItem(ItemDTO item)
        {
            bool Success = false;
            using (SqlConnection conn = new SqlConnection(data.connection))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("SaveItem", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", item.ItemID));
                    command.Parameters.Add(new SqlParameter("@Name", item.ProductName));
                    command.Parameters.Add(new SqlParameter("@Description", item.Description));
                    command.Parameters.Add(new SqlParameter("@VAT", item.VAT));
                    command.Parameters.Add(new SqlParameter("@Price", item.Price));
                    command.Parameters.Add(new SqlParameter("@Amount", item.Amount));
                    command.Parameters.Add(new SqlParameter("@InStock", item.InStock));

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
    }
}
