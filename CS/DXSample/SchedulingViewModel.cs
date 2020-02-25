using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using DXSample.Data;
using System.Collections.ObjectModel;

namespace DXSample {
    public class SchedulingViewModel : ViewModelBase {
        protected ObservableCollection<AppointmentEntity> _Appts = new ObservableCollection<AppointmentEntity>();
        public ObservableCollection<AppointmentEntity> Appts
        {
            get { return this._Appts; }
        }


        protected ObservableCollection<ResourceEntity> _Calendars = new ObservableCollection<ResourceEntity>();
        public ObservableCollection<ResourceEntity> Calendars
        {
            get { return this._Calendars; }
        }

        public SchedulingViewModel() {
            Calendars.Add(DataHelper.Personal());
            Calendars.Add(DataHelper.Education());
            Calendars.Add(DataHelper.Work());

            DataHelper.Gym().ForEach(c => Appts.Add(c));
            Appts.Add(DataHelper.Dentist());
            Appts.Add(DataHelper.Dinner());
            Appts.Add(DataHelper.Disneyland());
            Appts.Add(DataHelper.RR());
            Appts.Add(DataHelper.DayOff());
            Appts.Add(DataHelper.SecondShift());
            Appts.Add(DataHelper.ConferenceCompanyMeeting());
            Appts.Add(DataHelper.ConferenceCustomerRetentionReview());
            Appts.Add(DataHelper.ConferenceDatabaseAndWebsiteReview());
            Appts.Add(DataHelper.ConferenceWeeklyMeeting());
            Appts.Add(DataHelper.TrainingFrenchLesson());
            Appts.Add(DataHelper.TrainingGermanLesson());
            Appts.Add(DataHelper.TrainingTrainStaffOnNewRemoteControls());
        }
    }
}
