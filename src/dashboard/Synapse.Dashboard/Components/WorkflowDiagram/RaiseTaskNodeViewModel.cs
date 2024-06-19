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

using Neuroglia.Blazor.Dagre;
using ServerlessWorkflow.Sdk;
using ServerlessWorkflow.Sdk.Models.Tasks;

namespace Synapse.Dashboard.Components;

/// <summary>
/// Represents a raise task node view model
/// </summary>
/// <remarks>
/// Initializes a new <see cref="RaiseTaskNodeViewModel"/>
/// </remarks>
public class RaiseTaskNodeViewModel(MapEntry<string, RaiseTaskDefinition> task)
    : LabeledWorkflowNodeViewModel(task.Key, "raise-task-node", null, Constants.NodeHeight * 1.5, Constants.NodeHeight * 1.5)
{
}
