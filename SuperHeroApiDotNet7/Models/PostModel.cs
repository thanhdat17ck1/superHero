using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using SuperHeroApiDotNet7.Entity.Blog;
using SuperHeroApiDotNet7.Entity.User;
using SuperHeroApiDotNet7.Libs;
using System;
using System.Data;
using System.Text.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SuperHeroApiDotNet7.Models
{
    public class PostModel
    {
        private readonly DataContext _context;
        public PostModel(DataContext context)
        {
            _context = context;
        }
        public bool SavePost(PostEntity post)
        {
            List<PostEntity> lst = new List<PostEntity> { post };
            string json = JsonConvert.SerializeObject(lst);
            DataTable tbl = JsonConvert.DeserializeObject<DataTable>(json);
            SqlConnection conn = SqlHelper.GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                SqlCommand cmd = new SqlCommand("sp_QL_Post", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Post");
                cmd.Parameters.AddWithValue("@Para1", "");
                cmd.Parameters.AddWithValue("@TypeTable", tbl);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
