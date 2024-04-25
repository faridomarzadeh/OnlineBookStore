using Shop.Domain.CategoryAgg;
using Shop.Query.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Categories
{
    public static class CategoryMapper
    {
        public static CategoryDto Map(this Category? category)
        {
            if (category == null)
                return null;

            return new CategoryDto()
            {
                Title = category.Title,
                Id = category.Id,
                Slug = category.Slug,
                SeoData = category.SeoData,
                CreationDate = category.CreationDate,
                ChildCategories = category.ChildCategories.MapSubCategories()
            };
        }
        public static List<SubCategoryDto> MapSubCategories(this List<Category> subCategories)
        {
            var results = new List<SubCategoryDto>();
            if (subCategories == null)
                return results;

            foreach (var subCategory in subCategories)
            {
                results.Add(new SubCategoryDto()
                {
                    Title = subCategory.Title,
                    Id = subCategory.Id,
                    Slug = subCategory.Slug,
                    SeoData = subCategory.SeoData,
                    CreationDate = subCategory.CreationDate,
                    ParentId = (long)subCategory.ParentId,
                    ChildCategories = subCategory.ChildCategories.MapSubSubCategories()
                }
                );
            }
            return results;
        }

        private static List<SubSubCategoryDto> MapSubSubCategories(this List<Category> subSubCategories)
        {
            var results = new List<SubSubCategoryDto>();
            if(subSubCategories == null)
                return results;

            foreach (var subSubCategory in subSubCategories)
            {
                results.Add(new SubSubCategoryDto()
                {
                    Title = subSubCategory.Title,
                    Id = subSubCategory.Id,
                    Slug = subSubCategory.Slug,
                    SeoData = subSubCategory.SeoData,
                    CreationDate = subSubCategory.CreationDate,
                    ParentId = (long)subSubCategory.ParentId,
                }
                );
            }
            return results;
        }
    }
}
