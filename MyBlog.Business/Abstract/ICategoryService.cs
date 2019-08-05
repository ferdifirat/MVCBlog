using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.Entities.Concrete;
using MyBlog.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyBlog.Business.Abstract
{
    public interface ICategoryService
    {
        List<CategoryDto> GetList(Expression<Func<Category, bool>> expression = null);
        List<SelectListItem> GetCategoriesForCategoryComboBox();
        CategoryDto GetCategory(Expression<Func<Category, bool>> expression = null);
        bool DeleteCategory(int id);
        
    }
}
