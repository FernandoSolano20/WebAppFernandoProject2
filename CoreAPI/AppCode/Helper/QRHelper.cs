using Entities_POJO;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.AppCode.Helper
{
    public static class QRHelper
    {
        /// <summary>
        /// Retonar un codigo QR en formato Base64 para poder ser almacenado en la base de datos
        /// </summary>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        public static string GenerarCodigoQRBase64(Solicitud solicitud)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            string solicitudData = solicitud.ID.ToString();
            QRCodeData data = qrGenerator.CreateQrCode(solicitudData, QRCodeGenerator.ECCLevel.Q);
            Base64QRCode code = new Base64QRCode(data);
            string qrCodeImageAsBase64 = code.GetGraphic(20);
            return qrCodeImageAsBase64;
        }
        /// <summary>
        /// Permite retonar un codigo QR en formato de arreglo de bytes, para poder ser enviado mediante correo
        /// </summary>
        /// <param name="solicitud"></param>
        /// <returns>Arreglo de bytes</returns>
        public static byte[] GenerarCodigoQRByteArray(Solicitud solicitud)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            string solicitudData = solicitud.ID.ToString();
            QRCodeData data = qrGenerator.CreateQrCode(solicitudData, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            Bitmap bitmap = code.GetGraphic(20);
            return ToByteArray(bitmap, ImageFormat.Bmp);
        }

        public static byte[] ToByteArray(this Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }
    }
}
