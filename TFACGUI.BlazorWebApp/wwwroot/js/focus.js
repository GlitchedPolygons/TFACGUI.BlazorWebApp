
function IsDocumentHidden() 
{
    return document.hidden;
}

document.addEventListener("visibilitychange", () => {
    console.log(document.hidden);
    DotNet.invokeMethodAsync('TFACGUI.BlazorWebApp', 'OnChangeVisibilityState', document.hidden)
});