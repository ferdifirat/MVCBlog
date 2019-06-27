using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyBlog.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(
            ICategoryDal categoryDal
            )
        {

            _categoryDal = categoryDal;
        }

        public List<SelectListItem> GetCategoriesForCategoryComboBox()
        {
            var selectedList = new List<SelectListItem>();
            var categories = _categoryDal.GetList();
            foreach (var item in categories)
            {
                var listItem = new SelectListItem()
                {
                    Text = item.CategoryName,
                    Value = item.Id.ToString()
                };
                selectedList.Add(listItem);
            }

            return selectedList;
        }

       

        public List<Category> GetList(Expression<Func<Category, bool>> expression = null)
        {
            return _categoryDal.GetList(expression);
        }



    }
}
