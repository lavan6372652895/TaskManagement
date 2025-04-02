using TaskManagement.Manager.CommonMethods;
using TaskManagement.Manager.Manager;

namespace TaskManagement.Manager
{
    public static class ServicesRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dictionary = new Dictionary<Type, Type>()
            {
                { typeof(IJwt),typeof(JwtServices) },
                {typeof(ILoginmanager),typeof(Loginmanager) },
                {typeof(ITaskManager),typeof(TaskManager) },

            };
            return dictionary;
        }

    }
}
