using iText.Layout;
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Html2pdf.Css.Media;
using System.Drawing.Imaging;

using iTextSharp.tool.xml;
using iText.Kernel.Pdf;

namespace testApps
{
    public partial class PDFtestapps : System.Web.UI.Page
    {
        string url = HttpContext.Current.Request.Url.AbsoluteUri;
        public static  string src = @"D:\test\olapdf\PDFtestapps.aspx.html";
        public static string css = @"D:\dump\testApps\testApps\css\bootstrap.css";
        public static  string dest = @"D:\test\olapdf\sample.pdf";

        public void createPdf(String src, String dest) 
        {
              
            ConverterProperties properties = new ConverterProperties();  
            properties.SetBaseUri(css); 
            //FontProvider dfp = new DefaultFontProvider();
            CssStyleCollection style= new Panel().Style;
            

            

            MediaDeviceDescription mediaDeviceDescription = new MediaDeviceDescription(MediaType.PRINT);
            properties.SetMediaDeviceDescription(mediaDeviceDescription); 
            HtmlConverter.ConvertToPdf(new FileStream(src, FileMode.Open), new FileStream(dest, FileMode.Create), properties);

        }
         
        protected void Page_Load(object sender, EventArgs e)
        {

        }
          
        protected void ExportPDF(object sender, EventArgs e)
        {
            createPdf(src, dest); 
        }
         
        //private void test()
        //{
        //    byte[] pdf; // result will be here

        //    var cssText = File.ReadAllText(MapPath(@"D:\dump\testApps\testApps\css\bootstrap.css"));
        //    var html = File.ReadAllText(MapPath(@"D:\dump\testApps\testApps\PDFtestapps.html"));

        //    using (var memoryStream = new MemoryStream())
        //    {
        //        //Initialize PDF writer
        //         PdfWriter writer = new PdfWriter(dest);

        //        //Initialize PDF document                
        //        PdfDocument pdf1 = new PdfDocument(writer);

        //        // Initialize document
        //        Document document = new Document(pdf1, PageSize.A4.Rotate());
        //        document.SetMargins(20, 20, 20, 20);


        //   //     PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
        //      //  document.Open();

        //        using (var cssMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(cssText)))
        //        {
        //            using (var htmlMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html)))
        //            {
        //                XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, htmlMemoryStream, cssMemoryStream); 
        //            }
        //        }

        //        document.Close();

        //        pdf = memoryStream.ToArray();
        //    }
        //}  

      

    }
}
