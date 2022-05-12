﻿/*
 * Copyright © 2022-Present The Synapse Authors
 * <p>
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * <p>
 * http://www.apache.org/licenses/LICENSE-2.0
 * <p>
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

namespace Synapse.Infrastructure.Services
{

    /// <summary>
    /// Defines the fundamentals of a service used to host workflow runtimes
    /// </summary>
    public interface IWorkflowRuntimeHost
        : IDisposable, IAsyncDisposable
    {

        /// <summary>
        /// Creates the runtime and starts the execution of the specified <see cref="V1WorkflowInstance"/>
        /// </summary>
        /// <param name="workflowInstance">The <see cref="V1WorkflowInstance"/> to start the execution of</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>An id used to identify the <see cref="V1WorkflowInstance"/>'s runtime</returns>
        Task<string> StartRuntimeAsync(V1WorkflowInstance workflowInstance, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the logs associated to the execution of the specified <see cref="V1WorkflowInstance"/>
        /// </summary>
        /// <param name="runtimeIdentifier">A string used to uniquely identify the runtime to get the logs of</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>The specified <see cref="V1WorkflowInstance"/>'s execution logs</returns>
        Task<string> GetRuntimeLogsAsync(string runtimeIdentifier, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the runtime used for the execution of the specified <see cref="V1WorkflowInstance"/>
        /// </summary>
        /// <param name="runtimeIdentifier">A string used to uniquely identify the runtime to delete</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>A new awaitable <see cref="Task"/></returns>
        Task DeleteRuntimeAsync(string runtimeIdentifier, CancellationToken cancellationToken = default);

    }

}
