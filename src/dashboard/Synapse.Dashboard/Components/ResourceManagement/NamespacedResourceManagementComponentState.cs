﻿// Copyright © 2024-Present The Synapse Authors
//
// Licensed under the Apache License, Version 2.0 (the "License"),
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Synapse.Dashboard.Components.ResourceManagement;

/// <summary>
/// Represents the state of a namespaced resource management component
/// </summary>
/// <typeparam name="TResource">The type of managed namespaced <see cref="IResource"/>s</typeparam>
public record NamespacedResourceManagementComponentState<TResource>
    : ResourceManagementComponentState<TResource>
    where TResource : Resource, new()
{

    /// <summary>
    /// Gets/sets a boolean value that indicates whether to list <see cref="Neuroglia.Data.Infrastructure.ResourceOriented.Namespace"/>s
    /// </summary>
    public bool ListNamespaces { get; set; } = true;

    /// <summary>
    /// Gets a <see cref="EquatableList{T}"/> that contains all <see cref="Neuroglia.Data.Infrastructure.ResourceOriented.Namespace"/>s
    /// </summary>
    public EquatableList<Namespace>? Namespaces { get; set; }

    /// <summary>
    /// Gets the <see cref="Neuroglia.Data.Infrastructure.ResourceOriented.Namespace"/> the (namespaced) resources to list belong to, if any
    /// </summary>
    public string? Namespace { get; set; }

}