<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/242986561/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T865247)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# How to conditionally show and hide Time Regions in Scheduler Control

Scheduler Control allows you to highlight specific time frames: [Time Regions](https://docs.devexpress.com/WPF/401378/controls-and-libraries/scheduler/time-regions). Use this approach to highlight launch time, a holiday, a certain day of the week, etc.


When you use this approach, you can notice the following: when you define a Time Region for an interval that is less than a day (several hours, minutes, etc.), MonthView will still display this region as if it takes the whole day. This example illustrates how to hide Time Regions that should not be shown in MonthView.

The main idea of this approach is to handle SchedulerControl's **FilterTimeRegion** event and set **e.Visible** to **False** if a certain Time Region should not be shown. In this example, Scheduler contains two Time Regions:


```xaml
<dxsch:SchedulerControl.TimeRegionItems>
    <dxsch:TimeRegionItem BrushName="{x:Static dxsch:DefaultBrushNames.TimeRegion3Hatch}"
                            Start="1/1/2019 13:00:00"
                            End="1/1/2019 14:00:00"
                            RecurrenceInfo="{dxsch:RecurrenceDaily Start='1/1/2019 13:00:00', ByDay=WorkDays}"
                            Type ="Pattern" />
    <dxsch:TimeRegionItem BrushName="{x:Static dxsch:DefaultBrushNames.TimeRegion1Dotted}"
                            Start="1/1/2019 00:00:00"
                            End="1/1/2019 23:59:59"
                            RecurrenceInfo="{dxsch:RecurrenceWeekly Start='1/1/2019 00:00:00', ByDay='Wednesday'}"
                            Type ="Pattern" />
</dxsch:SchedulerControl.TimeRegionItems>
```

The first Time Region highlights the launch time and should not be visible when MonthView becomes active. To hide this region in MonthView, we set the **e.Visible** property to **False** in the **FilterTimeRegion** event handler when **e.View** is **MonthView** and the Time Region's interval is less than 23 hours:

```cs
private void scheduler_FilterTimeRegion(object sender, FilterTimeRegionEventArgs e)
{
    e.Visible = e.TimeRegion.Interval.Duration.TotalHours > 23
        || !(e.View is MonthView);
}
```

We used our **DXEvent** to process the FilterTimeRegion event in XAML:

```xaml
<dxsch:SchedulerControl ...
       FilterTimeRegion="{DXEvent Handler='@args.Visible = @args.TimeRegion.Interval.Duration.TotalHours > 23 or !(@args.View is $dxsch:MonthView)'}">
    ...
</dxsch:SchedulerControl>
```

For more information, please refer to these help topics: 
- [DXEvent](https://docs.devexpress.com/WPF/115778/mvvm-framework/dxbinding/dxevent)
- [Language Specification](https://docs.devexpress.com/WPF/115777/mvvm-framework/dxbinding/language-specification)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-scheduler-filter-time-regions&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-scheduler-filter-time-regions&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
