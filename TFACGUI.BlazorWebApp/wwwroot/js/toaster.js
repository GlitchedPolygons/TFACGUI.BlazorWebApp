
function ShowToast(toastElementId)
{
    const toast = document.getElementById(toastElementId);
    const bootstrapToast = new bootstrap.Toast(toast);
    bootstrapToast.show();
}