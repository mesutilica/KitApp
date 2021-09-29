﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KitApp.Core.Entities;
using KitApp.WebAPI.Data;
using KitApp.Core.Services;

namespace KitApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _context;

        public BooksController(IBookService context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.GetAllAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            try
            {
                _context.Update(book);
            }
            catch
            {
                return Problem("Hata Oluştu!");
            }
            return NoContent();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            await _context.AddAsync(book);

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}