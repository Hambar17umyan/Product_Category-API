namespace Application.Models.Response.Queries.Products; 

using Application.Common.DTOs;
using Application.Models.Requests.Queries.Products;
using Application.Models.Response.Abstract;


/// <summary>
/// This class represents the response for the GetProductsPaginationQuery.
/// </summary>
public class GetProductsPaginationResponse : IResponse<GetProductsPaginationQuery>
{
    /// <summary>
    /// Gets or sets the page number of the response.
    /// </summary>
    public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
}