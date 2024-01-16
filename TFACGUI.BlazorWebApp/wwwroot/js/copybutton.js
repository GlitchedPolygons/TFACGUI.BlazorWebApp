
function InitCopyButtonLabel(buttonElementId)
{
    const copyButton = document.getElementById(buttonElementId);
    const defaultLabelCopyButton = copyButton.innerHTML;

    copyButton.addEventListener('click', () =>
    {
        copyButton.innerHTML = 'Copied...';

        setTimeout(() => copyButton.innerHTML = defaultLabelCopyButton, 1337);
    });
}

function PressCopyButtonPortable(buttonElementId, customTempText = 'Copied...', customRevertToText = 'Copy')
{
    const copyButton = document.getElementById(buttonElementId);
    
    if (!copyButton)
    {
        return;
    }

    copyButton.innerHTML = customTempText; 
    
    setTimeout(() => copyButton.innerHTML = customRevertToText, 1337);
}