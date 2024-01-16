
function GetUserDarkThemePreference() 
{
    const localStorageKey = 'DarkTheme';
    
    let darkTheme = localStorage.getItem(localStorageKey);
    
    if (darkTheme === null)
    {
        darkTheme = window.matchMedia('(prefers-color-scheme: dark)').matches;

        localStorage.setItem(localStorageKey, darkTheme);
    }

    return darkTheme !== 'false';
}