using TaskManagement.Repository.Repo;

namespace TaskManagement.Repository
{
    public static class DataRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var didictionary = new Dictionary<Type, Type>()
            {
                {typeof(ILogin), typeof(LoginRepo)},
                {typeof(ITaskRepo),typeof(TaskRepo)},
            };
            return didictionary;
        }
    }
}
