namespace FitnessTracker.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        public int UserId { get; set; }
        protected virtual User User { get; set; }
        public Exercise() { }
        public Exercise(DateTime start,DateTime finish,Activity activity,User user)
        {
            //TODO: VALIDATION
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }

    }
}
