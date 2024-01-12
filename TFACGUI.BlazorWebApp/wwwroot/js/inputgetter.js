
function GetInputValue(elementId, defaultValue)
{
    const inputElement = document.getElementById(elementId);
    
    if (!inputElement)
    {
        return defaultValue;
    }
    
    return inputElement.value;
}