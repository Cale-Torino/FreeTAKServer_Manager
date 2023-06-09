using System;
using System.Xml;

namespace FreeTAKServer_Manager
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
            {
                XmlConfig = Path;
            }

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
                    XmlDocument Doc = new XmlDocument();

                    Doc.Load(XmlConfig);
                    string DocString = Doc.SelectSingleNode("//currentVersion/major").InnerText;
                    if (int.TryParse(DocString, out Major))
                    {
                        DocString = Doc.SelectSingleNode("//currentVersion/minor").InnerText;
                        int.TryParse(DocString, out Minor);

                        DocString = Doc.SelectSingleNode("//currentVersion/build").InnerText;
                        int.TryParse(DocString, out Build);

                        NewVersionPath = Doc.SelectSingleNode("//path").InnerText;
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

        public int GetVersion(VersionNumber en)
        {
            switch (en)
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
