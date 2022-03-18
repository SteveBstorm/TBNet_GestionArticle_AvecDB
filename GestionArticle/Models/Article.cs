namespace GestionArticle.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private decimal price;

        public decimal Price
        {
            get { return (price * (decimal)1.21); }
            set { price = value; }
        }

        
        public string EAN13 { get; set; }
        public string Description { get; set; }
    }
}
