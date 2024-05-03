using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.CategoryAgg
{
    public class Category:AggregateRoot
    {
        private Category()
        {
            
        }
        public Category(string title, string slug, SeoData seoData, ICategoryDomainService categoryDomainService)
        {
            slug = slug?.ToSlug();
            Validate(title, slug, categoryDomainService);
            Title = title;
            Slug = slug;
            SeoData = seoData;
        }

        public string Title { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public long? ParentId { get; private set; }
        public List<Category> ChildCategories { get; private set; }

        public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService categoryDomainService)
        {
            slug = slug?.ToSlug();
            Validate(title, slug, categoryDomainService);
            Title = title;
            Slug = slug;
            SeoData = seoData;
        }

        public void AddChild(string title, string slug, SeoData seoData, ICategoryDomainService categoryDomainService)
        {
            ChildCategories.Add(new Category(title, slug, seoData, categoryDomainService)
            {
                ParentId = Id
            });
        }

        public void Validate(string title, string slug, ICategoryDomainService categoryDomainService)
        {
            NullOrEmptyDomainDataException.CheckString(title,nameof(title));
            NullOrEmptyDomainDataException.CheckString(slug,nameof(slug));

            if (slug != Slug && categoryDomainService.SlugExists(slug))
                throw new DuplicatedSlugException(slug);
        }
    }
}
