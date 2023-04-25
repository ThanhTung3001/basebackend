using Microsoft.AspNetCore.Builder;
using QRCoder;
using WebApi.Middlewares;

namespace WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
        // public static void GenerateQRCode(string text, string filePath)
        // {
        //     QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //     QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
        //     QRCode qrCode = new QRCode(qrCodeData);
        //     Bitmap qrCodeImage = qrCode.GetGraphic(20);
        //
        //     qrCodeImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        // }
    }
}
