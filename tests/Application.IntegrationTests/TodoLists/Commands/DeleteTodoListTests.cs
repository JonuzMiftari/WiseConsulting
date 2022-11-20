using FluentAssertions;
using NUnit.Framework;
using WiseConsulting.Application.Common.Exceptions;
using WiseConsulting.Application.TodoLists.Commands.CreateTodoList;
using WiseConsulting.Application.TodoLists.Commands.DeleteTodoList;
using WiseConsulting.Domain.Entities;

using static WiseConsulting.Application.IntegrationTests.Testing;

namespace WiseConsulting.Application.IntegrationTests.TodoLists.Commands;
public class DeleteTodoListTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new DeleteTodoListCommand(99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        await SendAsync(new DeleteTodoListCommand(listId));

        var list = await FindAsync<TodoList>(listId);

        list.Should().BeNull();
    }
}
