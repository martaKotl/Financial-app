using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessObject
{
    public class UploadFileDAO
    {
        public void CreateFile(string bankStatementFilePath, int bankStatementIdBank)
        {
            string pathToStatement = System.Configuration.ConfigurationManager.AppSettings["PathToStatement"];
            string pathToBankId = System.Configuration.ConfigurationManager.AppSettings["PathToBankId"];
            if (File.Exists(pathToStatement))
            {
                File.Delete(pathToStatement);
                File.Delete(pathToBankId);
            }

            File.Copy(bankStatementFilePath, pathToStatement);
            FileStream fs = new FileStream(pathToBankId, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(Convert.ToString(bankStatementIdBank));
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}
