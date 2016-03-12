﻿using PocketRitual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebService.API.Query_Objects;


namespace WebService.API
{
    public class CardCategoryController : ApiController
    {
        IPocketRitualDbContext _context { get; }

        public CardCategoryController(IPocketRitualDbContext context)
        {
            if (context == null)
            {
                throw new System.Exception("");
            }

            this._context = context;
        }

        private DateTime TrimDateTime(DateTime input)
        {
            return new DateTime(input.Year, input.Month, input.Day);
        }

        // GET api/<controller>
        public IEnumerable<CardCategory> Get([FromBody] CardCategoryQuery query)
        {
            IQueryable<CardCategory> databaseQuery = _context.CardCategories;

            if (query.CardCategoryId.HasValue)
            {
                databaseQuery = (IQueryable<CardCategory>)_context.CardCategoryService.GetCardCategorysById((int)query.CardCategoryId);
                    //databaseQuery.Where(x => x.CardCategoryId == query.CardCategoryId.Value);
            }

            if (query.CardCategoryName != null)
            {
                databaseQuery = (IQueryable<CardCategory>)_context.CardCategoryService.GetCardCategorysByName(query.CardCategoryName);
                //databaseQuery.Where(x => x.Name == query.CardCategoryName);
            }

            /*
            if (query.CreatedDate.HasValue)
            {
                //Don't compare time portion
                var creatDateValue = query.CreatedDate.Value;
                databaseQuery = databaseQuery.Where(x => x.CreatedDate.Day == creatDateValue.Day && x.CreatedDate.Month == creatDateValue.Month && x.CreatedDate.Year == creatDateValue.Year);
            }
             */

            return databaseQuery;
        }

        // POST api/<controller>
        public void Post([FromBody] CardCategory journey)
        {
            _context.CardCategories.Add(journey);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] CardCategory value)
        {
            var result = _context.CardCategories.SingleOrDefault(x => x.CardCategoryId == id);
            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
            result.Name = value.Name;
            result.Description = value.Description;

            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var toRemove = this.Get(new CardCategoryQuery() { CardCategoryId = id }).SingleOrDefault();

            if (toRemove == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.CardCategories.Remove(toRemove);
        }
    }
}