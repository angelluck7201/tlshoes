﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLShoes.ViewModels;

namespace TLShoes.Common
{
    public class ErrorControl
    {

        public static void UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                WriteErrorLog(t.Exception);
                result = ShowThreadExceptionDialog("Xuất hiện lỗi", t.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Chương trình không thể tiếp tục hoạt động!",
                        "Chương trình không thể tiếp tục hoạt động!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Exits the program when the user clicks Abort.
            if (result == DialogResult.Abort)
                Application.Exit();
        }

        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
            string errorMsg = "Có lỗi xảy ra. Xin thứ lỗi về sự bất tiện này!:\n\n";
            //errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Stop);
        }

        private static void WriteErrorLog(Exception e)
        {
            var errorLog = new ErrorLog();
            errorLog.CreatedDate = TimeHelper.TimestampToString(TimeHelper.CurrentTimeStamp());
            errorLog.Messagelog = e.Message + "\n\nStack Trace:\n" + e.StackTrace;
            errorLog.AppVersion = Main.CURRENT_VERSION;
            BaseModel.DbContext.ErrorLogs.Add(errorLog);
            BaseModel.DbContext.SaveChanges();
        }
    }
}