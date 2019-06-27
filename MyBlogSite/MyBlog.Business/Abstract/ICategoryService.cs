using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyBlog.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList(Expression<Func<Category, bool>> expression = null);
        List<SelectListItem> GetCategoriesForCategoryComboBox();
        
    }
}
