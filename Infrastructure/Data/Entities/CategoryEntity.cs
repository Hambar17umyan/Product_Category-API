namespace Infrastructure.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// This class represents the category entity.
/// </summary>
[Table("categories")]
public class CategoryEntity : IEntity
{
    /// <summary>
    /// Gets or sets the id of the category.
    /// </summary>
    [Key]
    [Column("category_id")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the category.
    /// </summary>

    [Column("category_name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the category.
    /// </summary>

    [Column("category_description")]
    public string Description { get; set; } = string.Empty;
}
