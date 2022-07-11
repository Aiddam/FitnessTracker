namespace FitnessTracker.BL.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        /// <summary>
        /// имя продукта
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// белки
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrats { get; set; }
        /// <summary>
        /// Калории за 100 грам продукта
        /// </summary>
        public double Calories { get; set; }

        public virtual ICollection<Eating> Eatings { get; set; }

        public Food() { }
        public Food(string name) :this(name,0,0,0,0)  {}
        public Food(string name,double calories,double proteins,double fats,double carbohydrats)
        {
            //TODO: Проверка
            Name = name;
            Calories = calories/100.0;
            Proteins = proteins/100.0;
            Fats = fats/100.0;
            Carbohydrats = carbohydrats/100.0;

        }
        public override string ToString()
        {
            return Name; 
        }

    }
}
