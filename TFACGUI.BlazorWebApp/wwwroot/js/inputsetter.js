
function SetInputValue(elementId, newValue)
{
    const inputElement = document.getElementById(elementId);
    
    if (inputElement)
    {
        inputElement.value = newValue;
    }
}