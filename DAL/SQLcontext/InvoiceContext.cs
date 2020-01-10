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
    public class InvoiceContext : iInvoice
    {
        private readonly DB data = new DB();

        public bool AddInvoice(InvoiceDTO invoice)
        {
            bool Success = false;
            using (SqlConnection conn = new SqlConnection(data.connection))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("CreateInvoice", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", invoice.InvoiceNumber));
                    command.Parameters.Add(new SqlParameter("@Type", invoice.TypeOfInvoice));
                    command.Parameters.Add(new SqlParameter("@Reference", invoice.InvoiceReference.ID));
                    command.Parameters.Add(new SqlParameter("@InvoiceDate", invoice.InvoiceDate));
                    command.Parameters.Add(new SqlParameter("@PaymentDate", invoice.PaymentDate));
                    command.Parameters.Add(new SqlParameter("@UserID", invoice.InvoiceUser.UserID));
                    command.Parameters.Add(new SqlParameter("@PaymentStatus", invoice.PaymentStatus));

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

        public bool EditInvoice(string oldID, InvoiceDTO invoice)
        {
            bool Success = false;
            using (SqlConnection conn = new SqlConnection(data.connection))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("EditInvoice", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@oldID", oldID));
                    command.Parameters.Add(new SqlParameter("@ID", invoice.InvoiceNumber));
                    command.Parameters.Add(new SqlParameter("@Type", invoice.TypeOfInvoice));
                    command.Parameters.Add(new SqlParameter("@Reference", invoice.InvoiceReference.ID));
                    command.Parameters.Add(new SqlParameter("@Orderlist", invoice.InvoiceOrder.OrderID));
                    command.Parameters.Add(new SqlParameter("@InvoiceDate", invoice.InvoiceDate));
                    command.Parameters.Add(new SqlParameter("@PaymentDate", invoice.PaymentDate));
                    command.Parameters.Add(new SqlParameter("@UserID", invoice.InvoiceUser.UserID));
                    command.Parameters.Add(new SqlParameter("@PaymentStatus", invoice.PaymentStatus));

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

        public List<InvoiceDTO> GetInvoice()
        {
            List<InvoiceDTO> CollectedReferences = new List<InvoiceDTO>();
            using (SqlConnection conn = new SqlConnection(data.connection))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("GetAllInvoice", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var invoice = new InvoiceDTO
                        {
                            InvoiceNumber = reader["ID"].ToString(),
                            TypeOfInvoice = (Invoicetype)System.Enum.Parse(typeof(Invoicetype), reader["Type"].ToString()),
                            InvoiceReference = new ReferenceDTO() { ID = reader["Reference"].ToString() },
                            InvoiceOrder = new OrderlistDTO() { OrderID = reader["Orderlist"].ToString() },
                            InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString()),
                            PaymentDate = Convert.ToDateTime(reader["PaymentDate"].ToString()),
                            InvoiceUser = new UserDTO() { UserID = reader["UserID"].ToString() },
                            PaymentStatus = (bool)reader["PaymentStatus"],
                        };
                        CollectedReferences.Add(invoice);
                    }
                    reader.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            return CollectedReferences;
        }

        public InvoiceDTO GetInvoiceByID(string id)
        {
            var invoice = new InvoiceDTO();
            using (SqlConnection conn = new SqlConnection(data.connection))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("GetInvoiceByID", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", id));

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        invoice.InvoiceNumber = reader["ID"].ToString();
                        invoice.TypeOfInvoice = (Invoicetype)System.Enum.Parse(typeof(Invoicetype), reader["Type"].ToString());
                        invoice.InvoiceReference = new ReferenceDTO() { ID = reader["Reference"].ToString() };
                        invoice.InvoiceOrder = new OrderlistDTO() { OrderID = reader["Orderlist"].ToString() };
                        invoice.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                        invoice.PaymentDate = Convert.ToDateTime(reader["PaymentDate"].ToString());
                        invoice.InvoiceUser = new UserDTO() { UserID = reader["UserID"].ToString() };
                        invoice.PaymentStatus = (bool)reader["PaymentStatus"];
                    }
                    reader.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            return invoice;
        }

        public bool RemoveInvoice(string id)
        {
            bool Success = false;
            using (SqlConnection conn = new SqlConnection(data.connection))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("RemoveInvoice", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", id));
                    var reader = command.ExecuteReader();
                    reader.Read();
                    Success = true;
                    reader.Close();
                }
                catch (Exception)
                { Success = false; }
                finally
                { conn.Close(); }
            }
            return Success;
        }

        public bool CheckExistingInvoice(string id)
        {
            bool Success = false;
            using (SqlConnection conn = new SqlConnection(data.connection))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("GetInvoiceByID", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", id));
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Success = true;
                    }
                    reader.Close();
                }
                catch (Exception)
                { Success = false; }
                finally
                { conn.Close(); }
            }
            return Success;
        }
    }
}
