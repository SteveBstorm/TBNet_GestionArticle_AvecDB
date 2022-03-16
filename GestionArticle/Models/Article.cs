namespace GestionArticle.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private double price;

        public double Price
        {
            get { return price * 1.21; }
            set { price = value; }
        }

        
        public string EAN13 { get; set; }
        public string Description { get; set; }
    }
}
