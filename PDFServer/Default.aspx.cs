using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PDFServer
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var files = Directory.GetFiles(Server.MapPath("/PDFs/"));
            this.ListBox1.Items.AddRange(files.Select(c => new ListItem() { Text = c }).ToArray());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var currentText = this.ListBox1.SelectedItem.Text;
            var fileName = Path.GetFileName(currentText);
            Response.Redirect(string.Format("/pdfjs/web/viewer.html?file=/PDFs/{0}", fileName));
        }
    }
}