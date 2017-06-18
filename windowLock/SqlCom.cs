using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windowLock
{
    public class SqlCom
    {
        static string sqlcon = "server=.;database=;Integrated Security=true;";
        static string keyName = "windowLock.Properties.Settings.LockDBConnectionString";
        ///<summary>
        ///依据连接串名字connectionName返回数据连接字符串
        ///</summary>
        ///<param ></param>
        ///<returns></returns>
        private static void GetConnectionStringsConfig()
        {
            string connectionName = keyName;
            string connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString.ToString();
            sqlcon = connectionString;
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        public static bool Add(string sqlString)
        {
            GetConnectionStringsConfig();
            //string sqlcon = "server=.;database=;Integrated Security=true;";
            SqlConnection conn = new SqlConnection(sqlcon);
            string sqlStr = sqlString;
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public static bool Delete(string sqlString)
        {
            GetConnectionStringsConfig();
            SqlConnection conn = new SqlConnection(sqlcon);
            string sqlStr = sqlString;
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 数据更新，软删除
        /// </summary>
        private static bool Update(string sqlString)
        {
            GetConnectionStringsConfig();
            SqlConnection conn = new SqlConnection(sqlcon);
            string sqlStr = sqlString;
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 读取单个值
        /// </summary>
        public static string selectSingle(string sqlString)
        {
            GetConnectionStringsConfig();
            try
            {
                SqlConnection conn = new SqlConnection(sqlcon);
                string sqlStr = sqlString;
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                conn.Open();
                object obj = cmd.ExecuteScalar();
                conn.Close();
                return obj==null?null:obj.ToString();
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// dateReader读取数据，逐行读取，通过下表访问列
        /// </summary>
        private static void dateReader()
        {
            GetConnectionStringsConfig();
            SqlConnection conn = new SqlConnection(sqlcon);
            string sqlStr = "select * from Book";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())//如果读到下一行数据就返回True，且本身就属于那一行数据
                {
                    Console.Write(dr[0].ToString() + '_' + dr[1].ToString() + '_' + dr["ID"].ToString());
                }
            }
            else
            {
                Console.Write("无数据");
            }
            dr.Close();
            conn.Close();
        }

        //使用适配器填充数据集  SqlDataAdapter不需要手动开关，它能够自己开关
        public static DataTable QueryList(string sqlString)
        {
            try
            {
                GetConnectionStringsConfig();
                SqlConnection con = new SqlConnection(sqlcon);
                string sqlStr = sqlString;
                SqlDataAdapter da = new SqlDataAdapter(sqlStr, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //使用适配器填充数据集  SqlDataAdapter不需要手动开关，它能够自己开关
        public static void QueryListAdapter2()
        {
            GetConnectionStringsConfig();
            SqlConnection con = new SqlConnection(sqlcon);
            string sqlStr = "select*from book";
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            //循环数据表中的每一行
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];//将表中的一行拿出来给行对象
                Console.WriteLine(dr[0].ToString() + "_" + dr["ID"].ToString());
            }
        }
        //调用存储过程查询数据
        public static void QuerListByProc(string Pro)
        {
            GetConnectionStringsConfig();
            SqlConnection conn = new SqlConnection(sqlcon);
            SqlCommand cmd = new SqlCommand("usp_GetBookMyCateId", conn);
            //无参数的存储过程
            SqlParameter sp2 = new SqlParameter();
            sp2.ParameterName = "@cateId";
            sp2.SqlDbType = SqlDbType.Int;
            sp2.Value = 2;
            cmd.Parameters.Add(sp2);
            //有两个参数的存储过程
            SqlParameter sp = new SqlParameter("@cateId", 2);
            cmd.Parameters.Add(sp);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr[0].ToString() + "_" + dr["ID"].ToString());
            }
        }
        //调用多个参数的存储过程查询
        private static void QueryListByProc2()
        {
            GetConnectionStringsConfig();
            SqlConnection conn = new SqlConnection(sqlcon);
            SqlCommand cmd = new SqlCommand("proGetPageData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //尽量不要使用两个参数的存储过程，类型是枚举类型，另外一个两个参数的函数值混淆
            //SqlParameter par = new SqlParameter("@Id", DbType.Int32);
            //SqlParameter par = new SqlParameter("@id", 11);
            //赋值多个参数
            SqlParameter[] paras ={
                             new SqlParameter("@pageIndex",SqlDbType.Int,4),//这里的4是代表整型的长度
                             new SqlParameter("@pageSize",SqlDbType.Int,4)
                         };
            //cmd.Parameters.AddRange(paras);
            paras[0].Value = 1;//搜索第一页
            paras[1].Value = 2;//赋值的
            cmd.Parameters.AddRange(paras);//为command对象添加pameters数组
            conn.Open();
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    Console.Write("id=" + dr[0].ToString());
            //}
            //dr.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr[0].ToString() + "_" + dr[1].ToString());
            }
            conn.Close();
        }


        //调用带输出参数的存数过程
        private static void QuerListProc3()
        {
            GetConnectionStringsConfig();
            SqlConnection conn = new SqlConnection(sqlcon);
            SqlCommand cmd = new SqlCommand("proGetData2", conn);
            SqlParameter[] paras ={
                             new SqlParameter("@pageIndex",SqlDbType.Int),
                             new SqlParameter("@pageSize",SqlDbType.Int),
                             new SqlParameter("@pageCount",SqlDbType.Int),
                             new SqlParameter("@rowCount",SqlDbType.Int)
                         };
            paras[0].Value = 1;
            paras[1].Value = 2;
            paras[2].Direction = ParameterDirection.Output;
            paras[3].Direction = ParameterDirection.Output;//设置参数的输出方向
            cmd.Parameters.AddRange(paras);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr[0].ToString() + "_" + dr[1].ToString());
            }
            int pageCount = Convert.ToInt32(cmd.Parameters[2].Value);
            int rowCount = Convert.ToInt32(cmd.Parameters[3].Value);//获取输出参数
            Console.WriteLine("pageCount=" + pageCount + ",rowCount=" + rowCount);
        }

    }
}
