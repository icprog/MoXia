using AutoUpdate;
using DevExpress . XtraEditors;
using System;
using System . Windows . Forms;

namespace Carpenter
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main ( )
        {
            DevExpress . Skins . SkinManager . EnableFormSkins ( );

            Application . SetUnhandledExceptionMode ( UnhandledExceptionMode . CatchException );
            //添加非UI上的异常.
            AppDomain . CurrentDomain . UnhandledException += new UnhandledExceptionEventHandler ( CurrentDomain_UnhandledException );

            Application . EnableVisualStyles ( );
            Application . SetCompatibleTextRenderingDefault ( false );

            FastReport . Utils . Res . LoadLocale ( Application . StartupPath + "\\Chinese (Simplified).frl" );

            try
            {
                //是否有注册信息
                //Register . SoftReg sr = new Register . SoftReg ( );
                //if ( sr . registerYesOrNo ( ) == false )
                //{
                //    //弹出注册窗体
                //    Register . FormRegister from = new Register . FormRegister ( );
                //    if ( from . ShowDialog ( ) == DialogResult . OK )
                //    {
                //        startFromMain ( );
                //    }
                //}
                //else
                startFromMain ( );
            }
            catch ( Exception ex )
            {
                XtraMessageBox . Show ( "请检查网络是否正常" );
                Utility . LogHelper . WriteLog ( ex . StackTrace );
            }
        }

        private static void CurrentDomain_UnhandledException ( object sender ,UnhandledExceptionEventArgs e )
        {
            try
            {
                Exception ex = ( Exception ) e . ExceptionObject;

                Utility . LogHelper . WriteLog ( ex . Message + "\n\nStack Trace:\n" + ex . StackTrace );
            }
            catch ( Exception exc )
            {
                try
                {
                    XtraMessageBox . Show ( " Error" ,
                        " Could not write the error to the log. Reason: "
                        + exc . Message ,MessageBoxButtons . OK ,MessageBoxIcon . Stop );
                }
                finally
                {
                    Application . Exit ( );
                }
            }
        }

        static void startFromMain ( )
        {
            //E41F1

            //检查更新

            AppUpdate au = new AppUpdate ( );
            string msg = "";
            bool result = au . CheckAppVersion ( ref msg );

            if ( result == true )
                System . Diagnostics . Process . Start ( Application . StartupPath + @"\AutoUpdate.exe" );

            if ( CarpenterBll . Dao . EncryptQuery . getResult ( ) . Equals ( "E41F1" ,StringComparison . CurrentCultureIgnoreCase ) )

                //加载主窗体
                Application . Run ( new FormMajor ( ) );
        }

    }
}


/*
 WITH CET AS (
SELECT idx,PRD001,PRD004,PRD006,PRD003,PRD014,PRD015,PRD013 FROM MOXPRD WHERE PRD014=1 
) 
,CFT AS (
SELECT idx,PRD001,PRD004,PRD006,PRD003,PRD014,PRD015,PRD013 FROM MOXPRD WHERE PRD014=0
)
,CHT AS(
SELECT a.idx idaa,b.idx FROM CET A INNER JOIN CFT B ON A.PRD001=B.PRD001 AND A.PRD003=B.PRD003 AND A.PRD004=B.PRD004 AND A.PRD006=B.PRD006 AND A.PRD015=B.PRD015)

SELECT idx,PRD001,PRD004,PRD006,PRD003,PRD014,PRD015,PRD013 FROM MOXPRD WHERE idx NOT IN (SELECT idx FROM CHT) AND idx NOT IN (SELECT idaa FROM CHT)
ORDER BY PRD001

     */
