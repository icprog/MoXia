using System;
using System . Configuration;
using System . IO;
using StudentMgr;

namespace BackSqlServer
{
    public class DbBackup
    {
        static string path =string.Empty,filePath=string.Empty;
        public static string Backuping ( string dbName )
        {
            try
            {
                if ( dbName == null || dbName . Length == 0 )
                    return dbName + " msg = false, error = 输入的数据库不存在！";
                path = ConfigurationManager . ConnectionStrings [ "DbBackPath" ] . ConnectionString + dbName;
                //path = Server.MapPath(path);路径只能是服务器上的

                //如果路径不存在就创建文件夹
                if ( !Directory . Exists ( path ) )
                {
                    Directory . CreateDirectory ( path );
                }

                //判断文件是否已存在
                filePath = path + "\\" + dbName + "_" + DateTime . Now . ToString ( "yyyyMMddfffHHmmss" ) + ".bak'";
                //if ( System . IO . File . Exists ( filePath ) )
                //{
                //    System . IO . File . Delete ( filePath );
                //}
                //string str = ConfigurationManager . ConnectionStrings [ dbName ] . ToString ( );
                string strBak = "backup database " + dbName + " to disk='" + filePath;
                if ( SqlHelper . ExecuteNonQuery ( strBak ) == 0 )
                    return dbName + "succeed = false, error = 备份数据库失败！";
                else
                    return dbName + " succeed = true, filePath = filePath, error = 备份数据库成功！";
            }
            catch ( Exception ex )
            {
                return dbName + " " + path + "  " + filePath + " " + "succeed = false, error = 备份数据库失败！" + ex . Message + "\r\n" + ex . StackTrace;
            }
        }
    }
}
