using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.ProductAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.ProductAgg
{
    public class Product:AggregateRoot
    {
        public Product(string title, string imageName, string description,
            long categoryId, long subCategoryId, long subSubCategoryId, string slug,
            SeoData seoData, IProductDomainservice productDomainservice)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));

            Validate(title, slug, description, productDomainservice);
            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SubSubCategoryId = subSubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public string Title { get; private set; }
        public string ImageName { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SubSubCategoryId {  get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public List<ProductImage> Images { get; private set; }
        public List<ProductSpecification> Specifications { get; private set; }

        public void Edit(string title, string description,
            long categoryId, long subCategoryId, long subSubCategoryId, string slug, SeoData seoData,
            IProductDomainservice productDomainservice)
        {
            Validate(title, slug, description, productDomainservice);
            Title = title;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SubSubCategoryId = subSubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }
        public void AddImage(ProductImage image)
        {
            image.ProductId = Id;
            Images.Add(image);
        }

        public void SetProductImage(string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            ImageName = imageName;
        }
        public void RemoveImage(long imageId)
        {
            var img = Images.FirstOrDefault(x => x.Id == imageId);
            if (img != null)
                Images.Remove(img);
        }

        public void SetSpecifications(List<ProductSpecification> specifications)
        {
            specifications.ForEach(x => x.ProductId = Id);
            Specifications = specifications;
        }

        public void Validate(string title,string slug, string description, IProductDomainservice productDomainservice)
        {
            NullOrEmptyDomainDataException.CheckString(title,nameof(title));
            NullOrEmptyDomainDataException.CheckString(description,nameof(description));
            NullOrEmptyDomainDataException.CheckString(slug,nameof(slug));

            if (slug != Slug && productDomainservice.SlugExists(slug.ToSlug()))
                throw new DuplicatedSlugException(slug);
        }
    }
}
