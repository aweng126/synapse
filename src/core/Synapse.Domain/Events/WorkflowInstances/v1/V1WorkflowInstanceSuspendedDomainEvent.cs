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

using Synapse.Integration.Events.WorkflowInstances;

namespace Synapse.Domain.Events.WorkflowInstances
{

    /// <summary>
    /// Represents the <see cref="IDomainEvent"/> fired whenever the execution of a <see cref="V1WorkflowInstance"/> has been suspended
    /// </summary>
    [DataTransferObjectType(typeof(V1WorkflowInstanceSuspendedIntegrationEvent))]
    public class V1WorkflowInstanceSuspendedDomainEvent
        : DomainEvent<Models.V1WorkflowInstance, string>
    {

        /// <summary>
        /// Initializes a new <see cref="V1WorkflowInstanceSuspendedDomainEvent"/>
        /// </summary>
        protected V1WorkflowInstanceSuspendedDomainEvent()
        {

        }

        /// <summary>
        /// Initializes a new <see cref="V1WorkflowInstanceSuspendedDomainEvent"/>
        /// </summary>
        /// <param name="id">The id of the <see cref="V1WorkflowInstance"/> which's execution has been suspended</param>
        /// <param name="logs">The logs associated to the suspended <see cref="V1WorkflowInstance"/>'s execution</param>
        public V1WorkflowInstanceSuspendedDomainEvent(string id, string logs)
            : base(id)
        {
            this.Logs = logs;
        }

        /// <summary>
        /// Gets the logs associated to the suspended <see cref="V1WorkflowInstance"/>'s execution
        /// </summary>
        public virtual string Logs { get; protected set; } = null!;

    }

}
