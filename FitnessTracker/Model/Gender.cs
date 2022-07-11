namespace FitnessTracker.BL.Model
{
    /// <summary>
    ///     Пол
    /// </summary>
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        /// <summary>
        /// Название_гендера
        /// </summary>
        public string Name { get; set; }
        protected virtual ICollection<User> Users { get; set; }
        /// <summary>
        /// Конструктор названия пола
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Gender() { }
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
