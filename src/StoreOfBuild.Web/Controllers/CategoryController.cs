﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Web.Models;
using StoreOfBuild.Web.ViewsModels;

namespace StoreOfBuild.Web.Controllers {
    [Authorize(Roles= "Admin, Manager")]
    public class CategoryController : Controller {
        private readonly CategoryStorer _categoryStorer;
        public readonly IRepository<Category> _categoryRepository;

        public CategoryController (CategoryStorer categoryStorer, IRepository<Category> categoryRepository) {
            _categoryStorer = categoryStorer;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index () {
            var categories = _categoryRepository.All ();

            var viewModels = categories.Select (c => new CategoryViewModel { Id = c.Id, Name = c.Name });

            return View (viewModels);
        }

        [HttpGet]
        public IActionResult CreateOrEdit (int id) {
            if (id > 0) {
                var category = _categoryRepository.GetById (id);
                var categoryViewModel = new CategoryViewModel { Id = category.Id, Name = category.Name };
                return View (categoryViewModel);
            } 
            else
                return View ();
        }

        [HttpPost]
        public IActionResult CreateOrEdit (CategoryViewModel viewModel) {

            if (!string.IsNullOrEmpty (viewModel.Name))
                _categoryStorer.Store (viewModel.Id, viewModel.Name);

            return View ();
        }

    }
}