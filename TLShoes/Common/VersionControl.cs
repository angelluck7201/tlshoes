using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TLShoes.Common
{
    public class VersionControl
    {
        public const int CURRENT_VERSION = 1;

        public static bool IsNeedUpdate()
        {
            var lastestVersion = ConfigHelper.LastestVersion;
            return lastestVersion > CURRENT_VERSION;
        }

        public static void CheckAndUpdateApp()
        {
            var isNeedUpdate = IsNeedUpdate();
            if (isNeedUpdate)
            {
                DialogResult dialog = MessageBox.Show("Có version mới, tiến trình update sẽ được thực hiện ngay bây giờ","Thông Báo Update", MessageBoxButtons.OK);
                if (dialog == DialogResult.OK)
                {
                    var updatePath = ConfigHelper.UpdatePath;
                    FileHelper.UpdateAppConfig(Define.ConfigType.UPDATE_PATH.ToString(), updatePath);

                    var updateAppPath = Path.Combine(FileHelper.SourcePath, "UpdateApp.exe");
                    System.Diagnostics.Process.Start(updateAppPath);

                    Application.Exit();
                }
            }
        }
    }
}
