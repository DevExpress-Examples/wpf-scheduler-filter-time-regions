Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.Native
Imports DXSample.Data
Imports System.Collections.ObjectModel

Namespace DXSample
	Public Class SchedulingViewModel
		Inherits ViewModelBase

		Protected _Appts As New ObservableCollection(Of AppointmentEntity)()
		Public ReadOnly Property Appts() As ObservableCollection(Of AppointmentEntity)
			Get
				Return Me._Appts
			End Get
		End Property


		Protected _Calendars As New ObservableCollection(Of ResourceEntity)()
		Public ReadOnly Property Calendars() As ObservableCollection(Of ResourceEntity)
			Get
				Return Me._Calendars
			End Get
		End Property

		Public Sub New()
			Calendars.Add(DataHelper.Personal())
			Calendars.Add(DataHelper.Education())
			Calendars.Add(DataHelper.Work())

			DataHelper.Gym().ForEach(Sub(c) Appts.Add(c))
			Appts.Add(DataHelper.Dentist())
			Appts.Add(DataHelper.Dinner())
			Appts.Add(DataHelper.Disneyland())
			Appts.Add(DataHelper.RR())
			Appts.Add(DataHelper.DayOff())
			Appts.Add(DataHelper.SecondShift())
			Appts.Add(DataHelper.ConferenceCompanyMeeting())
			Appts.Add(DataHelper.ConferenceCustomerRetentionReview())
			Appts.Add(DataHelper.ConferenceDatabaseAndWebsiteReview())
			Appts.Add(DataHelper.ConferenceWeeklyMeeting())
			Appts.Add(DataHelper.TrainingFrenchLesson())
			Appts.Add(DataHelper.TrainingGermanLesson())
			Appts.Add(DataHelper.TrainingTrainStaffOnNewRemoteControls())
		End Sub
	End Class
End Namespace
