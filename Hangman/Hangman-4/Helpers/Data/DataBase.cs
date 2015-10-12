namespace HangMan.Helpers.Data
{
    using HangMan.Interfaces;

    /// <summary>
    /// Defines common functionalities for databases.
    /// </summary>
    public abstract class Database
    {
        private IDataSerialization dataSerialization;

        /// <summary>
        /// Database constructor.
        /// </summary>
        /// <param name="dataSerialization">IDataSerialization object to be turned into database.</param>
        internal Database(IDataSerialization dataSerialization)
        {
            this.DataSerialization = dataSerialization;
        }

        /// <summary>
        /// Gets the serialized data.
        /// </summary>
        public IDataSerialization DataSerialization
        {
            get
            {
                return this.dataSerialization;
            }

            private set
            {
                this.dataSerialization = value;
            }
        }
    }
}
