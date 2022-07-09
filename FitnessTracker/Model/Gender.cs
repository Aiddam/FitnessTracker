using System;


namespace Fitness_Tracker.BL.Model
{
    /// <summary>
    ///     Пол
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Название_гендера
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Конструктор названия пола
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null!");
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
