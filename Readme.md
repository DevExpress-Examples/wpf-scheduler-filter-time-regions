<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/242986561/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T865247)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF Scheduler - Filter Time Regions

This example demonstrates how to hide [Time Regions](https://docs.devexpress.com/WPF/401378/controls-and-libraries/scheduler/time-regions) that last less than a day from the [MonthView](https://docs.devexpress.com/WPF/119207/controls-and-libraries/scheduler/views/month-view).

When you define a [Time Region](https://docs.devexpress.com/WPF/401378/controls-and-libraries/scheduler/time-regions) for an interval that is less than a day (several hours, minutes, etc.), the [MonthView](https://docs.devexpress.com/WPF/119207/controls-and-libraries/scheduler/views/month-view) displays this region as if it takes the whole day. Handle the [SchedulerControl.FilterTimeRegion](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.SchedulerControl.FilterTimeRegion) event to hide time regions based on a condition.

## Implementation Details

In this example, the [Scheduler Control](https://docs.devexpress.com/WPF/114881/controls-and-libraries/scheduler) contains two [Time Regions](https://docs.devexpress.com/WPF/401378/controls-and-libraries/scheduler/time-regions):

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

Follow the steps below to hide the first time region (that lasts 1 hour) from the MonthView:

1) Handle the [FilterTimeRegion](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.SchedulerControl.FilterTimeRegion) event.
2) Set the [e.Visible](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.FilterTimeRegionEventArgs.Visible) property to `false` if [e.View](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.FilterTimeRegionEventArgs.View) is `MonthView` and the Time Region interval is less than 23 hours:

```cs
private void scheduler_FilterTimeRegion(object sender, FilterTimeRegionEventArgs e) {
    e.Visible = e.TimeRegion.Interval.Duration.TotalHours > 23
                || !(e.View is MonthView);
}
```

You can use the [DXEvent](https://docs.devexpress.com/WPF/115778/mvvm-framework/dxbinding/dxevent) extension to handle the [FilterTimeRegion](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.SchedulerControl.FilterTimeRegion) event in XAML:

```xaml
<dxsch:SchedulerControl ...
       FilterTimeRegion="{DXEvent Handler='@args.Visible = @args.TimeRegion.Interval.Duration.TotalHours > 23 or !(@args.View is $dxsch:MonthView)'}">
    ...
</dxsch:SchedulerControl>
```

## Files to Review

* [MainWindow.xaml](./CS/DXSample/MainWindow.xaml) 

## Documentation

* [Filter Appointments and Time Regions](https://docs.devexpress.com/WPF/401646/controls-and-libraries/scheduler/filter-appointments-and-time-regions)
* [Time Regions](https://docs.devexpress.com/WPF/401378/controls-and-libraries/scheduler/time-regions)
* [SchedulerControl.FilterTimeRegion](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.SchedulerControl.FilterTimeRegion)

## More Examples

* [WPF Scheduler - Highlight Time Intervals](https://github.com/DevExpress-Examples/wpf-scheduler-highlight-time-intervals)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-scheduler-filter-time-regions&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-scheduler-filter-time-regions&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
