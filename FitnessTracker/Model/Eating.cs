﻿
using System;

namespace FitnessTracker.BL.Model
{
    /// <summary>
    /// приём пищи
    /// </summary>
    [Serializable]
    public class Eating
    {
        public DateTime Moment { get;  }
        public Dictionary<Food,double> Foods { get; }
        public User User { get;  }
        public Eating(User user)
        {
            User = user??throw new ArgumentNullException("Пользователя не может быть null",nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food,double>();
        }

        public void Add(Food food,double weight)
        {
            
            var product = Foods.Keys.FirstOrDefault(f=>f.Name.Equals(food.Name));
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