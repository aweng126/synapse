﻿// Copyright © 2024-Present Neuroglia SRL. All rights reserved.
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

namespace Synapse;

/// <summary>
/// Exposes all default operator status phases
/// </summary>
public static class OperatorStatusPhase
{

    /// <summary>
    /// Indicates that the operator is running
    /// </summary>
    public const string Running = "running";
    /// <summary>
    /// Indicates that the operator has been stopped and is not running
    /// </summary>
    public const string Stopped = "stopped";

    /// <summary>
    /// Gets an <see cref="IEnumerable{T}"/> containing default operator status phases
    /// </summary>
    /// <returns>A new <see cref="IEnumerable{T}"/> containing default operator status phases</returns>
    public static IEnumerable<string> AsEnumerable()
    {
        yield return Running;
        yield return Stopped;
    }

}
