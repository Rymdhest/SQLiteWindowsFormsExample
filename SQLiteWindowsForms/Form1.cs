using System.Data.SQLite;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace SQLiteWindowsForms
{
    public partial class Form1 : Form
    {
        string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
        string filename = "myDatabase.db";
        public Form1()
        {
            InitializeComponent();
        }

        private void loadButton_click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear(); //Clear all the rows first before loading new ones
            loadTableToGridview(dataGridView1);
        }

        private void saveButton_click(object sender, EventArgs e)
        {
            createNewDatabaseTable();
            insertIntoTableFromGridview(dataGridView1);
        }


        /// <summary>
        /// adds all the cars from the database to the given DataGridView.
        /// <param name="gridView">the DataGridView where all the cars should be added</param>
        /// </summary>
        private void loadTableToGridview(DataGridView gridView)
        {
            using SQLiteConnection connection = establishDatabaseConnection(path, filename);
            string stm = "SELECT * FROM cars";
            using var cmd = new SQLiteCommand(stm, connection);
            SQLiteDataReader rdr;
            //making sure there are no errors. IE table cars does not exist yet.
            try {
                rdr = cmd.ExecuteReader();

            } catch (SQLiteException exception)
            {
                Debug.WriteLine(exception.Message);
                return;
            }
            while (rdr.Read())
            {
                // we know first column(0) is id, second(1) is name, and third(2) is price.
                gridView.Rows.Add(rdr.GetString(1), rdr.GetInt32(2));
            }
            rdr.Close();
        }

        /// <summary>
        /// Initializes and opens a new connection to a database. Do not forget to call close() when done if not having "using".
        /// </summary>
        /// <param name="path">the path to the folder where the database is located</param>
        /// <param name="filename">the name of the database file including ".db"</param>
        /// <returns>the established and opened SQLiteConnection object</returns>
        private SQLiteConnection establishDatabaseConnection(string path, string filename)
        {
            string connectionString = $@"URI=file:{path}\{filename}";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }

        /// <summary>
        /// Drops any existing tables then create a new empty table in the database called cars.
        /// The cars table will have the format (id, name, price).
        /// </summary>
        private void createNewDatabaseTable()
        {
            using SQLiteConnection connection = establishDatabaseConnection(path, filename);
            using var command = new SQLiteCommand(connection);

            command.CommandText = "DROP TABLE IF EXISTS cars";
            command.ExecuteNonQuery();

            //could be made more modular instead of hardcoding the table
            command.CommandText = @"CREATE TABLE cars(id INTEGER PRIMARY KEY,
            name TEXT, price INT)";
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// adds all the cars from a given DataGridView to the table cars in the database.
        /// </summary>
        /// <param name="gridView">the DataGridView containing all the cars to be added</param>
        private void insertIntoTableFromGridview(DataGridView gridView)
        {
            using SQLiteConnection connection = establishDatabaseConnection(path, filename);
            using var command = new SQLiteCommand(connection);

            // rows -1 because last row is always empty in griedview
            for (int i = 0; i < gridView.Rows.Count - 1; i++)
            {
                //assuming column 0 is name and column 1 is price in the gridview
                //TODO: add handling of null values 
                string name = gridView.Rows[i].Cells[0].Value.ToString();
                string price = gridView.Rows[i].Cells[1].Value.ToString();

                //Beware! The following allows for SQL injection attacks.
                //a safer approach would be to call command.Parameters.AddWithValue().
                command.CommandText = $"INSERT INTO cars(name, price) VALUES('{name}','{price}')";
                command.ExecuteNonQuery();
            }
        }
    }
}
