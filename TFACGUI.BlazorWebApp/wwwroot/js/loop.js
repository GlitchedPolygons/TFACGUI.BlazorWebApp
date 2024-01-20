let loopWorker = undefined;

function WorkerAvailable()
{
    return typeof(Worker) !== 'undefined';
}

function StartLoopWorker() 
{
    if (WorkerAvailable()) 
    {
        if (typeof(loopWorker) == 'undefined') 
        {
            loopWorker = new Worker('js/loopworker.js');
        }
        
        loopWorker.onmessage = function (event) 
        {
            DotNet.invokeMethodAsync('TFACGUI.BlazorWebApp', 'OnLoopCycleWorkerCallback', '');
        };
    } 
    else 
    {
        console.error('Sorry, your browser does not support web workers... Please use a browser that does in order to make full use of TFACGUI!');
    }
}

function StopLoopWorker() 
{
    if (loopWorker)
    {
        loopWorker.terminate();
        loopWorker = undefined;
    }
}