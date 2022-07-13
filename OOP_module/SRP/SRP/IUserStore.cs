namespace SRP
{
    public interface IUserStore
    {
        User FindUserByName(string name);
    }
}
