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
    public class AuthorManagerService : IAuthorService<Author>
    {
        private ApiContext _context { get; set; }
        public AuthorManagerService(ApiContext ctx)
        {
            this._context = ctx;
        }

        public async Task<StatusCodeResult> Delete(string authorCode)
        {
           var author = await _context.Authors.FirstOrDefaultAsync(x => x.AuthorCode == authorCode);

            if (author == null) { return new StatusCodeResult(404); }

            try
            {
                _context.Authors.Remove(author);
                return new StatusCodeResult(200);
            }
            catch
            {
                return new StatusCodeResult(400);
            }
        }

        public async Task<ActionResult<Author>> FindById(string authorCode)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.AuthorCode == authorCode);

            if (author == null) { return new StatusCodeResult(404); }

            return author;
        }

        public async Task<ActionResult<Author>> FindByName(string name)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.Name == name);

            if (author == null) { return new StatusCodeResult(404); }

            return author;
        }

        public async Task<StatusCodeResult> Save(Author author)
        {
            try
            {
                author.AuthorCode = $"{Guid.NewGuid()}";
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
                return new StatusCodeResult(201);

            }catch
            {
                return new StatusCodeResult(400);
            }
        }

        public async Task<StatusCodeResult> Update(Author author)
        {
            try
            {
                _context.Entry(author).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new StatusCodeResult(200);
            }
            catch
            {
                return new StatusCodeResult(400);
            }
            
        }
    }
}
