using Books.BooksApi.Data;
using Books.BooksApi.Enums;
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
    public class BooksManagerService : IBooksManagerService
    {
        private delegate Task<ActionResult<Book>> FindBookPerAnithingType(string data);

        private readonly ApiContext _ctx;

        public BooksManagerService(ApiContext ctx) { this._ctx = ctx; }

        public async Task<StatusCodeResult> Delete(Guid eanCode)
        {
             var bookObject = await _ctx.Books.FirstOrDefaultAsync(x => Guid.Parse(x.EANCode) == eanCode);
             if (bookObject == null) { return new StatusCodeResult(404); }
             
             try
             {
                 _ctx.Books.Remove(bookObject);
                 var result = _ctx.SaveChanges();
                return new StatusCodeResult(200);

             }
             catch (Exception ex)
             {
                 return new StatusCodeResult(400);
             }
        }

        public async Task<ActionResult<Book>> FindByEanCode(string eanCode)
        {
            var bookObject = await _ctx.Books.FirstOrDefaultAsync(x => x.EANCode == eanCode);
            if (bookObject == null) { return new StatusCodeResult(404); }

            try
            {
                return bookObject;
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(400);
            }
        }

        public async Task<ActionResult<Book>> FindById(int bookId)
        {
            var bookObject = await _ctx.Books.FirstOrDefaultAsync(x => x.BookId == bookId);
            if (bookObject == null) { return new StatusCodeResult(404); }

            try
            {
                return bookObject;
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(400);
            }
        }

        public async Task<ActionResult<Book>> FindByTitle(string title)
        {
            var bookObject = await _ctx.Books.FirstOrDefaultAsync(x => x.Title == title);
            if (bookObject == null) { return new StatusCodeResult(404); }

            try
            {
                return bookObject;
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(400);
            }
        }


        public async Task<ActionResult<Book>> Find(string data, int typeQuery)
        {
            var dictionaryTypes = new Dictionary<int, FindBookPerAnithingType>();
            dictionaryTypes.Add((int)QueryType.title,  (data) => FindByTitle(data));
            dictionaryTypes.Add((int)QueryType.ean_code, (data) => FindByEanCode(data));
            
            return await dictionaryTypes[typeQuery].Invoke(data);
        }

        public async Task<StatusCodeResult> Save(Book book)
        {
            book.EANCode = $"{Guid.NewGuid()}";

            try
            {
                _ctx.Books.Add(book);
                await _ctx.SaveChangesAsync();
                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(400);
            }
        }

        public async Task<StatusCodeResult> Update(Book book)
        {
            try
            {
                _ctx.Entry(book).State = EntityState.Modified;
                await _ctx.SaveChangesAsync();
                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(400);
            }
        }
    }
}
