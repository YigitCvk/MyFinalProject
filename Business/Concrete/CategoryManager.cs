﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            //Seelect*from categories where cateagoryId=3
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }

        List<Category> ICategoryService.GetById(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
