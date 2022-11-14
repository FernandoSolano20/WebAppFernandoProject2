﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Entities_POJO;
using TheArtOfDev.HtmlRenderer.PdfSharp;


namespace CoreAPI.AppCode.Helper
{
    public class PdfHelper
    {
        public static Byte[] PdfSharpConvert(string html)
        {

            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A5);
                pdf.Save(ms);
                res = ms.ToArray();

            }
            return res;
        }

        public static string Invoice(/*Usuario proovedor,*/ Usuario cliente, Entities_POJO.Factura factura, List<Entities_POJO.Detalle> detalles)
        {
            var items = string.Empty;
            decimal total = 0;
            foreach (var detalle in detalles)
            {
                items = $"            <tr class='item' v-for='item in items'>" +
                        $"                <td>{detalle.Nombre}</td>" +
                        $"                <td>{detalle.Precio}</td>" +
                        $"                <td>{detalle.Cantidad}</td>" +
                        $"                <td>{detalle.Precio*detalle.Cantidad} {cliente.Moneda}</td>" +
                        $"            </tr>";
                total += (detalle.Precio * detalle.Cantidad);
            }
            


            return $"<!doctype html>" +
                $"<html>" +

                $"<head>" +
                $"    <meta charset='utf-8'>" +
                $"    <title>A simple, clean, and responsive HTML invoice template</title>" +
                $"    <style>" +
                @"        .invoice-box{max - width:800px;margin:auto;padding:30px;border:1px solid #eee;box-shadow:0 0 10px rgba(0,0,0,.15);font-size:16px;line-height:24px;font-family:'Helvetica Neue',Helvetica,Helvetica,Arial,sans-serif;color:#555}.invoice-box table{width:100%;line-height:inherit;text-align:left}.invoice-box table td{padding:5px;vertical-align:top}.invoice-box table tr td:nth-child(n+2){text - align:right}.invoice-box table tr.top table td{padding - bottom:20px}.invoice-box table tr.top table td.title{font - size:45px;line-height:45px;color:#333}.invoice-box table tr.information table td{padding - bottom:40px}.invoice-box table tr.heading td{background:#eee;border-bottom:1px solid #ddd;font-weight:700}.invoice-box table tr.details td{padding - bottom:20px}.invoice-box table tr.item td{border - bottom:1px solid #eee}.invoice-box table tr.item.last td{border - bottom:none}.invoice-box table tr.item input{padding - left:5px}.invoice-box table tr.item td:first-child input{margin - left:-5px;width:100%}.invoice-box table tr.total td:nth-child(2){border - top:2px solid #eee;font-weight:700}.invoice-box input[type=number]{width:60px}@media only screen and (max-width:600px){.invoice - box table tr.top table td{width:100%;display:block;text-align:center}.invoice-box table tr.information table td{width:100%;display:block;text-align:center}}.rtl{direction:rtl;font-family:Tahoma,'Helvetica Neue',Helvetica,Helvetica,Arial,sans-serif}.rtl table{text - align:right}.rtl table tr td:nth-child(2){text - align:left}" + 
                $"    </style>" +
                $"</head>" +

                $"<body>" +
                $"    <div class='invoice-box'>" +
                $"        <table cellpadding='0' cellspacing='0'>" +
                $"            <tr class='top'>" +
                $"                <td colspan='4'>" +
                $"                    <table>" +
                $"                        <tr>" +
                $"                            <td class='title'>" +
                $"                                <img src='https://res.cloudinary.com/grupo-bejuco/image/upload/v1585727023/Bejuco.jpg'" +
                $"                                    style='width:100%; max-width:300px;'>" +
                $"                            </td>" +

                $"                            <td>" +
                $"                                Invoice #: {factura.ID}<br> Created: {factura.Fecha.ToString("D")}<br>" +
                $"                            </td>" +
                $"                        </tr>" +
                $"                    </table>" +
                $"                </td>" +
                $"            </tr>" +

                $"            <tr class='information'>" +
                $"                <td colspan='4'>" +
                $"                    <table>" +
                $"                        <tr>" +
                /*$"                            <td>" +
                $"                                {proovedor.Nombre} {proovedor.PrimerApellido}.<br> {proovedor.Provincia}, {proovedor.Canton}, {proovedor.Distrito}<br> {proovedor.Direccion} <br> {proovedor.Email}" +
                $"                            </td>" +*/

                $"                            <td>" +
                $"                                {cliente.Nombre} {cliente.PrimerApellido}.<br> {cliente.Provincia}, {cliente.Canton}, {cliente.Distrito}<br> {cliente.Direccion} <br> {cliente.Email}" +
                $"                            </td>" +
                $"                        </tr>" +
                $"                    </table>" +
                $"                </td>" +
                $"            </tr>" +

                $"            <tr class='heading'>" +
                $"                <td>Item</td>" +
                $"                <td>Unit Cost</td>" +
                $"                <td>Quantity</td>" +
                $"                <td>Price</td>" +
                $"            </tr>" +

                $"{items}"+

                $"            <tr class='total'>" +
                $"                <td colspan='3'></td>" +
                $"                <td>Total: {total} {cliente.Moneda}</td>" +
                $"            </tr>" +
                $"        </table>" +
                $"    </div>" +
                $"</body>" +
                $"</html>";
        }

        private static void StartBrowser(string source)
        {
            var th = new Thread(() =>
            {
                var webBrowser = new WebBrowser();
                webBrowser.ScrollBarsEnabled = false;
                webBrowser.IsWebBrowserContextMenuEnabled = true;
                webBrowser.AllowNavigation = true;

                webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
                webBrowser.DocumentText = source;

                Application.Run();
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        static void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var webBrowser = (WebBrowser)sender;
            using (Bitmap bitmap =
                new Bitmap(
                    webBrowser.Width,
                    webBrowser.Height))
            {
                webBrowser
                    .DrawToBitmap(
                        bitmap,
                        new System.Drawing
                            .Rectangle(0, 0, bitmap.Width, bitmap.Height));
                bitmap.Save(@"filename.jpg",
                    System.Drawing.Imaging.ImageFormat.Jpeg);
            }

        }
    }
}
