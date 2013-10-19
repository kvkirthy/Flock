using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Flock.DTO;

namespace Flock.Facade.Interfaces
{
    public interface IImageFacade
    {
        String ProcessImageByAction(UserImageDto img);
        byte[] GetImageFromUrl(String imageUrl);
    }
}