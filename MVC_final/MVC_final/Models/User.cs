using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MVC_final.Models;

[Table("users")]
public partial class User
{
    [Key]
    [Column("User_id")]
    public int UserId { get; set; }

    [Column("First_Name")]
    [StringLength(50)]
    [Unicode(false)]
    [Required(ErrorMessage = "This Field is required")]
    public string? FirstName { get; set; }

    [Column("Last_Name")]
    [StringLength(50)]
    [Unicode(false)]
    [Required(ErrorMessage = "This Field is required")]
    public string? LastName { get; set; }
    
    [StringLength(50)]
    [Unicode(false)]
    [Required(ErrorMessage = "This Field is required")]
    public string? Username { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    [Required(ErrorMessage = "Please select a property")]
    public string? Property { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    [Required(ErrorMessage = "This Field is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    [InverseProperty("User")]
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    [InverseProperty("User")]
    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}
