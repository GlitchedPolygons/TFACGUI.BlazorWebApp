
function SetInputValue(elementId, newValue, setInnerHtmlInsteadOfValue = false)
{
    const inputElement = document.getElementById(elementId);
    
    if (inputElement)
    {
        if (setInnerHtmlInsteadOfValue)
        {
            inputElement.innerHTML = newValue;
        }
        else
        {
            inputElement.value = newValue;
        }
    }
}