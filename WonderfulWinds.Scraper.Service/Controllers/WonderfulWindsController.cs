using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using WonderfulWinds.Scraper.Model.Entities;
using WonderfulWinds.Scraper.Repository;
using WonderfulWinds.Scraper.Service.Messages;

namespace WonderfulWinds.Scraper.Service.Controllers
{
    [RoutePrefix("api/v1")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WonderfulWindsController : ApiController
    {
        private static WonderfulWIndsRepository repo = new WonderfulWIndsRepository();



        [HttpGet]
        [Route("mc")]
        public GetMenuItemCountResponse GetMenuItemCount()
        {
            return new GetMenuItemCountResponse()
            {
                Count = repo.GetMenuItemCount(),
                StatusCode = 0,
                StatusText = "Success"
            };
        }

        [HttpGet]
        [Route("me")]
        public GetMenuItemsResponse GetMenuItems()
        {
            var it = repo.GetMenuItems();
            if (it == null)
            {
                return new GetMenuItemsResponse()
                {
                    Items = null,
                    StatusCode = -1,
                    StatusText = "Not ready or could not locate WonderfulWinds"
                };

            }
            else
            {
                return new GetMenuItemsResponse()
                {
                    Items = it,
                    StatusCode = 0,
                    StatusText = "Success"
                };
            }
        }

       

        [HttpGet]
        [Route("mi")]
        public GetMenuItemResponse GetMenuItemByIndex([FromUri]int index)
        {
            var it = repo.GetMenuItem(index);
            if (it == null)
            {
                return new GetMenuItemResponse()
                {
                    Item = null,
                    StatusCode = -1,
                    StatusText = "Not ready or could not locate WonderfulWinds"
                };

            }
            else
            {
                return new GetMenuItemResponse()
                {
                    Item = it,
                    StatusCode = 0,
                    StatusText = "Success"
                };
            }
        }
    }
}
