using System;
using System.IO;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

public class pafap_lists
{
    public ArrayList l;
    public bool isInitialized = false;
    public bool init()
    {
        try
        {
            l = new ArrayList();
            isInitialized = true;
        }
        catch
        {
            isInitialized = false;
        }
        return isInitialized;
    }
    public void clear()
    {
        l.Clear();
    }
    public uint count()
    {
        if (isInitialized)
            return (uint)l.Count;
        return 0;
    }
}

