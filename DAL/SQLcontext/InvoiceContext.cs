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
            using (SqlConnection conn = new SqlConnection(data.con.ConnectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("AddReference", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.Add(new SqlParameter("@CompanyName", reference.CompanyName));

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

        public bool EditInvoice(InvoiceDTO invoice)
        {
            bool Success = false;
            using (SqlConnection conn = new SqlConnection(data.con.ConnectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("EditReference", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.Add(new SqlParameter("@CompanyName", reference.ID));

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
            using (SqlConnection conn = new SqlConnection(data.con.ConnectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("GetAllReferences", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var invoice = new InvoiceDTO
                        {
                            //ID = reader["ID"].ToString(),
                            //CompanyName = reader["CompanyName"].ToString(),
                            //ContactName = reader["ContactName"].ToString(),
                            //Address = reader["Address"].ToString(),
                            //Zipcode = reader["Zipcode"].ToString(),
                            //Place = reader["Place"].ToString(),
                            //Country = reader["Country"].ToString(),
                            //PhoneNumber = reader["PhoneNumber"].ToString(),
                            //Email = reader["Email"].ToString(),
                            //Bank = reader["Bank"].ToString(),
                            //BIC = reader["BIC"].ToString(),
                            //IBAN = reader["IBAN"].ToString(),
                            //KvK = reader["KvK"].ToString(),
                            //VAT = reader["VAT"].ToString(),
                            //Doubtfull = (bool)reader["Doubtfull"],
                            //Date = (DateTime)reader["Date"],
                            //Note = reader["Note"].ToString()
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
            using (SqlConnection conn = new SqlConnection(data.con.ConnectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("GetReferenceByID", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", id));

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        //reference.CompanyName = reader["CompanyName"].ToString();
                        //reference.ContactName = reader["ContactName"].ToString();
                        //reference.Address = reader["Address"].ToString();
                        //reference.Zipcode = reader["Zipcode"].ToString();
                        //reference.Place = reader["Place"].ToString();
                        //reference.Country = reader["Country"].ToString();
                        //reference.PhoneNumber = reader["PhoneNumber"].ToString();
                        //reference.Email = reader["Email"].ToString();
                        //reference.Bank = reader["Bank"].ToString();
                        //reference.BIC = reader["BIC"].ToString();
                        //reference.IBAN = reader["IBAN"].ToString();
                        //reference.KvK = reader["KvK"].ToString();
                        //reference.VAT = reader["VAT"].ToString();
                        //reference.Doubtfull = (bool)reader["Doubtfull"];
                        //reference.Date = (DateTime)reader["Date"];
                        //reference.Note = reader["Note"].ToString();
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
            using (SqlConnection conn = new SqlConnection(data.con.ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("RemoveReference", conn);
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
    }
}
