using ADeeWu.HuoBi3J.Libary;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.My.User.Center
{
    public partial class SaleManQR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var content = WebUtility.GetRequestStr("s", "");
                content = HttpUtility.UrlDecode(content);

                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                QrCode qrCode = new QrCode();
                if (qrEncoder.TryEncode(content, out qrCode))
                {
                    var fCodeSize = new FixedCodeSize(500, QuietZoneModules.Two);
                    fCodeSize.QuietZoneModules = QuietZoneModules.Four;
                    GraphicsRenderer renderer = new GraphicsRenderer(fCodeSize, Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);

                    Response.Cache.SetNoStore();		
                    Response.ClearContent();
                    Response.ContentType = "image/Png";
                    Response.BinaryWrite(ms.ToArray());
                }
            }
        }
    }
}