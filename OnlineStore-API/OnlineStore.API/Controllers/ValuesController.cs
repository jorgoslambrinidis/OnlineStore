using Entities;
using OnlineStore.API.Models.ViewModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineStore.API.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        private readonly IItemService _itemService;

        public ValuesController(IItemService itemService)
        {
            _itemService = itemService;
        }

        // GET api/items
        //[Authorize]
        [HttpGet]
        [ActionName("Items")]
        public IEnumerable<Item> Get()
        {
            var items = _itemService.GetItems();

            return items;
        }

        // GET api/values/5
        [HttpGet]
        [ActionName("Items")]
        public Item Get(int id)
        {
            var item = _itemService.GetItemById(id);
            return item;
        }

        // GET api/values/reserved/
        [HttpGet]
        [ActionName("Reserved")]
        public IEnumerable<Item> GetReserved()
        {
            var reservedItems = _itemService.GetReservedItems();
            return reservedItems;
        }

        // POST api/values
        [HttpPost]
        [AllowAnonymous]
        [ActionName("Create")]
        //public HttpResponseMessage CreateItem(string Name, double Price, string Description, bool IsReserved, int NumberOfItems, DateTime Date)
        public HttpResponseMessage CreateItem([FromBody]ItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                // create new item
                var item = new Item()
                {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    IsReserved = model.IsReserved,
                    NumberOfItems = model.NumberOfItems,
                    Date = DateTime.Now
                };

                // add item in db
                _itemService.AddItem(item);

                // return response
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, item);
                response.Headers.Location = new Uri(Url.Link("ReservedItems", new { id = item.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


        [HttpPost]
        [ActionName("Reserve")]
        public HttpResponseMessage ReserveItem([FromBody]int id)
        {
            var reservedItem = _itemService.GetItemById(id);

            reservedItem.IsReserved = true;
            reservedItem.NumberOfItems = reservedItem.NumberOfItems - 1;

            _itemService.EditItem(reservedItem);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, reservedItem);
            return response;
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        [ActionName("Delete")]
        public void Delete(int id)
        {
        }
    }
}
