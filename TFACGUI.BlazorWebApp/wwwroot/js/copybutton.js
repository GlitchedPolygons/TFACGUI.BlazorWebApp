
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

function PressCopyButtonPortable(buttonElementId)
{
    const copyButton = document.getElementById(buttonElementId);
    
    if (!copyButton)
    {
        return;
    }

    copyButton.innerHTML = 'Done...'; 
    setTimeout(() => copyButton.innerHTML = 'Copy', 1337);
}