namespace ReleaseCompanion
{
    public class Parameters
    {
        public int SerialNumber { get; set; }
        public string NickName { get; set; }
        public string BatchFileStart { get; set; }
        public string BatchFileStop { get; set; }
        public string AppServerPath { get; set; }
        public string AppBackupPath { get; set; }
        public string WindowsServiceBackupPath { get; set; }
        public string AppURL { get; set; }
        public EnvironmentType EnvironmentType { get; set; }
        public ReleaseType ReleaseType { get; set; }
        public string DBName { get; set; }
        public string DBServerName { get; set; }
        public string DBBackupLocation { get; set; }
        public string FilePath { get; set; }
        public string FrameworkReleasePath { get; set; }
        public string WindowsServiceServerPath { get; set; }
    }

    public class GridParam
    {
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public bool Backup { get; set; }
        public bool Release { get; set; }
        public bool ScriptRequired { get; set; }
        public bool IsLessorPortal { get; set; }
        public string FilePath { get; set; }
        public bool IsFrameworkRelease { get; set; }
    }

    public enum EnvironmentType
    {
        LessorPortal = 0, BrokerPortal = 1
    }

    public enum ReleaseType
    {
        None = 0, ReleaseOnly = 1, BackupOnly = 2, BackupandRelease = 3
    }

    public class AppSetting
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Environments { get; set; }
    }
}
