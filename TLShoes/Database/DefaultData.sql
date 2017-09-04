-- Default data AppConfig
BEGIN
    IF NOT EXISTS
    (
        SELECT TOP 1 * FROM AppConfig WHERE ConfigName = 'FILE_PATH'
    )
        INSERT INTO AppConfig(ConfigName, ConfigParam)
    VALUES('FILE_PATH', '\\LONGNGUYEN\Users\nguye\Desktop\Share Folder\image\');
    IF NOT EXISTS
    (
        SELECT TOP 1 * FROM AppConfig WHERE ConfigName = 'LASTEST_VERSION'
    )
        INSERT INTO AppConfig(ConfigName, ConfigParam)
    VALUES('LASTEST_VERSION', '1');
    IF NOT EXISTS
    (
        SELECT TOP 1 * FROM AppConfig WHERE ConfigName = 'UPDATE_PATH'
    )
        INSERT INTO AppConfig(ConfigName, ConfigParam)
    VALUES('UPDATE_PATH', '\\LONGNGUYEN\Users\nguye\Desktop\Share Folder\update\');
END;