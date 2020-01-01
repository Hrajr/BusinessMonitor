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
    public class ReferenceContext : iReference
    {
        private readonly DB data = new DB();

        public bool AddReference(ReferenceDTO reference)
        {
            bool Success = false;
            using (SqlConnection conn = new SqlConnection(data.connection))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("AddReference", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@CompanyName", reference.CompanyName));
                    command.Parameters.Add(new SqlParameter("@ContactName", reference.ContactName));
                    command.Parameters.Add(new SqlParameter("@Address", reference.Address));
                    command.Parameters.Add(new SqlParameter("@Zipcode", reference.Zipcode));
                    command.Parameters.Add(new SqlParameter("@Place", reference.Place));
                    command.Parameters.Add(new SqlParameter("@Country", reference.Country));
                    command.Parameters.Add(new SqlParameter("@PhoneNumber", reference.PhoneNumber));
                    command.Parameters.Add(new SqlParameter("@Email", reference.Email));
                    command.Parameters.Add(new SqlParameter("@Bank", reference.Bank));
                    command.Parameters.Add(new SqlParameter("@BIC", reference.BIC));
                    command.Parameters.Add(new SqlParameter("@IBAN", reference.IBAN));
                    command.Parameters.Add(new SqlParameter("@KvK", reference.KvK));
                    command.Parameters.Add(new SqlParameter("@VAT", reference.VAT));
                    command.Parameters.Add(new SqlParameter("@Doubtfull", reference.Doubtfull));
                    command.Parameters.Add(new SqlParameter("@Date", reference.Date));
                    command.Parameters.Add(new SqlParameter("@Note", reference.Note));

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

        public bool EditReference(ReferenceDTO reference)
        {
            bool Success = false;
            using (SqlConnection conn = new SqlConnection(data.connection))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("EditReference", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@CompanyName", reference.ID));
                    command.Parameters.Add(new SqlParameter("@CompanyName", reference.CompanyName));
                    command.Parameters.Add(new SqlParameter("@ContactName", reference.ContactName));
                    command.Parameters.Add(new SqlParameter("@Address", reference.Address));
                    command.Parameters.Add(new SqlParameter("@Zipcode", reference.Zipcode));
                    command.Parameters.Add(new SqlParameter("@Place", reference.Place));
                    command.Parameters.Add(new SqlParameter("@Country", reference.Country));
                    command.Parameters.Add(new SqlParameter("@PhoneNumber", reference.PhoneNumber));
                    command.Parameters.Add(new SqlParameter("@Email", reference.Email));
                    command.Parameters.Add(new SqlParameter("@Bank", reference.Bank));
                    command.Parameters.Add(new SqlParameter("@BIC", reference.BIC));
                    command.Parameters.Add(new SqlParameter("@IBAN", reference.IBAN));
                    command.Parameters.Add(new SqlParameter("@KvK", reference.KvK));
                    command.Parameters.Add(new SqlParameter("@VAT", reference.VAT));
                    command.Parameters.Add(new SqlParameter("@Doubtfull", reference.Doubtfull));
                    command.Parameters.Add(new SqlParameter("@Date", reference.Date));
                    command.Parameters.Add(new SqlParameter("@Note", reference.Note));

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

        public List<ReferenceDTO> GetReference()
        {
            List<ReferenceDTO> CollectedReferences = new List<ReferenceDTO>();
            using (SqlConnection conn = new SqlConnection(data.connection))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("GetAllReferences", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var reference = new ReferenceDTO
                        {
                            ID = reader["ID"].ToString(),
                            CompanyName = reader["CompanyName"].ToString(),
                            ContactName = reader["ContactName"].ToString(),
                            Address = reader["Address"].ToString(),
                            Zipcode = reader["Zipcode"].ToString(),
                            Place = reader["Place"].ToString(),
                            Country = reader["Country"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            Bank = reader["Bank"].ToString(),
                            BIC = reader["BIC"].ToString(),
                            IBAN = reader["IBAN"].ToString(),
                            KvK = reader["KvK"].ToString(),
                            VAT = reader["VAT"].ToString(),
                            Doubtfull = (bool)reader["Doubtfull"],
                            Date = (DateTime)reader["Date"],
                            Note = reader["Note"].ToString()
                        };
                        CollectedReferences.Add(reference);
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

        public ReferenceDTO GetReferenceByID(string id)
        {
            var reference = new ReferenceDTO();
            using (SqlConnection conn = new SqlConnection(data.connection))
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
                        reference.CompanyName = reader["CompanyName"].ToString();
                        reference.ContactName = reader["ContactName"].ToString();
                        reference.Address = reader["Address"].ToString();
                        reference.Zipcode = reader["Zipcode"].ToString();
                        reference.Place = reader["Place"].ToString();
                        reference.Country = reader["Country"].ToString();
                        reference.PhoneNumber = reader["PhoneNumber"].ToString();
                        reference.Email = reader["Email"].ToString();
                        reference.Bank = reader["Bank"].ToString();
                        reference.BIC = reader["BIC"].ToString();
                        reference.IBAN = reader["IBAN"].ToString();
                        reference.KvK = reader["KvK"].ToString();
                        reference.VAT = reader["VAT"].ToString();
                        reference.Doubtfull = (bool)reader["Doubtfull"];
                        reference.Date = (DateTime)reader["Date"];
                        reference.Note = reader["Note"].ToString();
                    }
                    reader.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            return reference;
        }

        public bool RemoveReference(string id)
        {
            bool Success = false;
            using (SqlConnection conn = new SqlConnection(data.connection))
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
