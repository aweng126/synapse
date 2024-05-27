﻿using Synapse.Resources;

namespace Synapse.Operator.Application.Services;

/// <summary>
/// Represents the service used to manage the scheduling and execution of a specific <see cref="Workflow"/>
/// </summary>
/// <param name="logger">The service used to perform logging</param>
/// <param name="resources">The service used to manage resources</param>
/// <param name="resource">The resource of the workflow to manage the scheduling of</param>
/// <param name="definition">The definition of the workflow to manage the scheduling of</param>
public class WorkflowScheduler(ILogger<WorkflowScheduler> logger, IResourceRepository resources, Workflow resource, WorkflowDefinition definition)
    : IDisposable, IAsyncDisposable
{

    bool _disposed;

    /// <summary>
    /// Gets the service used to perform logging
    /// </summary>
    protected ILogger Logger { get; } = logger;

    /// <summary>
    /// Gets the service used to manage resources
    /// </summary>
    protected IResourceRepository Resources { get; } = resources;

    /// <summary>
    /// Gets the resource of the workflow to manage the scheduling of
    /// </summary>
    protected Workflow Resource { get; } = resource;

    /// <summary>
    /// Gets the definition of the workflow to manage the scheduling of
    /// </summary>
    protected WorkflowDefinition Definition { get; } = definition;

    /// <summary>
    /// Schedules the execution of the workflow
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
    /// <returns>A new awaitable <see cref="Task"/></returns>
    public virtual async Task ScheduleAsync(CancellationToken cancellationToken = default)
    {
        //todo
    }

    /// <summary>
    /// Disposes of the <see cref="WorkflowScheduler"/>
    /// </summary>
    /// <param name="disposing">A boolean indicating whether or not the <see cref="WorkflowScheduler"/> is being disposed of</param>
    /// <returns>A new awaitable <see cref="ValueTask"/></returns>
    protected virtual async ValueTask DisposeAsync(bool disposing)
    {
        if (!this._disposed) return;
        this._disposed = true;
        await Task.CompletedTask.ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async ValueTask DisposeAsync()
    {
        await this.DisposeAsync(true).ConfigureAwait(false);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes of the <see cref="WorkflowScheduler"/>
    /// </summary>
    /// <param name="disposing">A boolean indicating whether or not the <see cref="WorkflowScheduler"/> is being disposed of</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed) return;

        this._disposed = true;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

}
