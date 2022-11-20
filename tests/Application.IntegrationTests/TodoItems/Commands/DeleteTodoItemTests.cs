using FluentAssertions;
using NUnit.Framework;
using WiseConsulting.Application.Common.Exceptions;
using WiseConsulting.Application.TodoItems.Commands.CreateTodoItem;
using WiseConsulting.Application.TodoItems.Commands.DeleteTodoItem;
using WiseConsulting.Application.TodoLists.Commands.CreateTodoList;
using WiseConsulting.Domain.Entities;

using static WiseConsulting.Application.IntegrationTests.Testing;

namespace WiseConsulting.Application.IntegrationTests.TodoItems.Commands;
public class DeleteTodoItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteTodoItemCommand(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var itemId = await SendAsync(new CreateTodoItemCommand
        {
            ListId = listId,
            Title = "New Item"
        });

        await SendAsync(new DeleteTodoItemCommand(itemId));

        var item = await FindAsync<TodoItem>(itemId);

        item.Should().BeNull();
    }
}
