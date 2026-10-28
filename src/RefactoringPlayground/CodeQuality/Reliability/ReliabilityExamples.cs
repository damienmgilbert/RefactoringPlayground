namespace RefactoringPlayground.CodeQuality.Reliability;

public static class ReliabilityExamples
{
    // REFACTOR [CA2007]: Consider calling ConfigureAwait on the awaited task
    public static async Task WaitAsync()
    {
        await Task.Delay(1);
    }

    // REFACTOR [CA2016]: Forward the 'CancellationToken' parameter to methods that take one
    public static async Task WaitWithTokenAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(100);
        cancellationToken.ThrowIfCancellationRequested();
    }

    // REFACTOR [CA2008]: Do not create tasks without passing a TaskScheduler
    public static Task<int> Compute()
    {
        return Task.Factory.StartNew(() => 42);
    }

    // REFACTOR [CA2013]: Do not use 'ReferenceEquals' with value types
    public static bool SameInt(int a, int b)
    {
        return ReferenceEquals(a, b);
    }
}
