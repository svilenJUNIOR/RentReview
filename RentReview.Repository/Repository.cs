using RentReview.Data;
using RentReview.Data.Models;
using RentReview.Repository.Contracts;

namespace RentReview.Repository
{
    public class Repository : IRepository
    {
        private readonly RentDbContext context;

        public Repository(RentDbContext context) => this.context = context;

        public Property FindPropertyByReviewId(string ReviewId)
        {
            var review = this.context.Reviews.Where(x => x.Id == ReviewId).FirstOrDefault();
            var property = this.context.Properties.Where(x => x.Id == review.PropertyId).FirstOrDefault();

            return property;
        }

        public Review FindReviewByPropertyId(string PropertyId)
        => this.context.Reviews.Where(x => x.PropertyId == PropertyId).FirstOrDefault();

        public async Task AddAsync<T>(T newItem) where T : class
         => await this.context.Set<T>().AddAsync(newItem);

        public T FindById<T>(string Id) where T : class
         => this.context.Find<T>(Id);
        public IQueryable<T> GettAll<T>() where T : class
        => this.context.Set<T>();

        public void Remove<T>(T Item) where T : class
        => this.context.Set<T>().Remove(Item);

        public async Task SaveChangesAsync()
        => await this.context.SaveChangesAsync();

        public string ReturnReviewId(string propertyId)
        {
            var review = this.FindReviewByPropertyId(propertyId);

            if (review == null)
                return "null";

            return review.Id;
        }

        public void Update<T>(T item) where T : class
        => this.context.Set<T>().Update(item);
      
        public async Task AddRangeAsync<T>(List<T> items) where T : class
         => await this.context.Set<T>().AddRangeAsync(items);
    }
}
