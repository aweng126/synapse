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

namespace Synapse.Runtime.Services
{
    /// <summary>
    /// Defines the fundamentals of a service used to manage <see cref="OAuth2Token"/>s
    /// </summary>
    public interface IOAuth2TokenManager
    {

        /// <summary>
        /// Gets an <see cref="OAuth2Token"/>
        /// </summary>
        /// <param name="properties">The properties used to configure the way the <see cref="OAuth2Token"/> to get should be generated</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>An <see cref="OAuth2Token"/></returns>
        Task<OAuth2Token> GetTokenAsync(OAuth2AuthenticationProperties properties, CancellationToken cancellationToken = default);

    }

}
