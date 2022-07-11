﻿using FitnessTracker.BL.Model;
namespace FitnessTracker.BL.Controller
{
    public class ExerciseController:ControllerBase
    {
        private readonly User user;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }
        public ExerciseController(User user )
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercise();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        public void Add(Activity activity,DateTime begin,DateTime end)
        {
            var act = Activities.SingleOrDefault(a=>a.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, end,activity,user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
            }
            Save();
        }
        private List<Exercise> GetAllExercise()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }
        private void Save()
        {
            Save(Exercises);
            Save(Activities);
        }
    }
}
