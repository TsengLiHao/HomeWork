using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNote.DBSource
{
    public class UserInfoManager
    {
        public static DataRow GetUserInfoByAccount(string account)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                @" SELECT [UID], [ID], [Account], [PWD], [Name], [Email], [CreateDate], [UserLevel]
                    FROM UserInfo
                    WHERE [Account] = @account
                ";


            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", account));

            try
            {
                return DBHelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        public static DataTable GetUserInfoList(string id)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT
                        UID,
                        ID,
                        Account,
                        Name,
                        Email,
                        CreateDate, 
                        UserLevel
                    FROM UserInfo
                    WHERE ID = @id
                    ORDER BY CreateDate DESC
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", id));

            try
            {
                return DBHelper.ReadDataTable(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        public static DataRow GetUser(int uid, string id)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@"SELECT 
                        UID,
                        Name,
                        Account,
                        PWD,
                        Email,
                        UserLevel,
                        CreateDate
                    FROM UserInfo
                    WHERE UID = @uid AND ID = @id
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@uid", uid));
            list.Add(new SqlParameter("@id", id));

            try
            {
                return DBHelper.ReadDataRow(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }


        public static void CreateUser(string id, string account,int pwd ,string name, string email, string userlevel)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" INSERT INTO UserInfo
                    (
                        ID
                        ,Account
                        ,PWD
                        ,[Name]
                        ,Email
                        ,UserLevel
                        ,CreateDate
                    )
                    VALUES
                    (
                        @id
                        ,@account
                        ,@pwd
                        ,@name
                        ,@email
                        ,@userlevel
                        ,@createdate
                    ) ";


            // connect db & execute
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddWithValue("@id",id);
                    comm.Parameters.AddWithValue("@account", account);
                    comm.Parameters.AddWithValue("@pwd", pwd);
                    comm.Parameters.AddWithValue("@name", name);
                    comm.Parameters.AddWithValue("@email", email);
                    comm.Parameters.AddWithValue("@userlevel", userlevel);
                    comm.Parameters.AddWithValue("@createdate", DateTime.Now);


                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex);
                    }
                }
            }
        }

        public static bool UpdateUserInfo(int uid, string id, string name, string account, string email , string userlevel)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" UPDATE [UserInfo]
                    SET
                         ID         = @id
                        ,[Name]       = @name
                        ,Account    = @account
                        ,Email      = @email
                        ,UserLevel  = @userlevel
                        ,CreateDate = @createDate
                          
                    WHERE 
                        UID = @uid ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@id", id));
            paramList.Add(new SqlParameter("@name", name));
            paramList.Add(new SqlParameter("@account", account));
            paramList.Add(new SqlParameter("@email", email));
            paramList.Add(new SqlParameter("@userlevel", userlevel));
            paramList.Add(new SqlParameter("@createDate", DateTime.Now));
            paramList.Add(new SqlParameter("@uid", uid));


            try
            {
                int effectRows = DBHelper.ModifyData(connStr, dbCommand, paramList);

                if (effectRows == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }

        public static void DeleteUser(int uid)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" DELETE [UserInfo]
                    WHERE UID = @uid ";


            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@uid", uid));


            try
            {
                DBHelper.ModifyData(connStr, dbCommand, paramList);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }

        public static bool UpdateUserPWD(int uid, string pwd)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" UPDATE [UserInfo]
                    SET
                        PWD = @pwd
                          
                    WHERE 
                        UID = @uid ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@pwd", pwd));
            paramList.Add(new SqlParameter("@uid", uid));


            try
            {
                int effectRows = DBHelper.ModifyData(connStr, dbCommand, paramList);

                if (effectRows == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }

        public static DataRow GetValueOfMember()
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT COUNT 
                        (UID) AS UID
                    FROM UserInfo
                    
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            

            try
            {
                return DBHelper.ReadDataRow(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }
    }

   
}
