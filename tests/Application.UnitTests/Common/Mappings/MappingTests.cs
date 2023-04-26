using System.Runtime.Serialization;
using AutoMapper;
using NUnit.Framework;
using WiseConsulting.Application.Common.Mappings;
using WiseConsulting.Application.Companies.Models;
using WiseConsulting.Application.OrderCategories.Queries.GetOrderCategoriesWithPagination;
using WiseConsulting.Domain.Entities;

namespace WiseConsulting.Application.UnitTests.Common.Mappings;
public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config =>
            config.AddProfile<MappingProfile>());

        _mapper = _configuration.CreateMapper();
    }

    [Test]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Test]
    [TestCase(typeof(Company), typeof(CompanyDto))]
    [TestCase(typeof(OrderCategory), typeof(OrderCategoryVm))]
    //[TestCase(typeof(TodoList), typeof(LookupDto))]
    //[TestCase(typeof(TodoItem), typeof(LookupDto))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);

        _mapper.Map(instance, source, destination);
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

        // Type without parameterless constructor
        return FormatterServices.GetUninitializedObject(type);
    }
}
