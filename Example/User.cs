using System;
using System.Runtime.Intrinsics.X86;

namespace Example;
public interface IUser
{
    string UserName { get; set; }
    string Password { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    bool IsActive { get; set; }
    string IdentityNo { get; set; }
}


public abstract class User:IUser
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IdentityNo { get; set; }
    public User() { }
    public User(string userName, string password,bool isActive, string identityNo) {
        UserName = userName;
        Password = password;
        IsActive = isActive;
        IdentityNo = identityNo;
    }

}

public enum UserTypeEnum
{
    Personal,
    Student,
    Jobber
}
public static class UserFactory
{
    public static IUser GetInstance(UserTypeEnum userType)
    {
        if(userType==UserTypeEnum.Personal)
            return new Personal();
        if (userType == UserTypeEnum.Student)
            return new Student();
        return new Jobber();
    }
}