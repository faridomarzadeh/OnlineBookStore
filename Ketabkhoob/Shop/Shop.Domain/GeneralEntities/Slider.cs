using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.GeneralEntities
{
    public class Slider:BaseEntity
    {
        private Slider() { }
        public Slider(string title, string link, string imageName)
        {
            Validate(title, link, imageName);
            Title = title;
            Link = link;
            ImageName = imageName;
        }
        public void Edit(string title, string link, string imageName)
        {
            Validate(title, link, imageName);
            Title = title;
            Link = link;
            ImageName = imageName;
        }
        public void Validate(string title, string link, string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(title,nameof(title));
            NullOrEmptyDomainDataException.CheckString(link,nameof(link));
            NullOrEmptyDomainDataException.CheckString(imageName,nameof(imageName));
        }
        public string Title { get; private set; }
        public string Link { get; private set; }
        public string ImageName { get; private set; }
    }
}
