namespace Application.Models.Response.Queries.Products; 

using Application.Models.Requests.Queries.Products;
using Application.Models.Response.Abstract;

/// <summary>
/// This class represents the response of the GetProductById query.
/// </summary>
public class GetProductByIdResponse : IResponse<GetProductByIdQuery>
{
    /// <summary>
    /// Gets or sets the id of the product.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the first category of the product.
    /// </summary>
    public int Category1Id { get; set; }

    /// <summary>
    /// Gets or sets the second category of the product.
    /// </summary>
    public int Category2Id { get; set; }

    /// <summary>
    /// Gets or sets the third category of the product (if exists).
    /// </summary>
    public int? Category3Id { get; set; }
}