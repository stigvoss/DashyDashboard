using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashyDashboard.Client.Components.CodeBehinds
{
    public class ClockComponent : BlazorComponent
    {
        protected DateTime CurrentDateTime { get; private set; } = DateTime.Now;

        protected string TimeFormat
            => $"HH:mm{(ShowSeconds ? ":ss" : string.Empty)}";

        protected string DateFormat
            => "dddd, dd MMMM yyyy";

        [Parameter]
        protected bool ShowSeconds { get; set; }

        protected override void OnInit()
        {
            StartUpdatingPeriodically();
        }

        private void StartUpdatingPeriodically()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    UpdateCurrentDateTime();
                    StateHasChanged();

                    await Task.Delay(1000);
                }
            });
        }

        private void UpdateCurrentDateTime()
        {
            CurrentDateTime = DateTime.Now;
        }
    }
}
