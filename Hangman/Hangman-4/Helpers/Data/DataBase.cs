namespace HangMan.Helpers.Data
{
    using HangMan.Interfaces;

    public abstract class Database
    {
        private IDataSerialization dataSerialization;

        internal Database(IDataSerialization dataSerialization)
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
