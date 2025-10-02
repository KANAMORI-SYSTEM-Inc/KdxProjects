namespace Kdx.Contracts.DTOs
{
    public class InterlockCondition
    {
        private int _id;
        private int _interlockId;
        private int _conditionNumber;
        private int _conditionTypeId;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }

        public int InterlockId
        {
            get => _interlockId;
            set
            {
                _interlockId = value;
            }
        }

        public int ConditionNumber
        {
            get => _conditionNumber;
            set
            {
                _conditionNumber = value;
            }
        }

        public int ConditionTypeId
        {
            get => _conditionTypeId;
            set
            {
                _conditionTypeId = value;
            }
        }
    }
}
