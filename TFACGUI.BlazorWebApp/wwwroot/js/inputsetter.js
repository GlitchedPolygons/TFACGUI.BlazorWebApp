
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

function SetRadioBoxValue(radioBoxName, newValue)
{
    const radioBox = document.querySelector(`input[name='${radioBoxName}'][value='${newValue}']`);

    if (!radioBox)
    {
        return;
    }

    radioBox.checked = true;
}