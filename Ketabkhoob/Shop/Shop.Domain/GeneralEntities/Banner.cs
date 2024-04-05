using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.GeneralEntities
{
    public class Banner:BaseEntity
    {
        public Banner(string link, string imageName, BannerPosition position)
        {
            Validate(link, imageName);
            Link = link;
            ImageName = imageName;
            Position = position;
        }
        public void Edit(string link, string imageName, BannerPosition position)
        {
            Validate(link, imageName);
            Link = link;
            ImageName = imageName;
            Position = position;
        }

        public void Validate(string link,string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(link,nameof(link));
            NullOrEmptyDomainDataException.CheckString(imageName,nameof(imageName));
        }

        public string Link { get;private set; }
        public string ImageName { get;private set; }
        public BannerPosition Position { get;private set; }
    }
}
