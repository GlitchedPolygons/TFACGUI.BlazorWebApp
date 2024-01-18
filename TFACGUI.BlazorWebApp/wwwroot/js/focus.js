
function IsDocumentHidden() 
{
    return document.hidden;
}

document.addEventListener("visibilitychange", () => 
{
    DotNet.invokeMethodAsync('TFACGUI.BlazorWebApp', 'OnChangeVisibilityState', document.hidden)
});