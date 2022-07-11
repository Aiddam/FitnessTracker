using FitnessTracker.BL.Model;
namespace FitnessTracker.BL.Controller
{
    public class EatingController : ControllerBase
    {
        
        private readonly User user;
        public List<Food> Foods { get; set; }
        public Eating Eating { get; set; }    

        public EatingController(User user)
        {
            this.user = user ??throw new ArgumentNullException("Пользователь не может быть равен null!",
                                                                nameof(user));
            Foods = GetAllFoods();
            Eating = GetEatings();
        }

       
        public void Add(Food food,double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if(product ==null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
            }
            else
            {
                Eating.Add(product, weight);
            }
            Save();
        }
        private Eating GetEatings()
        {

            return Load<Eating>().FirstOrDefault() ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<Food>()??new List<Food>();
        }
        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            //var saveFoods = new List<Food>() { Foods}
            //var saveActivity =
            Save(Foods);
            Save(new List<Eating>() { Eating });
        }
    }
}
