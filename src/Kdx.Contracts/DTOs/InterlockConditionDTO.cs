using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Kdx.Contracts.DTOs
{
    public class InterlockConditionDTO : INotifyPropertyChanged
    {
        private int _id;
        private int _interlockId;
        private int _conditionNumber;
        private int _conditionTypeId;
        private InterlockConditionType? _conditionType;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public int InterlockId
        {
            get => _interlockId;
            set
            {
                _interlockId = value;
                OnPropertyChanged();
            }
        }

        public int ConditionNumber
        {
            get => _conditionNumber;
            set
            {
                _conditionNumber = value;
                OnPropertyChanged();
            }
        }

        public int ConditionTypeId
        {
            get => _conditionTypeId;
            set
            {
                _conditionTypeId = value;
                OnPropertyChanged();
            }
        }

        // Navigation property (not mapped to database)
        [JsonIgnore]
        public InterlockConditionType? ConditionType
        {
            get => _conditionType;
            set
            {
                _conditionType = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
