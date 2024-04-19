using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.GeneralEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.GeneralEntities.Banner.Edit
{
    public class EditBannerCommand : IBaseCommand
    {
        public EditBannerCommand(string link, IFormFile? imageFile,
            BannerPosition position, long bannerId)
        {
            Link = link;
            ImageFile = imageFile;
            Position = position;
            BannerId = bannerId;
        }

        public long BannerId { get; private set; }
        public string Link { get; private set; }
        public IFormFile? ImageFile { get; private set; }
        public BannerPosition Position { get; private set; }
    }
}
