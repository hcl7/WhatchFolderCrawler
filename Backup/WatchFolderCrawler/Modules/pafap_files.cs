using System;
using System.IO;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml;
using System.Xml.XPath;
using System.Threading;
using System.Windows.Forms;

public class pafap_files
{
    public string errors = "";
    public String Line;
    public string ResultPerPage;
    public string FileName;
    public bool isParsed = false;
    public static string source = string.Empty;
    public static string destination = string.Empty;

    public struct loadpath
    {
        public string source;
        public string destination;
    }
    loadpath lp = new loadpath();
    public void makePaths(string sourcestr, string deststr, string fn)
    {
        try
        {
            StreamWriter swfile;
            swfile = File.AppendText(fn);
            swfile.Write(sourcestr);
            swfile.Write(" > ");
            swfile.WriteLine(deststr);
            swfile.Close();
        }
        catch (Exception e)
        {
            errors = "makePaths Error: " + e.Message;
        }
    }
    //copy txt file;
    public void makeTempFile(string source, string dest)
    {
        try
        {
            using (FileStream sourceStream = new FileStream(source, FileMode.Open))
            {
                byte[] buffer = new byte[64 * 1024];
                using (FileStream destStream = new FileStream(dest, FileMode.Create))
                {
                    int i;
                    while ((i = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        destStream.Write(buffer, 0, i);
                    }
                }
            }
        }
        catch (Exception e)
        {
            errors = "makeTempFile error: " + e.Message;
        }
    }
    //get value from XML file;
    public string GetValueFromXmlFile(string fn, string expr)
    {
        string xmlReturnValue = "";
        try
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(fn);
            XPathNavigator xpn = xmldoc.CreateNavigator();
            XPathNodeIterator xpni = xpn.Select(expr);
            while (xpni.MoveNext())
            {
                xmlReturnValue = xpni.Current.Value;
            }
        }
        catch ( Exception e )
        {
            errors = "GetValueFromXmlFile error: " + e.Message;
        }
        return xmlReturnValue;
    }
    //check is the file is open for read/write or don't exists;
    public bool checkIfIsOpen(string file)
    {
        FileStream stream = null;
        FileInfo fileInfo = new FileInfo(file);
        try
        {
            stream = fileInfo.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }
        catch (IOException)
        {
            return true;
        }
        finally
        {
            if (stream != null)
                stream.Close();
        }
        return false;
    }
    //check if the file exists;
    public bool checkIfExist(string fn)
    {
        return (File.Exists(fn)) ? true : false;
    }
    //clear the file;
    public void clearFile(string fn)
    {
        try
        {
            FileStream fileStream = File.Open(fn, FileMode.Open);
            fileStream.SetLength(0);
            fileStream.Flush();
            fileStream.Close();
        }
        catch (Exception e)
        {
            errors = "clearFile error: " + e.Message;
        }
    }
    //copy file;
    public void copyFile(string source, string destination)
    {
        try
        {
            using (FileStream sourceStream = new FileStream(source, FileMode.Open))
            {
                byte[] buffer = new byte[64 * 1024];
                using (FileStream destStream = new FileStream(destination + Path.GetFileName(source), FileMode.Create))
                {
                    int i;
                    while ((i = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        destStream.Write(buffer, 0, i);
                    }
                }
            }
        }
        catch (Exception e)
        {
            errors = "copyFile error: " + e.Message;
        }
    }
    //split line by char;
    public void readLinesFromFile(string file, char readUntilToChar, pafap_lists pl)
    {
        String[] paths;
        int sep;
        int iLine = 0;
        int errornum = 0;
        try
        {
            StreamReader sr = new StreamReader(file);
            do
            {
                Line = sr.ReadLine();
                if (Line == null)
                    continue;
                iLine++;
                Line = Line.Trim();
                if (Line.Length == 0)
                    continue;
                sep = Line.IndexOf(readUntilToChar);
                if (sep < 0)
                {
                    errornum++;
                    errors = "readLineFromFile error!";
                    continue;
                }
                paths = new String[2];
                paths[0] = Line.Substring(0, sep);
                paths[1] = Line.Substring(sep + 1, Line.Length - sep - 1);
                source = paths[0];
                destination = paths[1];
                lp.source = source;
                lp.destination = destination;
                pl.l.Add(lp);
            }
            while (Line != null);
            sr.Close();
        }
        catch (Exception e)
        {
            errors = "readLineFromFile error: " + e.Message;
        }
        finally
        {
            if (source.Length > 0 && destination.Length > 0) isParsed = true;
        }
    }

    //if file is copied;
    public bool CheckFileHasCopied(string FilePath)
    {
        try
        {
            if (File.Exists(FilePath))
                using (File.OpenRead(FilePath))
                {
                    return true;
                }
            else
                return false;
        }
        catch (Exception)
        {
            Thread.Sleep(100);
            return CheckFileHasCopied(FilePath);
        }
    }

    public void LogFile(string logMessage, string lfp)
    {
        string strLogMessage = string.Empty; 
        StreamWriter swLog;
        strLogMessage = string.Format("{0}: {1}", DateTime.Now, logMessage);
        try
        {
            if (!File.Exists(lfp))
            {
                swLog = new StreamWriter(lfp);
            }
            else
            {
                swLog = File.AppendText(lfp);
            }
            swLog.WriteLine(strLogMessage);
            swLog.WriteLine();
            swLog.Close();
        }
        catch (Exception ex)
        {
            errors = "LogFile error: " + ex.Message;
        }
    }

    public void readLogFile(string fn, TextBox txtlog)
    {
        StreamReader srf = new StreamReader(fn);
        try
        {
            txtlog.Text = srf.ReadToEnd();
            srf.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }
    public bool checkIsEmpty(string fn)
    {
        FileInfo fi = new FileInfo(fn);
        if (fi.Length == 0)
            return true;
        else
            return false;
    }
    public void Watcher(string path, string filter, CheckBox chbsubdir, FileSystemWatcher fsw)
    {
        fsw.Path = @path;
        fsw.Filter = filter;
        fsw.IncludeSubdirectories = chbsubdir.Checked;
    }
}