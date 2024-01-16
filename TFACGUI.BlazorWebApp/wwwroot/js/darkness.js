
function GetUserDarkThemePreference() 
{
    const darkTheme = localStorage.getItem('DarkTheme');
    
    if (darkTheme)
    {
        return darkTheme.toLowerCase() !== false;
    }
    
    return window.matchMedia('(prefers-color-scheme: dark)').matches;
}