using AutoMapper;
using Ecommerce.Application.Carts.CreateCart;
using Ecommerce.Application.Carts.DeleteCart;
using Ecommerce.Application.Carts.GetCartByUserId;
using Ecommerce.Application.Carts.UpdateCart;
using Ecommerce.WebApi.Common;
using Ecommerce.WebApi.Features.Carts.CreateCart;
using Ecommerce.WebApi.Features.Carts.UpdateCart;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApi.Features.Carts;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CartController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCart([FromBody] CreateCartRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateCartRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateCartCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<object>
        {
            Success = true,
            Message = "Cart created successfully",
            Data = response
        });
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCartByUserId(Guid userId, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetCartByUserIdQuery { UserId = userId }, cancellationToken);
        if (response is null)
            return NotFound(new ApiResponse { Success = false, Message = "Cart not found" });

        return Ok(new ApiResponseWithData<object>
        {
            Success = true,
            Message = "Cart retrieved successfully",
            Data = response
        });
    }

    [HttpPut("{userId}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateCart(Guid userId, [FromBody] UpdateCartRequest request, CancellationToken cancellationToken)
    {
        if (userId != request.UserId)
            return BadRequest(new ApiResponse { Success = false, Message = "UserId in URL does not match body" });

        var validator = new UpdateCartRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<UpdateCartCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = result,
            Message = result ? "Cart updated successfully" : "Cart update failed"
        });
    }

    [HttpDelete("{userId}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteCart(Guid userId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteCartCommand { UserId = userId }, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = result,
            Message = result ? "Cart deleted successfully" : "Cart not found"
        });
    }
}
