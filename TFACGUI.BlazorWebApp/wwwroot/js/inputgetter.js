
function GetInputValue(elementId, defaultValue)
{
    const inputElement = document.getElementById(elementId);
    
    if (!inputElement)
    {
        return defaultValue;
    }
    
    return inputElement.value;
}

function GetRadioBoxValue(radioBoxName, defaultValue)
{
    const radioBox = document.querySelector(`input[name=${radioBoxName}]:checked`);
    
    if (!radioBox)
    {
        return defaultValue;
    }
    
    return radioBox.value;
}