using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace TopicManagement
{
    public class Database
    {
        //Phan xu li ket noi sql
        public const String REGEX = ";;;";
        private static SqlConnection connection;
        public static string lecturerid;

        public static bool connect(String url)
        {
            try
            {
                connection = new SqlConnection(url);
                connection.Open();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public static bool disconnect()
        {
            try
            {
                connection.Close();
                connection.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Trả về giá trị 1 cột trong database
        public static List<String> getSingelData(string sql, string type)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                cmd.Dispose();
                List<String> list = new List<string>();
                while (dr.Read())
                {
                    if (type == "string")
                        list.Add(dr.GetString(0));
                    if (type == "int")
                        list.Add(dr.GetInt32(0).ToString());
                    if (type == "date")
                        list.Add(dr.GetDateTime(0).Date.ToShortDateString());
                    if (type == "float")
                        list.Add(dr.GetDouble(0).ToString());
                    if (type == "bool")
                        list.Add(dr.GetBoolean(0).ToString());
                }
                dr.Close();
                return list;
            }
            catch {
                return null;
            }
        }

        public static bool updateData(String sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connection);
            try
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch
            {
                cmd.Dispose();
                return false;
            }
        }

        public static DataTable fillDataToTable(String sql)
        {
            try
            {
                SqlDataAdapter data = new SqlDataAdapter(sql, connection);
                DataTable table = new DataTable();
                data.Fill(table);
                return table;
            }
            catch {
                return null;
            }
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
