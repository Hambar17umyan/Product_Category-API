namespace Application.Models.Response.Commands.Products; 

using Application.Models.Requests.Commands.Products;
using Application.Models.Response.Abstract;

/// <summary>
/// This class represents the response for creating a product.
/// </summary>
public class CreateProductResponse : IResponse<CreateProductCommand>
{
    /// <summary>
    /// Gets or sets the ID of the new product.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the name of the new product.
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the new product.
    /// </summary>
    public int ProductCategory1Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the second product category.
    /// </summary>
    public int ProductCategory2Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the third product category.
    /// </summary>
    public int? ProductCategory3Id { get; set; }
}