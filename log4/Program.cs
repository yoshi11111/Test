using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace log4
{
    static class Program
    {
        // log <-- このへんに追加
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            logger.Debug("開発中のデバッグ／トレースに使用する");
            logger.Info("情報（操作履歴等）er");
            logger.Warn("注意／警告（障害の一歩手前）");
            logger.Error("システムが停止するまではいかない障害が発生");
            logger.Fatal("システムが停止する致命的な障害が発生");
            logger.ErrorFormat("hoge：{0}", "aaaaa");
            Application.Run(new Form1());
        }

    }
}
