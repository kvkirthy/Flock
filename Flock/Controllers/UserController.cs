
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AttributeRouting;
using AttributeRouting.Web.Mvc;
using Flock.DTO;
using Flock.DataAccess.EntityFramework;
using Flock.Facade.Interfaces;


namespace Flock.Controllers
{
    [RoutePrefix("/api/user")]
    public class UserController : ApiController
    {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [GET("getUser")]
        public UserDto GetUser()
        {
            var userName = HttpContext.Current.User.Identity.Name;
            return _userFacade.GetUserDetails(userName);
        }

        private HttpResponseMessage VerifyPhotoSize(String url)
        {
            var uploadedImg = url.Substring(url.IndexOf(',') + 1);
            
            byte[] data = Convert.FromBase64String(uploadedImg);
            Image imgPhoto = Image.FromStream(new MemoryStream(data));

            if (imgPhoto.Height < 200 || imgPhoto.Width < 800)
            {
                return Request.CreateResponse(HttpStatusCode.Created, false);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Created, true);
            }
        }

        private HttpResponseMessage ImagePreview(UserImageDto img)
        {
            byte[] src;
            var a = img.SourceUrl.Substring(img.SourceUrl.IndexOf(',') + 1);
            byte[] data = Convert.FromBase64String(a);
            Image imgPhoto = Image.FromStream(new MemoryStream(data));

            var height = imgPhoto.Height;
            var width = imgPhoto.Width;

            if (height > 480 && width > 800)
            {
                var newImage = new Bitmap(800, 500);
                Graphics.FromImage(newImage).DrawImage(imgPhoto, 0, 0, 800, 480);
                src = CropImageFile(newImage, img.Width, img.Height, img.X, img.Y);
            }
            else
            {
                src = CropImageFile(imgPhoto, 770, 193, img.X, img.Y);
            }
            string imageForPreview = Convert.ToBase64String(src);
            return Request.CreateErrorResponse(HttpStatusCode.Created, imageForPreview);
        }

        [POST("uploadImage")]
        public HttpResponseMessage Post(UserImageDto img)
        {
            ;
            if (img.Action == 0)
            {
                return VerifyPhotoSize(img.SourceUrl);
            }
            else if(img.Action == 1)
            {
                return ImagePreview(img);
            }
            else if(img.Action ==2)
            {
                var user = new UserDto();
                var a = img.SourceUrl.Substring(img.SourceUrl.IndexOf(',') + 1);
                byte[] data = Convert.FromBase64String(a);
                user.CoverImage = data;
                _userFacade.UpdateUser(user);
                return Request.CreateErrorResponse(HttpStatusCode.Created, img.SourceUrl);


            }
            return null;

            //var a = img.SourceUrl.Substring(img.SourceUrl.IndexOf(',') + 1);

            //byte[] data = Convert.FromBase64String(a);
            //CropImageFile(data , img.Width , img.Height , img.X, img.Y);
            //return null;

        }



        protected byte[] CropImageFile(Image imageFile, int targetW, int targetH, int targetX, int targetY)
        {
            var imgMemoryStream = new MemoryStream();
            //System.Drawing.Image imgPhoto = System.Drawing.Image.FromStream(new MemoryStream(imageFile));
            System.Drawing.Image imgPhoto = imageFile;

            var bmPhoto = new Bitmap(targetW, targetH, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(72, 72);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            grPhoto.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            grPhoto.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            try
            {
                grPhoto.DrawImage(imgPhoto, new Rectangle(0, 0, targetW, targetH),
                                    targetX, targetY, targetW, targetH, GraphicsUnit.Pixel);
                bmPhoto.Save(imgMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                bmPhoto.Save("c:\\local\\x.jpg");
            }

            catch (Exception e)
            {
                throw e;
            }
            return imgMemoryStream.GetBuffer();
        }

    }
}
