namespace Infrastructure.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// This class represents the product entity.
/// </summary>

[Table("products")]
public class ProductEntity : IEntity
{
    /// <summary>
    /// Gets or sets the product ID.
    /// </summary>
    [Key]
    [Column("product_id")]
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the product name.
    /// </summary>

    [Column("product_name")]
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the first category of the product.
    /// </summary>

    [Column("product_category1_id")]
    [ForeignKey(nameof(Category1))]
    [Required]
    public int Category1Id { get; set; }

    /// <summary>
    /// Gets or sets the second category of the product.
    /// </summary>

    [Column("product_category2_id")]
    [ForeignKey(nameof(Category2))]
    [Required]
    public int Category2Id { get; set; }

    /// <summary>
    /// Gets or sets the third category of the product (if exists).
    /// </summary>

    [Column("product_category3_id")]
    [ForeignKey(nameof(Category3))]
    public int? Category3Id { get; set; }

    /// <summary>
    /// Gets or sets the first category of the product.
    /// </summary>
    public CategoryEntity? Category1 { get; set; }

    /// <summary>
    /// Gets or sets the second category of the product.
    /// </summary>

    public CategoryEntity? Category2 { get; set; }

    /// <summary>
    /// Gets or sets the third category of the product (if exists).
    /// </summary>

    public CategoryEntity? Category3 { get; set; }
}
