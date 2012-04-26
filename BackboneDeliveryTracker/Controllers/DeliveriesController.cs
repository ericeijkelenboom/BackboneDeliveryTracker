using System.Linq;
using System.Net;
using System.Web.Http;
using BackboneDeliveryTracker.Models;

namespace BackboneDeliveryTracker.Controllers
{
    public class DeliveriesController : ApiController
    {
        private readonly AppDbContext _dbContext;

        public DeliveriesController()
        {
            _dbContext = new AppDbContext();
            _dbContext.Configuration.ProxyCreationEnabled = false;
        }

        // GET /api/deliveries
        public IQueryable<Delivery> GetDeliveriesForToday()
        {
            return _dbContext.Deliveries.Include("Customer").OrderBy(d => d.DeliveryId);
        }

        // GET /api/deliveries/5
        public Delivery Get(int id)
        {
            Delivery delivery = _dbContext.Deliveries.Find(id);
            if (delivery == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return delivery;
        }

        // POST /api/deliveries
        public void Post(Delivery delivery)
        {
            _dbContext.Deliveries.Add(delivery);
            _dbContext.SaveChanges();
        }

        // PUT /api/deliveries/5
        public void Put(int id, Delivery delivery)
        {
            Delivery existingDelivery = _dbContext.Deliveries.Find(id);
            if (existingDelivery == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            existingDelivery.Description = delivery.Description;
            existingDelivery.IsDelivered = delivery.IsDelivered;
        }

        // DELETE /api/deliveries/5
        public void Delete(int id)
        {
            Delivery existingDelivery = _dbContext.Deliveries.FirstOrDefault(d => d.DeliveryId == id);
            if (existingDelivery == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dbContext.Deliveries.Remove(existingDelivery);
        }
    }
}