﻿namespace Synapse.Worker.Application.Services.Executors;

/// <summary>
/// Represents an <see cref="ITaskExecutor"/> implementation used to execute <see cref="WaitTaskDefinition"/>s
/// </summary>
/// <param name="serviceProvider">The current <see cref="IServiceProvider"/></param>
/// <param name="logger">The service used to perform logging</param>
/// <param name="executionContextFactory">The service used to create <see cref="ITaskExecutionContext"/>s</param>
/// <param name="executorFactory">The service used to create <see cref="ITaskExecutor"/>s</param>
/// <param name="context">The current <see cref="ITaskExecutionContext"/></param>
/// <param name="serializer">The service used to serialize/deserialize objects to/from JSON</param>
public class WaitTaskExecutor(IServiceProvider serviceProvider, ILogger<WaitTaskExecutor> logger, ITaskExecutionContextFactory executionContextFactory, ITaskExecutorFactory executorFactory, ITaskExecutionContext<WaitTaskDefinition> context, IJsonSerializer serializer)
    : TaskExecutor<WaitTaskDefinition>(serviceProvider, logger, executionContextFactory, executorFactory, context, serializer)
{

    /// <summary>
    /// Gets the <see cref="Timer"/> used to wait a specific amount of time
    /// </summary>
    protected virtual Timer? WaitTimer { get; set; }

    /// <inheritdoc/>
    protected override Task DoExecuteAsync(CancellationToken cancellationToken)
    {
        this.WaitTimer = new Timer(async state => await this.OnWaitTimeElapsedAsync(cancellationToken).ConfigureAwait(false), null, this.Task.Definition.Wait.ToTimeSpan(), Timeout.InfiniteTimeSpan);
        return System.Threading.Tasks.Task.CompletedTask;
    }

    /// <summary>
    /// Fires when the specified amount of time has been waited for
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
    /// <returns>A new awaitable <see cref="Task"/></returns>
    protected virtual Task OnWaitTimeElapsedAsync(CancellationToken cancellationToken) => this.SetResultAsync(this.Task.Input, this.Task.Definition.Then, cancellationToken: cancellationToken);

    /// <inheritdoc/>
    protected override async ValueTask DisposeAsync(bool disposing)
    {
        await base.DisposeAsync(disposing).ConfigureAwait(false);
        if (!disposing) return;
        if (this.WaitTimer != null) await this.WaitTimer.DisposeAsync().ConfigureAwait(false);
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (!disposing) return;
        this.WaitTimer?.Dispose();
    }

}
