
function Loop() 
{
    postMessage('');
    setTimeout('Loop()',128);
}

Loop();