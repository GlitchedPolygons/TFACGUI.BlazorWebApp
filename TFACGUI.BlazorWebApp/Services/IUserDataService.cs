using TFACGUI.BlazorWebApp.Models;

namespace TFACGUI.BlazorWebApp.Services;

public interface IUserDataService
{
    ValueTask<string> GetUserDataPlaintext();
    ValueTask SetUserDataPlaintext(string userDataPlaintext);

    ValueTask<UserData> GetUserData();
    ValueTask SetUserData(UserData userData);
}