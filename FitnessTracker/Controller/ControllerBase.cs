namespace FitnessTracker.BL.Controller
{
    public abstract class ControllerBase
    {
        /// <summary>
        /// интерфейс для разных сохранений
        /// </summary>
        protected readonly IDataSaver manager = new DataBaseDataSaver();

        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }
        protected  List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }

    }
}
