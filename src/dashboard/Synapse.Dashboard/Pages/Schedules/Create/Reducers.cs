﻿/*
 * Copyright © 2022-Present The Synapse Authors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using Neuroglia.Data.Flux;

namespace Synapse.Dashboard.Pages.Schedules.Create
{

    /// <summary>
    /// Defines Flux reducers applying to <see cref="CreateScheduleState"/>-related actions
    /// </summary>
    [Reducer]
    public static class Reducers
    {

        /// <summary>
        /// Handles the specified <see cref="HandleCreateScheduleResult"/>
        /// </summary>
        /// <param name="state">The state to reduce</param>
        /// <param name="action">The <see cref="HandleCreateScheduleResult"/> action to reduce</param>
        /// <returns>The reduced state</returns>
        public static CreateScheduleState On(CreateScheduleState state, HandleCreateScheduleResult action)
        {
            return state with
            {
                Error = action.Exception,
                Schedule = action.Schedule
            };
        }

    }

}
