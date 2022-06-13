namespace Cosmos.Core;

public class LogHelper
{
    public static void WriteLog(string str, string category = "ping_log")
    {
        string sFilePath = $"C:\\{category}\\" + DateTime.Now.ToString("yyyy-MM-dd");
        //string sFilePath = filepath+ _sFilePath;
        string sFileName = "DSM" + "-" + DateTime.Now.ToString("yyyy-MM-dd hh") + ".log";
        sFileName = sFilePath + "\\" + sFileName; //the absolute path of file 
        if (!Directory.Exists(sFilePath))//Verify that the path exists
        {
            Directory.CreateDirectory(sFilePath);
            //Create if not present
        }
        FileStream fs;
        StreamWriter sw;
        if (File.Exists(sFileName))
        //verify that the file exists ,append if present ,creat if not present
        {
            fs = new FileStream(sFileName, FileMode.Append, FileAccess.Write);
        }
        else
        {
            fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write);
        }
        sw = new StreamWriter(fs);
        sw.Write(str);
        sw.Close();
        fs.Close();
    }

}

