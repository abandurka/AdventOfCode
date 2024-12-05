using System.Runtime.CompilerServices;

namespace AOC.Shared;

public static class PipeExtensions
{
    /// <summary>
    /// Pass input to func and return the result.
    /// </summary>
    /// <typeparam name="TParam">Parameter type.</typeparam>
    /// <typeparam name="TOutput">The type asyncFunc returns</typeparam>
    /// <param name="input">The object passed to func.</param>
    /// <param name="func">The function to call which operates on input.</param>
    /// <returns>An object of type U</returns>
    // [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public static TOutput Pipe<TParam, TOutput>(this TParam input, Func<TParam, TOutput> func)
        => func(input);

    /// <summary>
    /// Pass input to asyncFunc and return the result.
    /// </summary>
    /// <typeparam name="TParam">Parameter type.</typeparam>
    /// <typeparam name="TOutput">The type asyncFunc returns</typeparam>
    /// <param name="input">The object passed to func.</param>
    /// <param name="asyncFunc">The function to call which operates on T.</param>
    /// <returns>An object of type U wrapped in a Task</returns>
    public static Task<TOutput> PipeAsync<TParam, TOutput>(this TParam input, Func<TParam, Task<TOutput>> asyncFunc)
        => asyncFunc(input);

    /// <summary>
    /// Pass input and cancellationToken to asyncFunc and return the result.
    /// </summary>
    /// <typeparam name="TParam">Parameter type.</typeparam>
    /// <typeparam name="TOutput">The type asyncFunc returns</typeparam>
    /// <param name="input">The object passed to func.</param>
    /// <param name="asyncFunc">The function to call which operates on T.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>An object of type U wrapped in a Task</returns>
    public static Task<TOutput> PipeAsync<TParam, TOutput>(this TParam input, Func<TParam, CancellationToken, Task<TOutput>> asyncFunc, CancellationToken cancellationToken = default)
        => asyncFunc(input, cancellationToken);

    /// <summary>
    /// Await inputTask, pass it to func, and return the result.
    /// </summary>
    /// <typeparam name="TParam">Parameter type.</typeparam>
    /// <typeparam name="TOutput">The type asyncFunc returns</typeparam>
    /// <param name="inputTask">The object you're operating on wrapped in a Task.</param>
    /// <param name="func">The function to call which operates on input.</param>
    /// <returns>An object of type U wrapped in a Task</returns>
    public static async Task<TOutput> PipeAsync<TParam, TOutput>(this Task<TParam> inputTask, Func<TParam, TOutput> func)
        => func(await inputTask);

    /// <summary>
    /// Await inputTask, pass it to asyncFunc, and return the result.
    /// </summary>
    /// <typeparam name="TParam">Parameter type.</typeparam>
    /// <typeparam name="TOutput">The type asyncFunc returns</typeparam>
    /// <param name="inputTask">The object you're operating on wrapped in a Task.</param>
    /// <param name="asyncFunc">The function to call which operates on T.</param>
    /// <returns>An object of type U wrapped in a Task</returns>
    public static async Task<TOutput> PipeAsync<TParam, TOutput>(this Task<TParam> inputTask, Func<TParam, Task<TOutput>> asyncFunc)
        => await asyncFunc(await inputTask);

    /// <summary>
    /// Await inputTask, pass it and the cancellationToken to asyncFunc, and return the result.
    /// </summary>
    /// <typeparam name="TParam">Parameter type.</typeparam>
    /// <typeparam name="TOutput">The type asyncFunc returns</typeparam>
    /// <param name="inputTask">The object you're operating on wrapped in a Task.</param>
    /// <param name="asyncFunc">The function to call which operates on T.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>An object of type U wrapped in a Task</returns>
    public static async Task<TOutput> PipeAsync<TParam, TOutput>(this Task<TParam> inputTask, Func<TParam, CancellationToken, Task<TOutput>> asyncFunc, CancellationToken cancellationToken = default)
        => await asyncFunc(await inputTask, cancellationToken);
}