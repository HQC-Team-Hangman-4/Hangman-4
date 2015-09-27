using HangMan.Interfaces;

namespace HangMan.Helpers.Data
{
    public abstract class DataBase
    {
        private IDataSerialization dataSerialization;

        internal DataBase(IDataSerialization dataSerialization)
        {
            this.DataSerialization = dataSerialization;
        }

        public IDataSerialization DataSerialization
        {
            get
            {
                return this.dataSerialization;
            }

            private set
            {
                // TODO: Validate
                this.dataSerialization = value;
            }
        }
    }
}
