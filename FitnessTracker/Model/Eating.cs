namespace FitnessTracker.BL.Model
{
    /// <summary>
    /// приём пищи
    /// </summary>
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }
        public DateTime Moment { get; set; }
        public Dictionary<Food,double> Foods { get; set; }
        public int UserId { get; set; }
        protected virtual User User { get; set; }
        public Eating() { }
        public Eating(User user)
        {
            User = user??throw new ArgumentNullException("Пользователя не может быть null",nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food,double>();
        }

        public void Add(Food food,double weight)
        {
            
            var product = Foods.Keys.FirstOrDefault(f=>f.Name.Equals(food.Name)) ;
            if (product == null)
            {
                Foods.Add (food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
        
    }
}
