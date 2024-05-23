﻿using Synapse.Resources;

namespace Synapse.Api.Http.Controllers;

/// <summary>
/// Represents the <see cref="NamespacedResourceController{TResource}"/> used to manage <see cref="Workflow"/>s
/// </summary>
/// <param name="mediator">The service used to mediate calls</param>
[Route("api/v1/workflows")]
public class WorkflowsController(IMediator mediator)
    : NamespacedResourceController<Workflow>(mediator)
{



}
