import pyodbc

server = "compscifinalproject.database.windows.net"
database = "compsciproject"
username = "Guestacc1"
password = "exbKD9oQ"

# Establish a connection to the SQL Server
conn = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};SERVER='+server+';DATABASE='+database+';UID='+username+';PWD='+ password)

# Create a cursor object to execute SQL queries
cursor = conn.cursor()

# Perform an SQL query
cursor.execute("SELECT * FROM Songs")

# Fetch the results of the query
rows = cursor.fetchall()

# Print the results
for row in rows:
    print(row)

# Close the cursor and connection
cursor.close()
conn.close()