using BlazorAppTodoAPI.CQRS.Queries;
using BlazorAppTodoAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorAppTodoAPI.Pages.Code
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        IMediator _mediator { get; set; } = default!;

        public EditContext? editctx { get; set; }

        public bool IsLoading { get; set; } = true;

        public IndexViewModel model { get; set; } = new IndexViewModel();

        public IEnumerable<TodoItem> TodoItems { get; set; } = new List<TodoItem>();

        protected override async Task OnInitializedAsync()
        {
            editctx = new(model);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Refresh();
            }
        }

        protected async Task Refresh()
        {
            try
            {
                IsLoading = true;
                TodoItems = await _mediator.Send(new TodoItemGetAllQuery());
                IsLoading = false;
                StateHasChanged();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task SetId(int id)
        {
            model.Id = id;
            StateHasChanged();
        }
    }
}
