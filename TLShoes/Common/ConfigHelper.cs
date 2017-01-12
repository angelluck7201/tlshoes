using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLShoes.ViewModels;

namespace TLShoes.Common
{
    public class ConfigHelper
    {
        private static List<AppConfig> _instance;
        public static List<AppConfig> ConfigList
        {
            get
            {
                if (_instance == null)
                {
                    _instance = BaseModel.DbContext.AppConfigs.ToList();
                }
                return _instance;
            }
        }

        private static string _fileConfigPath;
        public static string FileConfigPath
        {
            get
            {
                if (string.IsNullOrEmpty(_fileConfigPath))
                {
                    var fileConfig = ConfigList.FirstOrDefault(s => s.ConfigName == Define.ConfigType.FILE_PATH.ToString());
                    if (fileConfig != null)
                    {
                        _fileConfigPath = fileConfig.ConfigParam;
                    }
                }
                return _fileConfigPath;
            }
        }

        private static int? _lastestVersion;
        public static int LastestVersion
        {
            get
            {
                if (_lastestVersion == null)
                {
                    var versionConfig = ConfigList.FirstOrDefault(s => s.ConfigName == Define.ConfigType.LASTEST_VERSION.ToString());
                    if (versionConfig != null)
                    {
                        _lastestVersion = (int)PrimitiveConvert.StringToInt(versionConfig.ConfigParam);
                    }
                }
                return (int)_lastestVersion;
            }
        }

        private static string _updatePath;
        public static string UpdatePath
        {
            get
            {
                if (string.IsNullOrEmpty(_updatePath))
                {
                    var updatePathConfig = ConfigList.FirstOrDefault(s => s.ConfigName == Define.ConfigType.UPDATE_PATH.ToString());
                    if (updatePathConfig != null)
                    {
                        _updatePath = updatePathConfig.ConfigParam;
                    }
                }
                return _updatePath;
            }
        }
    }
}
