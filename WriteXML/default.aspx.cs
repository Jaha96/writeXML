﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace WriteXML
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Init();
        }

        public void Init()
        {
            DataSet ds = new DataSet();

            if (Cache["mycache"] == null)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Cache generated";
                ds.ReadXml(Server.MapPath("Authors.xml"));
                Cache.Insert("mycache", ds, new CacheDependency(Server.MapPath("Authors.xml")), DateTime.Now.AddSeconds(100), TimeSpan.Zero);
                GridView1.DataSource = Cache["mycache"];
                GridView1.DataBind();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Using regenerated version";
                GridView1.DataSource = Cache["mycache"];
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            writeXML();
            Init();
        }

        protected void writeXML()
        {
            String authID = txtID.Text;
            String authFname = txtFname.Text;
            String authLname = txtLname.Text;

            if (File.Exists(Server.MapPath("Authors.xml")) == false)
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;
                using (XmlWriter xmlWriter = XmlWriter.Create(Server.MapPath("Authors.xml"), xmlWriterSettings))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("authorslist");

                    xmlWriter.WriteStartElement("authors");
                    xmlWriter.WriteElementString("au_id", authID);
                    xmlWriter.WriteElementString("au_lname", authLname);
                    xmlWriter.WriteElementString("au_fname", authFname);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                    xmlWriter.Close();
                }
            }
            else
            {
                XDocument doc = XDocument.Load(Server.MapPath("Authors.xml"));
                XElement root = new XElement("authors");
                root.Add(new XElement("au_id", authID));
                root.Add(new XElement("au_lname", authLname));
                root.Add(new XElement("au_fname", authFname));
                doc.Element("authorslist").Add(root);
                doc.Save(Server.MapPath("Authors.xml"));
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            DataTable dtSales=new DataTable();
            dtSales = (DataTable)GridView1.DataSource;
            dtSales.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "au_id", txtID.Text);
        
        }
    }
}