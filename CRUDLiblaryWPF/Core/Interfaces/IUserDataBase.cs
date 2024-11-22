using CRUDLiblaryWPF.Core.Entities;

namespace CRUDLiblaryWPF.Core.Interfaces;

public interface IUserDataBase
{
    public List<User> Get();
    public User GetUserById(int Id);
    public void AddUSer(User user);
    public void UpdateUser(int id, User newUser);
}