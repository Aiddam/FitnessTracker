using System;


namespace FitnessTracker.BL.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// имя продукта
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// белки
        /// </summary>
        public double Proteins  { get;  }
        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get;  }
        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrats { get;  }
        /// <summary>
        /// Калории за 100 грам продукта
        /// </summary>
        public double Calories { get; }
        

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
