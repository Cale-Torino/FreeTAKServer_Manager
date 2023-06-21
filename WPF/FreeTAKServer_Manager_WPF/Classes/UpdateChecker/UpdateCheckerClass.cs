using System;
using System.Xml;

namespace FreeTAKServer_Manager_WPF
{
    public enum VersionNumber
    {
        Unknown = -1,
        Major,
        Minor,
        Build
    }
    internal class UpdateCheckerClass
    {
        private int Major, Minor, Build;

        private string XmlConfig, NewVersionPath;

        public UpdateCheckerClass(string Path = null)
        {
            if (Path != null)
                XmlConfig = Path;

            Major = (int)VersionNumber.Unknown;
            Minor = (int)VersionNumber.Unknown;
            Build = (int)VersionNumber.Unknown;

            NewVersionPath = string.Empty;

            CheckUpdate();
        }

        internal void CheckUpdate()
        {
            try
            {
                if (XmlConfig != null && !string.IsNullOrEmpty(XmlConfig))
                {
                    XmlDocument Dom = new XmlDocument();

                    Dom.Load(XmlConfig);
                    string Str = Dom.SelectSingleNode("//currentVersion/major").InnerText;
                    if (int.TryParse(Str, out Major))
                    {
                        Str = Dom.SelectSingleNode("//currentVersion/minor").InnerText;
                        int.TryParse(Str, out Minor);
                        Str = Dom.SelectSingleNode("//currentVersion/build").InnerText;
                        int.TryParse(Str, out Build);
                        NewVersionPath = Dom.SelectSingleNode("//path").InnerText;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public string GetNewVersionPath()
        {
            return NewVersionPath;
        }

        public int GetVersion(VersionNumber En)
        {
            switch (En)
            {
                case VersionNumber.Major:
                    return Major;
                case VersionNumber.Minor:
                    return Minor;
                case VersionNumber.Build:
                    return Build;
                default:
                    return (int)VersionNumber.Unknown;
            }
        }
    }
}
