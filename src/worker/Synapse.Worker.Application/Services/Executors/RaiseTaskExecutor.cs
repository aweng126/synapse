﻿using Neuroglia.Data.Expressions;

namespace Synapse.Worker.Application.Services.Executors;

/// <summary>
/// Represents an <see cref="ITaskExecutor"/> implementation used to execute <see cref="RaiseTaskDefinition"/>s
/// </summary>
/// <param name="serviceProvider">The current <see cref="IServiceProvider"/></param>
/// <param name="logger">The service used to perform logging</param>
/// <param name="executionContextFactory">The service used to create <see cref="ITaskExecutionContext"/>s</param>
/// <param name="executorFactory">The service used to create <see cref="ITaskExecutor"/>s</param>
/// <param name="context">The current <see cref="ITaskExecutionContext"/></param>
/// <param name="serializer">The service used to serialize/deserialize objects to/from JSON</param>
public class RaiseTaskExecutor(IServiceProvider serviceProvider, ILogger<RaiseTaskExecutor> logger, ITaskExecutionContextFactory executionContextFactory, ITaskExecutorFactory executorFactory, ITaskExecutionContext<RaiseTaskDefinition> context, IJsonSerializer serializer)
    : TaskExecutor<RaiseTaskDefinition>(serviceProvider, logger, executionContextFactory, executorFactory, context, serializer)
{

    /// <inheritdoc/>
    protected override async Task DoExecuteAsync(CancellationToken cancellationToken)
    {
        var input = this.Task.Input;
        var status = this.Task.Definition.Raise.Error.Status is string expression 
            ? expression.IsRuntimeExpression()
                ? await this.Task.Workflow.Expressions.EvaluateAsync<ushort>(this.Task.Definition.Raise.Error.Status, input, this.GetExpressionEvaluationArguments(), cancellationToken).ConfigureAwait(false)
                : ushort.Parse(expression)
            : ushort.Parse(this.Task.Definition.Raise.Error.Status.ToString()!);
        var type = this.Task.Definition.Raise.Error.Type.IsRuntimeExpression()
            ? (await this.Task.Workflow.Expressions.EvaluateAsync<Uri>(this.Task.Definition.Raise.Error.Type, input, this.GetExpressionEvaluationArguments(), cancellationToken).ConfigureAwait(false))!
            : new(this.Task.Definition.Raise.Error.Type, UriKind.RelativeOrAbsolute);
        var title = this.Task.Definition.Raise.Error.Title.IsRuntimeExpression()
            ? (await this.Task.Workflow.Expressions.EvaluateAsync<string>(this.Task.Definition.Raise.Error.Title, input, this.GetExpressionEvaluationArguments(), cancellationToken).ConfigureAwait(false))!
            : this.Task.Definition.Raise.Error.Title;
        var detail = string.IsNullOrWhiteSpace(this.Task.Definition.Raise.Error.Detail) ? null : this.Task.Definition.Raise.Error.Detail!.IsRuntimeExpression()
            ? await this.Task.Workflow.Expressions.EvaluateAsync<string>(this.Task.Definition.Raise.Error.Detail!, input, this.GetExpressionEvaluationArguments(), cancellationToken).ConfigureAwait(false)
            : this.Task.Definition.Raise.Error.Detail;
        var error = new Error()
        {
            Status = status,
            Type = type,
            Title = title,
            Detail = detail,
            Instance = this.Task.Instance.Reference
        };
        await this.SetErrorAsync(error, cancellationToken).ConfigureAwait(false);
    }

}
