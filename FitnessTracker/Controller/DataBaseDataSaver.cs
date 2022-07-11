namespace FitnessTracker.BL.Controller
{
    public class DataBaseDataSaver : IDataSaver
    { 
        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessContext() )
            {
                return (db.Set<T>().Where(x => true).ToList());
                
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}
