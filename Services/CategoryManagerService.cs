using Books.BooksApi.Data;
using Books.BooksApi.Interfaces;
using Books.BooksApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.BooksApi.Services
{
    public class CategoryManagerService : ICategoryService<Category>
    {
        private ApiContext _context { get; set; }
        public CategoryManagerService(ApiContext ctx)
        {
            this._context = ctx;
        }

        public async Task<StatusCodeResult> Delete(string categoryCode)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryCode == categoryCode);

            if (category == null) { return new StatusCodeResult(404); }

            try
            {
                _context.Categories.Remove(category);
                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(400);
            }
        }

        public async Task<ActionResult<Category>> FindById(string categoryCode)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryCode == categoryCode);

            if (category == null) { return new StatusCodeResult(404); }

            return category;
        }

        public async Task<ActionResult<Category>> FindByName(string name)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Name == name);

            if (category == null) { return new StatusCodeResult(404); }

            return category;
        }

        public async Task<StatusCodeResult> Save(Category category)
        {
            try
            {
                category.CategoryCode = $"{Guid.NewGuid()}";
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return new StatusCodeResult(200);

            }
            catch (Exception ex)
            {
                return new StatusCodeResult(400);
            }
        }

        public async Task<StatusCodeResult> Update(Category category)
        {
            try
            {
                _context.Entry(category).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(400);
            }

        }
    }
}
