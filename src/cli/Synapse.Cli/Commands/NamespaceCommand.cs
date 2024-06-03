﻿using Neuroglia.Data.Infrastructure.ResourceOriented;
using Synapse.Cli.Commands.Namespaces;

namespace Synapse.Cli.Commands;

/// <summary>
/// Represents the <see cref="Command"/> used to manage <see cref="Namespace"/>s
/// </summary>
public class NamespaceCommand
    : Command
{

    /// <summary>
    /// Gets the <see cref="NamespaceCommand"/>'s name
    /// </summary>
    public const string CommandName = "namespace";
    /// <summary>
    /// Gets the <see cref="NamespaceCommand"/>'s description
    /// </summary>
    public const string CommandDescription = "Manages namespaces";

    /// <inheritdoc/>
    public NamespaceCommand(IServiceProvider serviceProvider, ILoggerFactory loggerFactory, ISynapseApiClient api)
        : base(serviceProvider, loggerFactory, api, CommandName, CommandDescription)
    {
        this.AddAlias("namespaces");
        this.AddAlias("ns");
        this.AddCommand(ActivatorUtilities.CreateInstance<CreateNamespaceCommand>(this.ServiceProvider));
        this.AddCommand(ActivatorUtilities.CreateInstance<ListNamespacesCommand>(this.ServiceProvider));
        this.AddCommand(ActivatorUtilities.CreateInstance<DeleteNamespaceCommand>(this.ServiceProvider));
    }

}