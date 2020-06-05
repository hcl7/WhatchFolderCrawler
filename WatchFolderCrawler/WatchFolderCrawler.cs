using System;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Configuration;

namespace WatchFolderCrawler
{
    namespace pafap_global
    {
        public class Init
        {
            public static pafap_sql InitSql;
        }
    }
    public partial class frmWFC : Form
    {
        public frmWFC()
        {
            InitializeComponent();
            pafap_global.Init.InitSql = new pafap_sql(cstr);
            pafap_global.Init.InitSql.ping();
            chbcrawler.Enabled = false;
            lblnrindexed.Text = "Indexed: " + 0;
            lbldub.Text = "Dublicated: " + 0;
            lblcreated.Text = "Created: " + 0;
            lblnrchanged.Text = "Changed: " + 0;
            lblrenamed.Text = "Renamed: " + 0;
            lblnrdeleted.Text = "Deleted: " + 0;
        }
        public class DBInfo
        {
            public DBInfo(string _fn, string _path, string _ext, string _datemodified)
            {
                fn = _fn;
                path = _path;
                ext = _ext;
                datemodified = _datemodified;
            }
            public string fn;
            public string path;
            public string ext;
            public string datemodified;
        }

        public class WatchCrawlerInfo
        {
            public WatchCrawlerInfo()
            {
                created = 0; 
                changed = 0;
                renamed = 0;
                deleted = 0;
                dublicated = 0;
            }
            public int created;
            public int changed;
            public int renamed;
            public int deleted;
            public int dublicated;
        }
        
        private string cstr = ConfigurationManager.ConnectionStrings["cstring"].ToString();
        private string errors;
        WatchCrawlerInfo wci = new WatchCrawlerInfo();
        
        private void fswfoldercrawler_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            txtlog.Text += e.ChangeType + ": " + e.FullPath + "\r\n";
            txtlog.Focus();
            txtlog.Select(txtlog.TextLength, 0);
            wci.changed += 1;
            lblnrchanged.Text = "Changed: " + wci.changed;
            txtlog.ScrollToCaret();
        }

        private void fswfoldercrawler_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            txtlog.Text += e.ChangeType + ": " + e.FullPath + "\r\n";
            if (chbcrawler.Checked)
            {
                FileInfo fi = new FileInfo(e.FullPath);
                string datetime = File.GetLastWriteTime(e.FullPath).ToString();
                DBInfo dbi = new DBInfo(fi.Name, Path.GetDirectoryName(fi.FullName), fi.Extension, datetime);
                string sql = "SET ANSI_WARNINGS OFF INSERT INTO files (fn, pth, ext, date_modified, aspect_ratio, status) VALUES('" + dbi.fn + "', '" + dbi.path + "\\', '" + dbi.ext + "', '" + dbi.datemodified + "', '0', '0');";
                string dub = "SELECT fn FROM files WHERE fn = '" + dbi.fn + "' AND pth = '" + dbi.path + "\\'";
                pafap_global.Init.InitSql.errors = string.Empty;
                if (pafap_global.Init.InitSql.checkValue(dub))
                {
                    errors = pafap_global.Init.InitSql.errors;
                    wci.dublicated += 1;
                    lbldub.Text = "Dublicated: " + wci.dublicated;
                    lblstatus.Text = errors;
                }
                else
                {
                    indexing(sql);
                    wci.created += 1;
                    if (errors == "")
                    {
                        lblnrindexed.Text = "Indexed: " + wci.created;
                        lblcreated.Text = "Created: " + wci.created;
                        lblLastIndexed.Text = "LastIndexed: " + dbi.fn;
                    }
                    else errors = string.Empty;
                }
            }
            txtlog.Select(txtlog.TextLength, 0);
            txtlog.ScrollToCaret();
        }

        private void fswfoldercrawler_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            txtlog.Text += e.ChangeType + ": " + e.FullPath + "\r\n";
            txtlog.Focus();
            txtlog.Select(txtlog.TextLength, 0);
            txtlog.ScrollToCaret();
            wci.deleted += 1;
            lblnrdeleted.Text = "Deleted: " + wci.deleted;
            if (chbcrawler.Checked)
            {
                FileInfo fi = new FileInfo(e.FullPath);
                string datetime = File.GetLastWriteTime(e.FullPath).ToString();
                DBInfo dbi = new DBInfo(fi.Name, Path.GetDirectoryName(fi.FullName), fi.Extension, datetime);
                string del = "DELETE FROM files WHERE fn = '" + dbi.fn + "' AND pth = '" + dbi.path + "\\'";
                indexing(del);
            }
        }

        private void fswfoldercrawler_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            txtlog.Text += e.ChangeType + ": " + e.OldFullPath + " renamed to: " + e.FullPath + "\r\n";
            txtlog.Focus();
            txtlog.Select(txtlog.TextLength, 0);
            FileInfo ofi = new FileInfo(e.OldFullPath);
            FileInfo nfi = new FileInfo(e.FullPath);
            DBInfo dbi = new DBInfo(nfi.Name, Path.GetDirectoryName(nfi.FullName), nfi.Extension, nfi.LastWriteTime.ToString());
            if (chbcrawler.Checked)
            {
                string sql = "UPDATE files SET fn = '" + nfi.Name + "' WHERE fn = '" + ofi.Name + "'";
                indexing(sql);
            }
            wci.renamed += 1;
            lblrenamed.Text = "Renamed: " + wci.renamed;
            lblLastIndexed.Text = "LastIndexed: " + dbi.fn;
            txtlog.ScrollToCaret();
        }

        private void chbwatch_CheckedChanged(object sender, EventArgs e)
        {
            if (chbwatch.Checked)
            {
                TypeOfWatcher();
                this.fswfoldercrawler.IncludeSubdirectories = chbsubdir.Checked;
                this.fswfoldercrawler.EnableRaisingEvents = chbwatch.Checked;
                chbcrawler.Enabled = chbwatch.Checked;
                chbwatch.Text = "Watching";
                chbwatch.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                this.fswfoldercrawler.EnableRaisingEvents = chbwatch.Checked;
                chbcrawler.Enabled = chbwatch.Checked;
                chbcrawler.Checked = false;
                chbwatch.Text = "Watch";
                chbwatch.ForeColor = System.Drawing.Color.Red;
            }
        }

        public void TypeOfWatcher()
        {
            this.fswfoldercrawler.Path = @txtpath.Text;
            this.fswfoldercrawler.Filter = txtfilter.Text;
        }

        private void chbcrawler_CheckedChanged(object sender, EventArgs e)
        {
            if (chbcrawler.Checked)
            {
                chbcrawler.Text = "Crawling";
                chbcrawler.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                chbcrawler.Text = "Crawler";
                chbcrawler.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtlog.Text = string.Empty;
        }

        private void indexing(string query)
        {
            errors = string.Empty;
            pafap_global.Init.InitSql.errors = string.Empty;
            pafap_global.Init.InitSql.runSQLQuery(query);
            if (pafap_global.Init.InitSql.errors != "")
            {
                lblstatus.Text = pafap_global.Init.InitSql.errors;
                errors = pafap_global.Init.InitSql.errors;
            }
            System.Threading.Thread.Sleep(500);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmWFC_Load(object sender, EventArgs e)
        {
            Icon viewIcon = new Icon("logo.ico");
            this.Icon = viewIcon;
        }
    }
}
