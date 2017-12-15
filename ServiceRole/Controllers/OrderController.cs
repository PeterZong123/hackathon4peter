using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using Microsoft.WindowsAzure.Storage.Table;
using ServiceRole.Entities;
using ServiceRole.Models;

namespace ServiceRole.Controllers
{
    public class OrderController : ApiController
    {
        [HttpGet]
        [Route("api/order/{orderId}")]
        [ResponseType(typeof(Order))]
        public IHttpActionResult GetOrderById(int orderId)
        {
            var connectionString = ConfigurationManager.AppSettings["StorageTableConnectionString"];
            var cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = cloudStorageAccount.CreateCloudTableClient();
            tableClient.DefaultRequestOptions.RetryPolicy = new ExponentialRetry(TimeSpan.FromMilliseconds(100), 5);
            var cloudTable = tableClient.GetTableReference("Order");

            var orderEntities =
                cloudTable.CreateQuery<OrderEntity>()
                    .Where(x => x.RowKey.Equals(orderId.ToString(), StringComparison.InvariantCultureIgnoreCase));

            var order = orderEntities.FirstOrDefault().ToDTO();
            return Ok(order);
        }

        [HttpGet]
        [Route("api/order")]
        [ResponseType(typeof(List<Order>))]
        public IHttpActionResult GetAllOrders()
        {
            var connectionString = ConfigurationManager.AppSettings["StorageTableConnectionString"];
            var cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = cloudStorageAccount.CreateCloudTableClient();
            tableClient.DefaultRequestOptions.RetryPolicy = new ExponentialRetry(TimeSpan.FromMilliseconds(100), 5);
            var cloudTable = tableClient.GetTableReference("Order");

            var orderEntities =
                cloudTable.CreateQuery<OrderEntity>();

            var orders = new List<Order>();

            foreach (var entity in orderEntities)
            {
                orders.Add(entity.ToDTO());
            }
            return Ok(orders);
        }
    }
}
