namespace Flightmanagementsystem.BasicFolderClass
{
    public class LoginToken<T> : ILoginToken where T : IUser
    {
        private T user;

        public T GetUser()
        {
            return user;
        }

        public void SetUser(T value)
        {
            user = value;
        }
    }
}
