using System;
namespace WiseConsulting.Domain.Entities;

public class Bank : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public string Identifier { get; set; } = string.Empty;
}